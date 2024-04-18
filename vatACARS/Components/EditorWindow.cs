using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using vatACARS.Helpers;
using vatACARS.Lib;
using vatACARS.Util;
using vatsys;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace vatACARS.Components
{
    public partial class EditorWindow : BaseForm
    {
        private static Logger logger = new Logger("EditorWindow");
        private static string[] response = new string[5];
        private static int responseIndex = 0;
        private static readonly Regex placeholderParse = new Regex(@"\((.*?)\)");
        private CPDLCMessage msg;

        public EditorWindow()
        {
            InitializeComponent();
            StyleComponent();
            msg = DispatchWindow.SelectedMessage;

            this.Text = $"Replying to {msg.Station}";
            ListViewItem lvMsg = new ListViewItem(msg.TimeReceived.ToString("HH:mm"));
            lvMsg.SubItems.Add($"{msg.Text}");
            lvMsg.Font = MMI.eurofont_winsml;

            lvw_messages.Items.Add(lvMsg);

            if(msg.Text == "(no message received)")
            {
                this.Text = $"Sending to {msg.Station}";
                btn_editor_Click(null, null);
                return;
            }

            lvw_messageSelector.Items.Clear();
            foreach (var uplink in Uplinks.uplinks.Entries.Where(entry => entry.Response == "N").ToList())
            {
                lvw_messageSelector.Items.Add(uplink.Element);
            }

            logger.Log("Window opened and populated.");
        }

        private void StyleComponent()
        {
            lbl_receivedMsgs.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_messages.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lvw_messageSelector.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_messageSelector.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lvw_freetextInput.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_freetextInput.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

            btn_send.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_send.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_standby.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_defer.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_tfc.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_air.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_standby.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_defer.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_tfc.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_air.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);

            DelayLabel.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            ToEditLabel.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            UnableLabel.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            scr_messageSelector.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messageSelector.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
        }

        private void ShowGroup(string group_id)
        {
            lvw_messageSelector.Items.Clear();
            List<UplinkEntry> filteredUplinks = Uplinks.uplinks.Entries.Where(entry => entry.Group == group_id).ToList();

            int visibleCount = 0;
            int startIndex = lvw_messageSelector.TopItem != null ? lvw_messageSelector.TopItem.Index : 0;
            for (int i = startIndex; i < lvw_messageSelector.Items.Count; i++)
            {
                ListViewItem item = lvw_messageSelector.Items[i];
                Rectangle itemRect = lvw_messageSelector.GetItemRect(i);
                if (lvw_messageSelector.ClientRectangle.IntersectsWith(itemRect)) visibleCount++;
            }

            int tileHeight = lvw_messageSelector.TileSize.Height;
            if(filteredUplinks.Count > 0)
            {
                scr_messageSelector.PreferredHeight = (filteredUplinks.Count * tileHeight) / 10;
                scr_messageSelector.ActualHeight = ((filteredUplinks.Count * tileHeight) / 10) - (filteredUplinks.Count - 8);
                scr_messageSelector.Enabled = true;
            } else
            {
                // Disable the scrollbar
                scr_messageSelector.PreferredHeight = 1;
                scr_messageSelector.ActualHeight = 1;
                scr_messageSelector.Enabled = false;
            }

            for (int i = startIndex; i < lvw_messageSelector.Items.Count; i++)
            {
                ListViewItem item = lvw_messageSelector.Items[i];
                Rectangle itemRect = lvw_messageSelector.GetItemRect(i);
                if (lvw_messageSelector.ClientRectangle.IntersectsWith(itemRect)) visibleCount++;
            }

            scr_messageSelector.Value = 0;
            foreach (var uplink in filteredUplinks)
            {
                lvw_messageSelector.Items.Add(uplink.Element);
            }
        }

        private void lvw_messages_SelectedIndexChanged(object sender, EventArgs e) { }

        private void lvw_messageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvw_messageSelector.SelectedItems.Count > 0)
            {
                lvw_freetextInput.Items.Clear();
                var selected = lvw_messageSelector.SelectedItems[0].Text; //Uplinks.uplinks.Entries.Where(entry => entry.Element == lvw_messageSelector.SelectedItems[0].Text).ToList().FirstOrDefault().Element;
                lvw_freetextInput.Items.Add(selected);
                response[responseIndex] = selected;
            }
        }

        private void btn_standby_Click(object sender, EventArgs e)
        {
            lvw_freetextInput.Items.Clear();
            var standby = Uplinks.uplinks.Entries.Where(entry => entry.Code == "1").ToList().FirstOrDefault().Element;
            lvw_freetextInput.Items.Add(standby);
            response = new string[5];
            response[0] = standby;
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_defer_Click(object sender, EventArgs e)
        {
            lvw_freetextInput.Items.Clear();
            var defer = Uplinks.uplinks.Entries.Where(entry => entry.Code == "2").ToList().FirstOrDefault().Element;
            lvw_freetextInput.Items.Add(defer);
            response = new string[5];
            response[0] = defer;
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_tfc_Click(object sender, EventArgs e)
        {
            lvw_freetextInput.Items.Clear();
            var unable = Uplinks.uplinks.Entries.Where(entry => entry.Code == "0").ToList().FirstOrDefault().Element;
            var tfc = Uplinks.uplinks.Entries.Where(entry => entry.Code == "166").ToList().FirstOrDefault().Element;
            lvw_freetextInput.Items.Add(tfc);
            response = new string[5];
            response[0] = unable;
            response[1] = tfc;
            responseIndex = 1;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_air_Click(object sender, EventArgs e)
        {
            lvw_freetextInput.Items.Clear();
            var unable = Uplinks.uplinks.Entries.Where(entry => entry.Code == "0").ToList().FirstOrDefault().Element;
            var air = Uplinks.uplinks.Entries.Where(entry => entry.Code == "167").ToList().FirstOrDefault().Element;
            lvw_freetextInput.Items.Add(air);
            response = new string[5];
            response[0] = unable;
            response[1] = air;
            responseIndex = 1;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_editor_Click(object sender, EventArgs e)
        {
            logger.Log("Transferring to Editor");
            lvw_freetextInput.Items.Clear();
            pnl_categories.Visible = true;
            response = new string[5];
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
            ShowGroup("1");
        }

        private void btn_messageScroller_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && responseIndex < 4)
            {
                responseIndex++;
                lvw_freetextInput.Items.Clear();
                lvw_freetextInput.Items.Add(response[responseIndex]);
                btn_messageScroller.Text = (responseIndex + 1).ToString();
            } else if(e.Button == MouseButtons.Right && responseIndex > 0)
            {
                responseIndex--;
                lvw_freetextInput.Items.Clear();
                lvw_freetextInput.Items.Add(response[responseIndex]);
                btn_messageScroller.Text = (responseIndex + 1).ToString();
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(msg.Station, "telex", string.Join("\n", response));
            HoppiesInterface.SendMessage(req);
        }

        private void scr_messageSelector_Scroll(object sender, EventArgs e)
        {
            try
            {
                lvw_messageSelector.SetScrollPosVert(scr_messageSelector.PercentageValue);
            } catch (Exception ex) { logger.Log($"An error occured:\n{ex.ToString()}"); }
        }

        private void btn_suspend_Click(object sender, EventArgs e) { }

        private void btn_category_Click(object sender, EventArgs e) {
            try
            {
                GenericButton clicked = (GenericButton)sender;
                switch (clicked.Text)
                {
                    case "LEVEL": ShowGroup("1"); break;
                    case "ROUTE": ShowGroup("2"); break;
                    case "TRANSFR": ShowGroup("3"); break;
                    case "CROSS": ShowGroup("4"); break;
                    case "ENQ/TXT": ShowGroup("5"); break;
                    case "SURV": ShowGroup("6"); break;
                    case "EXPECT": ShowGroup("7"); break;
                    case "BLK/CND": ShowGroup("8"); break;
                    case "WX/OFF": ShowGroup("9"); break;
                    case "COMM": ShowGroup("10"); break;
                    case "SPEED": ShowGroup("11"); break;
                    case "CFM/RPT": ShowGroup("12"); break;
                    case "MISC": ShowGroup("13"); break;
                    case "EMERG": ShowGroup("14"); break;
                    default: ShowGroup("1"); break;
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Something went wrong!\n{ex.ToString()}");
            }
        }

        private void lvw_freetextInput_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                response[responseIndex] = "";
                lvw_freetextInput.Items.Clear();
                lvw_messageSelector.SelectedItems.Clear();
            }
        }

        private void lvw_messages_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Font font = MMI.eurofont_winsml;
            SolidBrush bg = new SolidBrush(e.Item.BackColor);
            SolidBrush fg = new SolidBrush(e.Item.ForeColor);
            e.Graphics.FillRectangle(bg, e.Bounds);
            int n = 0;
            foreach (ListViewItem.ListViewSubItem subItem in e.Item.SubItems)
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                int offset = lvw_messages.ClientSize.Width - n;
                SizeF strSpace = e.Graphics.MeasureString(subItem.Text, font);
                if (strSpace.Width > (float)offset)
                {
                    int place = (int)Math.Floor((float)offset / (strSpace.Width / (float)subItem.Text.Length));
                    if (place > 0) e.Graphics.DrawString(subItem.Text.Substring(0, place) + "...", font, fg, subItem.Bounds, format);
                }
                else e.Graphics.DrawString(subItem.Text, font, fg, subItem.Bounds, format);
                n++;
            }
        }

        private void lvw_freetextInput_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            
            Font font = new Font(MMI.eurofont_winsml.FontFamily.Name, 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush bg = new SolidBrush(e.Item.BackColor);
            SolidBrush fg = new SolidBrush(e.Item.ForeColor);
            e.Graphics.FillRectangle(bg, e.Bounds);
            int n = 0;
            foreach (ListViewItem.ListViewSubItem subItem in e.Item.SubItems)
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(subItem.Text, font, fg, subItem.Bounds, format);

                var placeholders = placeholderParse.Matches(subItem.Text);

                if (placeholders.Count > 0)
                {
                    format.LineAlignment = StringAlignment.Far;
                    foreach (Match placeholder in placeholders)
                    {
                        SolidBrush outline = new SolidBrush(Colours.GetColour(Colours.Identities.CPDLCDownlink));
                        Pen p = new Pen(outline, 2f);

                        CharacterRange[] ranges = { new CharacterRange(placeholder.Index, placeholder.Length) };
                        format.SetMeasurableCharacterRanges(ranges);

                        Region region = e.Graphics.MeasureCharacterRanges(subItem.Text, font, subItem.Bounds, format)[0];
                        Rectangle bounds = Rectangle.Round(region.GetBounds(e.Graphics));

                        e.Graphics.FillRectangle(outline, new Rectangle(new Point(bounds.X -1, bounds.Y - 2), new Size(bounds.Width + 3, bounds.Height + 2)));
                        e.Graphics.DrawString($"{placeholder.Value})", font, bg, new PointF(bounds.X - 2, bounds.Y + 16), format);

                        // Dispose of resources
                        p.Dispose();
                        outline.Dispose();
                    }
                }

                n++;
            }
        }

        private void lvw_messageSelector_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Font font = MMI.eurofont_winsml;
            SolidBrush bg = new SolidBrush(e.Item.BackColor);
            SolidBrush fg = new SolidBrush(e.Item.ForeColor);
            e.Graphics.FillRectangle(bg, e.Bounds);
            int n = 0;
            foreach (ListViewItem.ListViewSubItem subItem in e.Item.SubItems)
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                int offset = lvw_messageSelector.ClientSize.Width - n;
                SizeF strSpace = e.Graphics.MeasureString(subItem.Text, font);
                if (strSpace.Width > (float)offset)
                {
                    int place = (int)Math.Floor((float)offset / (strSpace.Width / (float)subItem.Text.Length));
                    if (place > 0) e.Graphics.DrawString(subItem.Text.Substring(0, place) + "...", font, fg, subItem.Bounds, format);
                }
                else e.Graphics.DrawString(subItem.Text, font, fg, subItem.Bounds, format);
                n++;
            }
        }
    }
}

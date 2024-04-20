using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using vatACARS.Helpers;
using vatACARS.Lib;
using vatACARS.Util;
using vatsys;
using static vatACARS.Components.QuickFillWindow;

namespace vatACARS.Components
{
    public partial class EditorWindow : BaseForm
    {
        private static Logger logger = new Logger("EditorWindow");
        private static ResponseItem[] response = new ResponseItem[5];
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
            foreach (var uplink in XMLReader.uplinks.Entries.Where(entry => entry.Response == "N").ToList())
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
            lbl_response.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_response.Font = new Font(MMI.eurofont_winsml.FontFamily, 12F, FontStyle.Bold);

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
            List<UplinkEntry> filteredUplinks = XMLReader.uplinks.Entries.Where(entry => entry.Group == group_id).ToList();

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
                var selected = lvw_messageSelector.SelectedItems[0].Text; //Uplinks.uplinks.Entries.Where(entry => entry.Element == lvw_messageSelector.SelectedItems[0].Text).ToList().FirstOrDefault().Element;
                var placeholders = placeholderParse.Matches(selected);

                
                response[responseIndex] = new ResponseItem()
                {
                    Text = selected,
                    Placeholders = null
                };

                if (placeholders.Count > 0)
                {
                    response[responseIndex].Placeholders = new PlaceholderStr[placeholders.Count];
                    Graphics graphics = lbl_response.CreateGraphics();
                    StringFormat format = new StringFormat();
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Near;

                    for (int i = 0; i < placeholders.Count; i++)
                    {
                        CharacterRange[] ranges = { new CharacterRange(placeholders[i].Index, placeholders[i].Length) };
                        format.SetMeasurableCharacterRanges(ranges);

                        Region region = graphics.MeasureCharacterRanges(response[responseIndex].Text, lbl_response.Font, lbl_response.Bounds, format)[0];
                        Rectangle bounds = Rectangle.Round(region.GetBounds(graphics));

                        response[responseIndex].Placeholders[i] = new PlaceholderStr()
                        {
                            Placeholder = placeholders[i].Value,
                            UserValue = "",
                            TopLeftLoc = new Point(bounds.X, bounds.Y),
                            Size = new Size(bounds.Width, bounds.Height)
                        };
                    }
                } else response[responseIndex].Placeholders = new PlaceholderStr[placeholders.Count];

                lbl_response.Text = selected;
                lbl_response.Refresh();
            }
        }

        private void btn_standby_Click(object sender, EventArgs e)
        {
            var standby = XMLReader.uplinks.Entries.Where(entry => entry.Code == "1").ToList().FirstOrDefault().Element;
            lbl_response.Text = standby;
            response = new ResponseItem[5];
            response[0] = new ResponseItem() { Text = standby };
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_defer_Click(object sender, EventArgs e)
        {
            var defer = XMLReader.uplinks.Entries.Where(entry => entry.Code == "2").ToList().FirstOrDefault().Element;
            lbl_response.Text = defer;
            response = new ResponseItem[5];
            response[0] = new ResponseItem() { Text = defer };
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_tfc_Click(object sender, EventArgs e)
        {
            var unable = XMLReader.uplinks.Entries.Where(entry => entry.Code == "0").ToList().FirstOrDefault().Element;
            var tfc = XMLReader.uplinks.Entries.Where(entry => entry.Code == "166").ToList().FirstOrDefault().Element;
            lbl_response.Text = tfc;
            response = new ResponseItem[5];
            response[0] = new ResponseItem() { Text = unable };
            response[1] = new ResponseItem() { Text = tfc };
            responseIndex = 1;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_air_Click(object sender, EventArgs e)
        {
            var unable = XMLReader.uplinks.Entries.Where(entry => entry.Code == "0").ToList().FirstOrDefault().Element;
            var air = XMLReader.uplinks.Entries.Where(entry => entry.Code == "167").ToList().FirstOrDefault().Element;
            lbl_response.Text = air;
            response = new ResponseItem[5];
            response[0] = new ResponseItem() { Text = unable };
            response[1] = new ResponseItem() { Text = air };
            responseIndex = 1;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_editor_Click(object sender, EventArgs e)
        {
            logger.Log("Transferring to Editor");
            lbl_response.Text = "";
            pnl_categories.Visible = true;
            response = new ResponseItem[5];
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
            ShowGroup("1");
        }

        private void btn_messageScroller_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && responseIndex < 4)
            {
                responseIndex++;
                btn_messageScroller.Text = (responseIndex + 1).ToString();
            } else if(e.Button == MouseButtons.Right && responseIndex > 0)
            {
                responseIndex--;
                btn_messageScroller.Text = (responseIndex + 1).ToString();
            }

            lbl_response.Text = response[responseIndex].Text;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(msg.Station, "telex", string.Join("\n", response.Select(obj => obj.Text)));
            HoppiesInterface.SendMessage(req);
        }

        private void scr_messageSelector_Scroll(object sender, EventArgs e)
        {
            lvw_messageSelector.SetScrollPosVert(scr_messageSelector.PercentageValue);
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

        /*private void lvw_freetextInput_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                System.Windows.Forms.Label item = lbl_response;
                if (item != null)
                {
                    foreach(EditableInput input in editableBounds)
                    {
                        if (input.bounds.Contains(e.Location))
                        {
                            logger.Log("Opening the quick fill window...");
                            QuickFillWindow fillWindow = new QuickFillWindow(input.placeholder.Substring(1, input.placeholder.Length - 2).ToUpper());
                            fillWindow.QuickFillDataChanged += (object s, QuickFillData fillText) =>
                            {
                                try
                                {
                                    input.filled = fillText.Setting;
                                    input.graphics.FillRectangle(new SolidBrush(Colours.GetColour(Colours.Identities.CPDLCDownlink)), new Rectangle(new Point(input.bounds.X - 1, input.bounds.Y - 2), new Size(input.bounds.Width + 3, input.bounds.Height + 2)));
                                    input.graphics.DrawString($"{(input.filled != "" ? input.filled : input.placeholder)})", new Font(MMI.eurofont_winsml.FontFamily.Name, 14F, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(item.BackColor), new PointF(input.bounds.X - 2, input.bounds.Y + 16), new StringFormat());
                                }
                                catch(Exception ex)
                                {
                                    logger.Log($"Something went wrong: {ex.ToString()}");
                                }
                            };
                            fillWindow.Show(this);
                            break;
                        }
                    }
                }
            } else if(e.Button == MouseButtons.Right)
            {
                response[responseIndex] = "";
                lbl_response.Text = "";
                lvw_messageSelector.SelectedItems.Clear();
                lbl_response.Refresh();
            }
        }*/

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

        private void lbl_response_Paint(object sender, PaintEventArgs e)
        {
            if (response[responseIndex] == null || response[responseIndex].Placeholders == null) return;

            SolidBrush highlight = new SolidBrush(Colours.GetColour(Colours.Identities.CPDLCDownlink));
            SolidBrush highlightText = new SolidBrush(Colours.GetColour(Colours.Identities.WindowBackground));

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Near;

            foreach(PlaceholderStr item in response[responseIndex].Placeholders)
            {
                e.Graphics.FillRectangle(highlight, new Rectangle(item.TopLeftLoc, item.Size));
                format.Alignment = StringAlignment.Center;

                if (item.UserValue != "")
                {
                    SizeF strSpace = e.Graphics.MeasureString(item.UserValue, lbl_response.Font);
                    if (strSpace.Width > (float)item.Size.Width)
                    {
                        int place = (int)Math.Floor((float)item.Size.Width / (strSpace.Width / (float)item.UserValue.Length));
                        if (place > 0) e.Graphics.DrawString(item.UserValue.Substring(0, place) + "...", lbl_response.Font, highlightText, new PointF(item.TopLeftLoc.X + (item.Size.Width / 2), item.TopLeftLoc.Y + (item.Size.Height / 2)), format);
                    } else
                    {
                        e.Graphics.DrawString(item.UserValue, lbl_response.Font, highlightText, new PointF(item.TopLeftLoc.X + (item.Size.Width / 2), item.TopLeftLoc.Y + (item.Size.Height / 2)), format);
                    }
                }
                else
                {
                    e.Graphics.DrawString(item.Placeholder, lbl_response.Font, highlightText, new PointF(item.TopLeftLoc.X + (item.Size.Width / 2), item.TopLeftLoc.Y + (item.Size.Height / 2)), format);
                }
            }
        }

        private void lbl_response_MouseUp(object sender, MouseEventArgs e)
        {
            if (response[responseIndex] == null || response[responseIndex].Placeholders == null) return;

            for(var i = 0; i < response[responseIndex].Placeholders.Count(); i++)
            {
                PlaceholderStr item = response[responseIndex].Placeholders[i];
                if (new Rectangle(item.TopLeftLoc, item.Size).Contains(e.Location))
                {
                    try
                    {
                        QuickFillWindow fillWindow = new QuickFillWindow(item.Placeholder.Substring(1, item.Placeholder.Length - 2).ToUpper());
                        fillWindow.QuickFillDataChanged += (object s, QuickFillData data) =>
                        {
                            item.UserValue = data.Setting;
                            lbl_response.Refresh();
                        };

                        fillWindow.ShowDialog(ActiveForm);
                    } catch(Exception ex)
                    {
                        logger.Log($"Oops: {ex.ToString()}");
                    }
                    break;
                }
            }
        }
    }

    class ResponseItem
    {
        public string Text;
        public PlaceholderStr[] Placeholders;
    }

    class PlaceholderStr
    {
        public string Placeholder;
        public string UserValue;
        public Point TopLeftLoc;
        public Size Size;
    }
}

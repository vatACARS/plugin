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
using static vatACARS.Components.QuickFillWindow;
using static vatACARS.Helpers.Tranceiver;

namespace vatACARS.Components
{
    public partial class EditorWindow : BaseForm
    {
        private static Logger logger = new Logger("EditorWindow");
        private static ResponseItem[] response = new ResponseItem[5];
        private static int responseIndex = 0;
        private static readonly Regex placeholderParse = new Regex(@"\((.*?)\)");
        private IMessageData selectedMsg;
        private static readonly Dictionary<string, List<string>> keywordGroupMapping = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "14", new List<string> { "EMERG", "EMERGENCY", "MAYDAY", "PAN PAN" } } ,
            { "1", new List<string> { "LEVEL", "ALTITUDE", "FL", "DECENT", "CLIMB", "CLIMBING", "DESCENDING", "LEAVING" } },
            { "2", new List<string> { "ROUTE", "DIRECT", "HEADING", "TRACK", "DIVERTING" } },
            { "3", new List<string> { "TRANSFR", "HANDOFF", "TRANSFER" } },
            { "4", new List<string> { "CROSS", "OVERFLY", "PASS" } },
            { "5", new List<string> { "ENQ", "INQUIRE", "QUESTION", "TXT", "TEXT" } },
            { "6", new List<string> { "SURV", "SURVEILLANCE", "MONITOR" } },
            { "7", new List<string> { "EXPECT", "ANTICIPATE", "WAIT" } },
            { "8", new List<string> { "CONDITION" } },
            { "10", new List<string> { "COMM", "CONTACT", "MESSAGE", "VOICE" } },
            { "12", new List<string> { "CONFIRM", "REPORT" } },
            { "13", new List<string> { "MISC", "OTHER" } },
            { "11", new List<string> { "M", "K", "SPEED" } },
            { "9", new List<string> { "WX", "WEATHER", } }
        };

        public EditorWindow()
        {
            InitializeComponent();
            StyleComponent();
            selectedMsg = DispatchWindow.SelectedMessage;
            
            if(selectedMsg is TelexMessage)
            {
                var msg = (TelexMessage)selectedMsg;

                this.Text = $"Replying to {msg.Station}";
                ListViewItem lvMsg = new ListViewItem(msg.TimeReceived.ToString("HH:mm"));
                lvMsg.SubItems.Add($"{msg.Content}");
                lvMsg.Font = MMI.eurofont_winsml;

                lvw_messages.Items.Add(lvMsg);

                if (msg.Content == "(no message received)")
                {
                    this.Text = $"Sending to {msg.Station}";
                    btn_editor_Click(null, null);
                    return;
                }

                ShowGroupBasedOnMessageContent(msg.Content);
            } else if(selectedMsg is CPDLCMessage)
            {
                var msg = (CPDLCMessage)selectedMsg;

                this.Text = $"Replying to {msg.Station}";
                ListViewItem lvMsg = new ListViewItem(msg.TimeReceived.ToString("HH:mm"));
                lvMsg.SubItems.Add($"{msg.Content}");
                lvMsg.Font = MMI.eurofont_winsml;

                lvw_messages.Items.Add(lvMsg);

                ShowGroupBasedOnMessageContent(msg.Content);
            }

            response = new ResponseItem[5]; 
            responseIndex = 0;

            lbl_response.Invalidate();
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

        private void ShowGroupBasedOnMessageContent(string content)
        {
            foreach (var entry in keywordGroupMapping)
            {
                foreach (var keyword in entry.Value)
                {
                    if (content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        if (entry.Key == "11")
                        {
                            if (keyword.Equals("M", StringComparison.OrdinalIgnoreCase))
                            {
                                if (Regex.IsMatch(content, @"M\s*\d+", RegexOptions.IgnoreCase))
                                {
                                    ShowGroup(entry.Key);
                                    return;
                                }
                            }
                            else if (keyword.Equals("K", StringComparison.OrdinalIgnoreCase))
                            {
                                if (Regex.IsMatch(content, @"\d+\s*K", RegexOptions.IgnoreCase))
                                {
                                    ShowGroup(entry.Key);
                                    return;
                                }
                            }
                            else
                            {
                                ShowGroup(entry.Key);
                                return;
                            }
                        }
                        else
                        {
                            ShowGroup(entry.Key);
                            return;
                        }
                    }
                }
            }
            ShowGroup("1");
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
                UplinkEntry selected = (UplinkEntry)XMLReader.uplinks.Entries.Where(entry => entry.Element == lvw_messageSelector.SelectedItems[0].Text).ToList().FirstOrDefault().Clone();
                var placeholders = placeholderParse.Matches(selected.Element);

                
                response[responseIndex] = new ResponseItem()
                {
                    Entry = selected,
                    Placeholders = null
                };

                if (placeholders.Count > 0)
                {
                    response[responseIndex].Placeholders = new ResponseItemPlaceholderData[placeholders.Count];
                    Graphics graphics = lbl_response.CreateGraphics();
                    StringFormat format = new StringFormat();
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Near;

                    for (int i = 0; i < placeholders.Count; i++)
                    {
                        CharacterRange[] ranges = { new CharacterRange(placeholders[i].Index, placeholders[i].Length) };
                        format.SetMeasurableCharacterRanges(ranges);

                        Region region = graphics.MeasureCharacterRanges(response[responseIndex].Entry.Element, lbl_response.Font, lbl_response.Bounds, format)[0];
                        Rectangle bounds = Rectangle.Round(region.GetBounds(graphics));

                        response[responseIndex].Placeholders[i] = new ResponseItemPlaceholderData()
                        {
                            Placeholder = placeholders[i].Value,
                            UserValue = "",
                            TopLeftLoc = new Point(bounds.X - 4, bounds.Y - 2),
                            Size = new Size(bounds.Width + 4, bounds.Height + 2)
                        };
                    }
                } else response[responseIndex].Placeholders = new ResponseItemPlaceholderData[placeholders.Count];

                lbl_response.Text = selected.Element;
                lbl_response.Refresh();
            }
        }

        private void btn_standby_Click(object sender, EventArgs e)
        {
            var standby = (UplinkEntry)XMLReader.uplinks.Entries.Where(entry => entry.Code == "1").ToList().FirstOrDefault().Clone();
            lbl_response.Text = standby.Element;
            response = new ResponseItem[5];
            response[0] = new ResponseItem() { Entry = standby };
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_defer_Click(object sender, EventArgs e)
        {
            var defer = (UplinkEntry)XMLReader.uplinks.Entries.Where(entry => entry.Code == "2").ToList().FirstOrDefault().Clone();
            lbl_response.Text = defer.Element;
            response = new ResponseItem[5];
            response[0] = new ResponseItem() { Entry = defer };
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_tfc_Click(object sender, EventArgs e)
        {
            var unable = (UplinkEntry)XMLReader.uplinks.Entries.Where(entry => entry.Code == "0").ToList().FirstOrDefault().Clone();
            var tfc = (UplinkEntry)XMLReader.uplinks.Entries.Where(entry => entry.Code == "166").ToList().FirstOrDefault().Clone();
            lbl_response.Text = tfc.Element;
            response = new ResponseItem[5];
            response[0] = new ResponseItem() { Entry = unable };
            response[1] = new ResponseItem() { Entry = tfc };
            responseIndex = 1;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_air_Click(object sender, EventArgs e)
        {
            var unable = (UplinkEntry)XMLReader.uplinks.Entries.Where(entry => entry.Code == "0").ToList().FirstOrDefault().Clone();
            var air = (UplinkEntry)XMLReader.uplinks.Entries.Where(entry => entry.Code == "167").ToList().FirstOrDefault().Clone();
            lbl_response.Text = air.Element;
            response = new ResponseItem[5];
            response[0] = new ResponseItem() { Entry = unable };
            response[1] = new ResponseItem() { Entry = air };
            responseIndex = 1;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
        }

        private void btn_editor_Click(object sender, EventArgs e)
        {
            lbl_response.Text = "";
            pnl_categories.Visible = true;
            response = new ResponseItem[5];
            responseIndex = 0;
            btn_messageScroller.Text = (responseIndex + 1).ToString();
            ShowGroup("1");
        }

        private void btn_messageScroller_MouseDown(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Left && responseIndex < 4)
                {
                    responseIndex++;
                    btn_messageScroller.Text = (responseIndex + 1).ToString();
                }
                else if (e.Button == MouseButtons.Right && responseIndex > 0)
                {
                    responseIndex--;
                    btn_messageScroller.Text = (responseIndex + 1).ToString();
                }

                if (response[responseIndex] == null)
                {
                    response[responseIndex] = new ResponseItem();
                }

                if (response[responseIndex].Entry == null)
                {
                    response[responseIndex].Entry = new UplinkEntry();
                }

                lbl_response.Text = response[responseIndex].Entry.Element ?? string.Empty;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: replace placeholder content
                foreach (ResponseItem item in response.Where(obj => obj != null && obj.Entry.Element != ""))
                {

                    if (item.Placeholders != null)
                    {
                        foreach (ResponseItemPlaceholderData placeholder in item.Placeholders)
                        {
                            item.Entry.Element = item.Entry.Element.Replace(placeholder.Placeholder, $"@{placeholder.UserValue}@");
                        }
                    }
                    else
                    {
                        //idk
                    }
                }

                if (selectedMsg is TelexMessage)
                {
                    TelexMessage message = (TelexMessage)selectedMsg;
                    string resp = string.Join("\n", response.Where(obj => obj != null && obj.Entry.Element != "").Select(obj => obj.Entry.Element)).Replace("@", "");
                    FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedMsg.Station, "telex", resp);
                    selectedMsg.Content = resp;
                    _ = HoppiesInterface.SendMessage(req);
                    selectedMsg.setMessageState(3); // Done
                }
                else if (selectedMsg is CPDLCMessage)
                {
                    var responseCode = "N";
                    if (response.Any(obj => obj != null && obj.Entry != null && obj.Entry.Response == "R")) responseCode = "R"; // TODO: Fix priorities here
                    if (response.Any(obj => obj != null && obj.Entry != null && obj.Entry.Response == "Y")) responseCode = "Y";
                    if (response.Any(obj => obj != null && obj.Entry != null && obj.Entry.Response == "W/U")) responseCode = "WU";
                    CPDLCMessage message = (CPDLCMessage)selectedMsg;
                    string encodedMessage = string.Join("+", response.Where(obj => obj != null && obj.Entry != null && obj.Entry.Element != "").Select(obj => obj.Entry.Element));
                    string resp = $"/data2/{SentMessages}/{message.MessageId}/{responseCode}/{encodedMessage}";
                    if (resp.EndsWith("@")) resp = resp.Substring(0, resp.Length - 1);
                    FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedMsg.Station, "CPDLC", resp);

                    addSentCPDLCMessage(new SentCPDLCMessage()
                    {
                        Station = selectedMsg.Station,
                        MessageId = SentMessages,
                        ReplyMessageId = message.MessageId
                    });

                    selectedMsg.Content = resp.Replace("@", "");

                    _ = HoppiesInterface.SendMessage(req);
                    if(responseCode == "N") {
                        selectedMsg.setMessageState(3);
                    } else
                    {
                        selectedMsg.setMessageState(2); // Uplink
                    }
                }

                logger.Log("Message sent successfully");
                Close();
            }
            catch (Exception ex)
            {
                logger.Log($"Oops: {ex.ToString()}");
            }
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

        public void lbl_response_Paint(object sender, PaintEventArgs e)
        {
            if (response[responseIndex] == null || response[responseIndex].Placeholders == null) return;

            SolidBrush highlight = new SolidBrush(Colours.GetColour(Colours.Identities.CPDLCDownlink));
            SolidBrush highlightText = new SolidBrush(Colours.GetColour(Colours.Identities.WindowBackground));

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Near;

            e.Graphics.FillRectangle(new SolidBrush(Colours.GetColour(Colours.Identities.WindowBackground)), lbl_response.ClientRectangle);
            e.Graphics.DrawString(lbl_response.Text, lbl_response.Font, new SolidBrush(Colours.GetColour(Colours.Identities.InteractiveText)), lbl_response.ClientRectangle, format);

            foreach (ResponseItemPlaceholderData item in response[responseIndex].Placeholders)
            {
                e.Graphics.FillRectangle(highlight, new Rectangle(item.TopLeftLoc, item.Size));
                format.Alignment = StringAlignment.Center;

                if (item.UserValue != "")
                {
                    SizeF strSpace = e.Graphics.MeasureString(item.UserValue, lbl_response.Font);
                    if (strSpace.Width > (float)item.Size.Width)
                    {
                        int place = (int)Math.Floor((float)item.Size.Width / (strSpace.Width / (float)item.UserValue.Length) - 1);
                        if (place > 0) e.Graphics.DrawString(item.UserValue.Substring(0, place) + "*", lbl_response.Font, highlightText, new PointF(item.TopLeftLoc.X + (item.Size.Width / 2), item.TopLeftLoc.Y + (item.Size.Height / 2)), format);
                    }
                    else
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

        private void lbl_response_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                response[responseIndex] = null;

                lbl_response.Text = "";
                lbl_response.Refresh();
            }
        }

        private void lbl_response_MouseUp(object sender, MouseEventArgs e)
        {
            if (response[responseIndex] == null || response[responseIndex].Placeholders == null) return;

            for(var i = 0; i < response[responseIndex].Placeholders.Count(); i++)
            {
                ResponseItemPlaceholderData item = response[responseIndex].Placeholders[i];
                if (new Rectangle(item.TopLeftLoc, item.Size).Contains(e.Location))
                {
                    try
                    {
                        QuickFillWindow fillWindow = new QuickFillWindow(item.Placeholder.Substring(1, item.Placeholder.Length - 2).ToUpper(), item.UserValue);
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
        public UplinkEntry Entry;
        public ResponseItemPlaceholderData[] Placeholders;
    }

    class ResponseItemPlaceholderData
    {
        public string Placeholder;
        public string UserValue;
        public Point TopLeftLoc;
        public Size Size;
    }
}

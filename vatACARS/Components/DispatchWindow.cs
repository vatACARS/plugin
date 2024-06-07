using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Timers;
using System.Windows.Forms;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Tranceiver;

namespace vatACARS.Components
{
    public partial class DispatchWindow : BaseForm
    {
        private static Logger logger = new Logger("DispatchWindow");
        private List<TelexMessage> telexMessages = new List<TelexMessage>();
        private List<CPDLCMessage> CPDLCMessages = new List<CPDLCMessage>();
        private List<Station> stations = new List<Station>();
        private static ImageList il;
        public static IMessageData SelectedMessage;
        private static LogonConsentWindow LogonConsentWindow;
        private static PDCWindow PDCWindow;

        public DispatchWindow()
        {
            InitializeComponent();
            StyleComponent();

            TelexMessageReceived += UpdateTelexList;
            CPDLCMessageReceived += UpdateCPDLCList;
            MessageUpdated += UpdateList;
            StationAdded += UpdateStationsList;

            UpdateMessages();
        }

        private void StyleComponent()
        {
            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messages.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messages.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
            scr_connections.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_connections.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);

            il = new ImageList();
            il.Images.Add(Properties.Resources.RXIcon);
            il.Images.Add(Properties.Resources.DeferIcon);
            il.Images.Add(Properties.Resources.TXIcon);

            lvw_messages.SmallImageList = il;
        }

        private void PollTimer(object sender, ElapsedEventArgs e)
        {
            UpdateMessages();
        }

        private void UpdateTelexList(object sender, TelexMessage message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateTelexList(sender, message)));
                return;
            }
            UpdateMessages();
        }

        private void UpdateCPDLCList(object sender, CPDLCMessage message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateCPDLCList(sender, message)));
                return;
            }
            UpdateMessages();
        }

        private void UpdateStationsList(object sender, Station station)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateStationsList(sender, station)));
                return;
            }
            UpdateMessages();
        }

        private void UpdateList(object sender, IMessageData message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateList(sender, message)));
                return;
            }
            UpdateMessages();
        }

        private void UpdateMessages()
        {
            try
            {
                telexMessages = getAllTelexMessages().ToList();
                CPDLCMessages = getAllCPDLCMessages().ToList();
                stations = getAllStations().ToList();

                var messages = telexMessages.Cast<IMessageData>().Concat(CPDLCMessages.Cast<IMessageData>()).OrderBy(item => item.State).ThenBy(item => item.TimeReceived).ToList();
                var stationList = stations.ToList();

                lvw_messages.BeginInvoke(new Action(() =>
                {
                    lvw_messages.Items.Clear();
                    foreach (var message in messages)
                    {
                        if (message is CPDLCMessage)
                        {
                            AddMessage((CPDLCMessage)message);
                        }
                        else
                        {
                            AddMessage((TelexMessage)message);
                        }
                    }
                    lvw_messages.Refresh();
                }));

                tbl_connected.BeginInvoke(new Action(() =>
                {
                    tbl_connected.Controls.Clear();
                    foreach (var station in stationList)
                    {
                        AddStation(station);
                    }
                    tbl_connected.Refresh();
                }));
            }
            catch (Exception ex)
            {
                logger.Log($"Something went wrong:\n{ex.ToString()}");
            }
        }

        public void AddMessage(TelexMessage message)
        {
            try
            {
                ListViewItem item = new ListViewItem(message.TimeReceived.ToString("HH:mm"), message.State == 3 ? -1 : message.State);
                item.SubItems.Add($"{message.Station}: {message.Content}");
                item.Font = MMI.eurofont_winsml;
                item.Tag = message;
                item.Group = lvw_messages.Groups[message.State];
                if (message.State == 0)
                { // DOWNLINK
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCDownlink);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                else if (message.State == 1)
                { // STBY/DEFER
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCFreetext);
                }
                else if (message.State == 2)
                { // UPLINK
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                else
                {
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCFreetext);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                lvw_messages.Items.Add(item);
            }
            catch (Exception ex)
            {
                logger.Log($"Something went wrong:\n{ex.ToString()}");
            }
        }

        public void AddMessage(CPDLCMessage message)
        {
            try
            {
                ListViewItem item = new ListViewItem(message.TimeReceived.ToString("HH:mm"), message.State == 3 ? -1 : message.State);
                item.SubItems.Add($"{message.Station}: {message.Content}");
                item.Font = MMI.eurofont_winsml;
                item.Tag = message;
                item.Group = lvw_messages.Groups[message.State];
                if (message.State == 0)
                { // DOWNLINK
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCDownlink);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                else if (message.State == 1)
                { // STBY/DEFER
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCFreetext);
                }
                else if (message.State == 2)
                { // UPLINK
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                else
                {
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCFreetext);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                lvw_messages.Items.Add(item);
            }
            catch (Exception ex)
            {
                logger.Log($"Something went wrong:\n{ex.ToString()}");
            }
        }

        private void AddStation(Station station)
        {
            Label callsignLabel = new Label();
            callsignLabel.Text = station.Callsign;
            callsignLabel.TextAlign = ContentAlignment.MiddleCenter;
            callsignLabel.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
            callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
            callsignLabel.Margin = new Padding(3); // A bit of spacing

            callsignLabel.MouseEnter += (sender, e) => callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCDownlink);
            callsignLabel.MouseLeave += (sender, e) => callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);

            callsignLabel.MouseDown += (sender, e) =>
            {
                if(e.Button == MouseButtons.Left)
                {
                    SelectedMessage = new CPDLCMessage()
                    {
                        State = 0,
                        Station = callsignLabel.Text,
                        Content = "(no message received)",
                        TimeReceived = DateTime.UtcNow
                };

                    EditorWindow window = new EditorWindow();
                    window.Show(Form.ActiveForm);
                } else
                {
                    // Confirm logout
                }
            };

            tbl_connected.Controls.Add(callsignLabel);
        }

        private void lvw_messages_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Font font = MMI.eurofont_winsml;
            SolidBrush bg = new SolidBrush(e.Item.BackColor);
            SolidBrush fg = new SolidBrush(e.Item.ForeColor);
            e.Graphics.FillRectangle(bg, e.Item.Bounds);
            int n = 0;
            foreach(ListViewItem.ListViewSubItem subItem in e.Item.SubItems)
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                int offset = lvw_messages.Columns[n].Width - (n == 0 ? 0 : (int)e.Graphics.MeasureString("......", font).Width);
                SizeF strSpace = e.Graphics.MeasureString(subItem.Text, font);
                if (strSpace.Width > (float)offset)
                {
                    int place = (int)Math.Floor((float)offset / (strSpace.Width / (float)subItem.Text.Length));
                    if (place > 0) e.Graphics.DrawString(subItem.Text.Substring(0, place) + "...", font, fg, subItem.Bounds, format);
                }
                else
                {
                    e.Graphics.DrawString(subItem.Text, font, fg, n == 0 ? new Rectangle(subItem.Bounds.X + 2, subItem.Bounds.Y, subItem.Bounds.Width, subItem.Bounds.Height) : subItem.Bounds, format);
                    if (n == 0 && e.Item.ImageIndex != -1) e.Graphics.DrawImage(il.Images[e.Item.ImageIndex], e.Bounds.Left + 55, e.Bounds.Top + ((e.Bounds.Height - il.Images[e.Item.ImageIndex].Height) / 2) - 1);
                }
                n++;
            }
        }

        private void lvw_messages_MouseUp(object sender, MouseEventArgs e)
        {
            lvw_messages.SelectedItems.Clear();
            ListViewItem selected = null;
            foreach(ListViewItem item in lvw_messages.Items)
            {
                if(item.Bounds.Contains(e.Location))
                {
                    item.Selected = true;
                    selected = item;
                    break;
                }
            }

            if(selected != null)
            {
                var msg = (IMessageData)selected.Tag;

                if (e.Button == MouseButtons.Left)
                {
                    if(msg.State == 0 || msg.State == 1)
                    {
                        SelectedMessage = msg;
                        if(msg is CPDLCMessage)
                        {
                            var m = (CPDLCMessage)msg;
                            if(m.Content == "REQUEST LOGON")
                            {
                                if (LogonConsentWindow == null || LogonConsentWindow.IsDisposed)
                                    LogonConsentWindow = new LogonConsentWindow();
                                else if (LogonConsentWindow.Visible)
                                    return;

                                LogonConsentWindow.Show(ActiveForm);
                                return;
                            }
                        }
                        else if (msg is TelexMessage)
                        {
                            var m = (TelexMessage)msg;
                            if (m.Content.StartsWith("REQUEST PREDEP CLEARANCE"))
                            {
                                if (PDCWindow == null || PDCWindow.IsDisposed)
                                    PDCWindow = new PDCWindow();
                                else if (PDCWindow.Visible)
                                    return;

                                PDCWindow.Show(ActiveForm);
                                return;
                            }
                        }
                        EditorWindow window = new EditorWindow();
                        window.Show(ActiveForm);
                    }
                    lvw_messages.Invalidate();
                } else if(e.Button == MouseButtons.Right)
                {
                    if(msg.State == 0)
                    {
                        if(msg is CPDLCMessage)
                        {
                            CPDLCMessage m = (CPDLCMessage)msg;
                            FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(m.Station, "CPDLC", $"/data2/{SentMessages}/{m.MessageId}/N/STANDBY");
                            _ = HoppiesInterface.SendMessage(req);
                        }
                        if(msg is TelexMessage)
                        {
                            TelexMessage m = (TelexMessage)msg;
                            FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(m.Station, "telex", $"STANDBY");
                            _ = HoppiesInterface.SendMessage(req);
                        }
                        msg.setMessageState(1);
                        UpdateMessages();
                    }
                }
            }
        }

        private void tbl_connected_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Tranceiver;
using static vatACARS.Util.ExtendedUI;

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
        public static Station SelectedStation;
        private static LogonConsentWindow LogonConsentWindow;
        private static HandoffSelector HandoffSelector;
        private static PDCWindow PDCWindow;

        public DispatchWindow()
        {
            InitializeComponent();
            StyleComponent();

            TelexMessageReceived += UpdateTelexList;
            CPDLCMessageReceived += UpdateCPDLCList;
            MessageUpdated += UpdateList;
            StationAdded += UpdateStationsList;
            StationRemoved += UpdateStationsList;

            lvw_messages.MouseWheel += (sender, e) =>
            {
                if (scr_messages.Enabled)
                {
                    if (e.Delta > 0) scr_messages.Value -= scr_messages.Change;
                    else scr_messages.Value += scr_messages.Change;
                }
            };

            addTelexMessage(new TelexMessage()
            {
                State = 0,
                Station = "AFR1738",
                Content = "REQUEST PREDEP CLEARANCE",
                TimeReceived = DateTime.UtcNow
            });

            UpdateMessages();
        }

        private void StyleComponent()
        {
            lbl_messages.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_connections.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messages.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messages.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);

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
                    foreach(ACARSListViewItem item in lvw_messages.Items)
                    {
                        item.Dispose();
                    }
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

                    ListViewItem ph = lvw_messages.Items.Add("");
                    int tileHeight = lvw_messages.GetItemRect(ph.Index).Height;
                    lvw_messages.Items.Remove(ph);
                    if (messages.Count > 6)
                    {
                        scr_messages.PreferredHeight = messages.Count * tileHeight;
                        scr_messages.ActualHeight = lvw_messages.Height;
                        scr_messages.Enabled = true;
                        scr_messages.Change = tileHeight;
                    }
                    else
                    {
                        scr_messages.PreferredHeight = 1;
                        scr_messages.ActualHeight = 1;
                        scr_messages.Enabled = false;
                    }
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
                ACARSListViewItem item = new ACARSListViewItem(message.TimeReceived.ToString("HH:mm"), message.State == 3 ? -1 : message.State, lvw_messages);
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

                if (message.State < 2)
                {
                    GenericButton finishBtn = item.ContextMenu.CreateButton();
                    finishBtn.Text = "Unable";

                    finishBtn.Click += delegate
                    {
                        item.ContextMenu.Show(false);
                        FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(message.Station, "telex", $"UNABLE");
                        _ = HoppiesInterface.SendMessage(req);
                        message.setMessageState(3);
                        UpdateMessages();
                    };
                }

                if (message.State == 0)
                {
                    GenericButton stbyBtn = item.ContextMenu.CreateButton();
                    stbyBtn.Text = "Standby";

                    stbyBtn.Click += delegate
                    {
                        item.ContextMenu.Show(false);
                        FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(message.Station, "telex", $"STANDBY");
                        _ = HoppiesInterface.SendMessage(req);
                        message.setMessageState(1);
                        UpdateMessages();
                    };
                }
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
                ACARSListViewItem item = new ACARSListViewItem(message.TimeReceived.ToString("HH:mm"), message.State == 3 ? -1 : message.State, lvw_messages);

                item.SubItems.Add($"{message.Station.PadRight(7)}: {(message.Response != "" ? $"[{message.Response}] " : "")}{message.Content}");
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

                if(message.State < 3)
                {
                    GenericButton finishBtn = item.ContextMenu.CreateButton();
                    finishBtn.Text = "Close";

                    finishBtn.Click += delegate
                    {
                        item.ContextMenu.Show(false);
                        //FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(message.Station, "CPDLC", $"/data2/{SentMessages}/{message.MessageId}/N/UNABLE");
                        //_ = HoppiesInterface.SendMessage(req);
                        message.setMessageState(3);
                        UpdateMessages();
                    };
                }

                if (message.State == 0)
                {
                    GenericButton stbyBtn = item.ContextMenu.CreateButton();
                    stbyBtn.Text = "Standby";

                    stbyBtn.Click += delegate
                    {
                        item.ContextMenu.Show(false);
                        FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(message.Station, "CPDLC", $"/data2/{SentMessages}/{message.MessageId}/N/STANDBY");
                        _ = HoppiesInterface.SendMessage(req);
                        message.Content = "STANDBY";
                        message.setMessageState(1);
                        UpdateMessages();
                    };
                }
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
                    window.Show(ActiveForm);
                } else
                {
                    SelectedStation = station;
                    if(HandoffSelector != null)
                    {
                        HandoffSelector.Close();
                        HandoffSelector.Dispose();
                    }
                    HandoffSelector = new HandoffSelector();
                    HandoffSelector.Show(ActiveForm);
                }
            };

            tbl_connected.Controls.Add(callsignLabel);
        }

        private void lvw_messages_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ACARSListViewItem item = (ACARSListViewItem)e.Item;
            Font font = MMI.eurofont_winsml;
            SolidBrush bg = new SolidBrush(item.BackColor);
            SolidBrush fg = new SolidBrush(item.ForeColor);
            e.Graphics.FillRectangle(bg, item.Bounds);
            int n = 0;
            foreach(ListViewItem.ListViewSubItem subItem in item.SubItems)
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                int offset = lvw_messages.Columns[n].Width - (n == 0 ? 0 : (int)e.Graphics.MeasureString("......", font).Width); // TODO: This sucks
                SizeF strSpace = e.Graphics.MeasureString(subItem.Text, font);
                if (strSpace.Width > (float)offset)
                {
                    int place = (int)Math.Floor((float)offset / (strSpace.Width / (float)subItem.Text.Length));
                    if (place > 0) e.Graphics.DrawString(subItem.Text.Substring(0, place) + "...", font, fg, subItem.Bounds, format); // TODO: This sucks
                }
                else
                {
                    e.Graphics.DrawString(subItem.Text, font, fg, n == 0 ? new Rectangle(subItem.Bounds.X + 2, subItem.Bounds.Y, subItem.Bounds.Width, subItem.Bounds.Height) : subItem.Bounds, format);
                    if (n == 0 && item.ImageIndex != -1) e.Graphics.DrawImage(il.Images[item.ImageIndex], e.Bounds.Left + 55, e.Bounds.Top + ((e.Bounds.Height - il.Images[item.ImageIndex].Height) / 2) - 1);
                }
                n++;
            }
            item.ContextMenu.Show(item.ContextMenu.Open);
        }

        private void lvw_messages_MouseUp(object sender, MouseEventArgs e)
        {
            lvw_messages.SelectedItems.Clear();
            ACARSListViewItem selected = null;
            foreach(ACARSListViewItem item in lvw_messages.Items)
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
                            if(m.Content.StartsWith("REQUEST LOGON"))
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
                            if (Regex.IsMatch(m.Content, @"\b(?:REQ|REQUEST)\s+(?:(?:PRE?DEPARTURE|PREDEP)?\s+CLEARANCE)\b"))
                            {
                                if (PDCWindow.Visible) return;
                                if (!PDCWindow.IsDisposed) PDCWindow.Dispose();
                                PDCWindow = new PDCWindow();
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
                    bool isOpen = selected.ContextMenu.Open;
                    foreach (ACARSListViewItem item in lvw_messages.Items) item.ContextMenu.Show(false);
                    selected.ContextMenu.Show(!isOpen);
                }
            }
        }

        private void tbl_connected_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void scr_messages_Scroll(object sender, EventArgs e)
        {
            lvw_messages.SetScrollPosVert(scr_messages.PercentageValue);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        private static System.Timers.Timer timer;
        private static ImageList il;
        public static IMessageData SelectedMessage;

        public DispatchWindow()
        {
            InitializeComponent();
            StyleComponent();

            timer = new System.Timers.Timer();
            timer.Elapsed += PollTimer;
            timer.AutoReset = true; // Keep the timer running
            timer.Interval = 5_000;
            timer.Enabled = true;

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

        public void UpdateMessages()
        {
            try
            {
                telexMessages = Tranceiver.getAllTelexMessages().ToList();
                CPDLCMessages = Tranceiver.getAllCPDLCMessages().ToList();
                stations = Tranceiver.getAllStations().ToList();

                lvw_messages.Items.Clear();
                var messages = telexMessages.ToList<IMessageData>().Concat(CPDLCMessages.ToList<IMessageData>()).ToList<IMessageData>();
                foreach (var message in messages.OrderBy(item => item.State).ThenBy(item => item.TimeReceived).ToList<IMessageData>())
                {
                    if (message is CPDLCMessage)
                    {
                        AddMessage((CPDLCMessage)message);
                        continue;
                    }
                    AddMessage((TelexMessage)message);
                }

                foreach (var station in stations) AddStation(station);

                lvw_messages.Invalidate();
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
            // Check if a station with the same callsign already exists fix loop?
            bool stationExists = false;
            foreach (Control control in tbl_connected.Controls)
            {
                if (control is Label label && label.Text == station.Callsign)
                {
                    stationExists = true;
                    break;
                }
            }

            // If the station doesn't exist, add it
            if (!stationExists)
            {
                Label callsignLabel = new Label();
                callsignLabel.Text = station.Callsign;
                callsignLabel.TextAlign = ContentAlignment.MiddleCenter;
                callsignLabel.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                callsignLabel.Margin = new Padding(3); // A bit of spacing

                callsignLabel.MouseEnter += (sender, e) => callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCDownlink);
                callsignLabel.MouseLeave += (sender, e) => callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);

                callsignLabel.MouseUp += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        SelectedMessage = new TelexMessage()
                        {
                            State = 0,
                            Station = callsignLabel.Text,
                            Content = "(no message received)",
                            TimeReceived = DateTime.Now
                        };

                        EditorWindow window = new EditorWindow();
                        window.Show(Form.ActiveForm);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(callsignLabel.Text, "CPDLC", $"/data2/{Tranceiver.SentMessages}//N/CONTROLLER TERMINATED CPDLC");
                        FormUrlEncodedContent req2 = HoppiesInterface.ConstructMessage(callsignLabel.Text, "CPDLC", $"/data2/{Tranceiver.SentMessages}//N/LOGOFF");
                        _ = HoppiesInterface.SendMessage(req);
                        _ = HoppiesInterface.SendMessage(req2);

                        callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);

                        // Find the station and remove
                        Station stationToRemove = Tranceiver.Stations.FirstOrDefault(s => s.Callsign == callsignLabel.Text);

                        // Remove the station if found
                        if (stationToRemove != null)
                        {
                            Tranceiver.removeStation(stationToRemove);
                        }
                    }
                };

                if (tbl_connected.InvokeRequired)
                {
                    tbl_connected.Invoke((MethodInvoker)delegate
                    {
                        tbl_connected.Controls.Add(callsignLabel);
                    });
                }
                else
                {
                    tbl_connected.Controls.Add(callsignLabel);
                }
            }
        }

        //NEEDS REMOVE STATION CODE FROM THE LIST



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
                                LogonConsentWindow consentWindow = new LogonConsentWindow();
                                consentWindow.Show(ActiveForm);
                                return;
                            }
                        }
                        else if (msg is TelexMessage)
                        {
                            var m = (TelexMessage)msg;
                            if (m.Content.StartsWith("REQUEST PREDEP CLEARANCE"))
                            {
                                PDCWindow PDCWindow = new PDCWindow();
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
                            FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(m.Station, "CPDLC", $"/data2/{Tranceiver.SentMessages}/{m.MessageId}/N/STANDBY");
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

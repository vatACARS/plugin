using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Transceiver;
using static vatACARS.Util.ExtendedUI;

namespace vatACARS.Components
{
    public partial class HistoryWindow : BaseForm
    {
        public static IMessageData SelectedMessage;
        public static Station SelectedStation;
        private static Logger logger = new Logger("HistoryWindow");
        private List<Station> stations = new List<Station>();

        public HistoryWindow()
        {
            InitializeComponent();
            StyleComponent();
            TelexMessageReceived += UpdateTelexList;
            CPDLCMessageReceived += UpdateCPDLCList;
            MessageUpdated += UpdateList;
            StationAdded += UpdateStationsList;
            StationRemoved += UpdateStationsList;
        }

        public void AddMessage(IMessageData message)
        {
            try
            {
                ACARSListViewItem item = new ACARSListViewItem(message.TimeReceived.ToString("HH:mm"), (int)message.State, lvw_messages);
                item.SubItems.Add($"{message.Station.PadRight(2)}: {message.Content}");
                item.Font = MMI.eurofont_winsml;
                item.Tag = message;
                item.BackColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCFreetext);
                lvw_messages.Items.Add(item);
            }
            catch (Exception ex)
            {
                logger.Log($"Something went wrong:\n{ex.ToString()}");
            }
        }

        private void AddStation(Station station)
        {
            if (!stations.Contains(station))
            {
                stations.Add(station);
                dd_acids.Items.Add(station.Callsign);
            }
        }

        private void dd_acids_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvw_messages.Items.Clear();
            lvw_messages.Invalidate();
            string selectedCallsign = dd_acids.Text;
            SelectedStation = stations.FirstOrDefault(s => s.Callsign == selectedCallsign);
            LoadHistoryForSelectedStation();
        }

        private void HistoryWindow_Load(object sender, EventArgs e)
        {
        }

        private void HistoryWindow_ResizeEnd(object sender, EventArgs e)
        {
            int newWidth = lvw_messages.ClientRectangle.Width;
            int timestampWidth = 55;
            int messageWidth = newWidth - timestampWidth;
            col_timestamp.Width = timestampWidth;
            col_message.Width = messageWidth;
            lvw_messages.Invalidate();
            UpdateMessages();
        }

        private void HistoryWindow_SizeChanged(object sender, EventArgs e)
        {
            int newWidth = lvw_messages.ClientRectangle.Width;
            int timestampWidth = 55;
            int messageWidth = newWidth - timestampWidth;
            col_timestamp.Width = timestampWidth;
            col_message.Width = messageWidth;
            lvw_messages.Invalidate();
            UpdateMessages();
        }

        private void LoadHistoryForSelectedStation()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadHistoryForSelectedStation));
                return;
            }

            if (SelectedStation != null)
            {
                foreach (IMessageData msg in SelectedStation.History)
                {
                    AddMessage(msg);
                }

                ListViewItem ph = lvw_messages.Items.Add("");
                int tileHeight = lvw_messages.GetItemRect(ph.Index).Height;
                lvw_messages.Items.Remove(ph);
                if (SelectedStation.History.Count > 10)
                {
                    scr_messages.PreferredHeight = SelectedStation.History.Count * tileHeight;
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
            }
        }

        private void lvw_messages_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ACARSListViewItem item = (ACARSListViewItem)e.Item;
            Font font = MMI.eurofont_winsml;
            SolidBrush bg = new SolidBrush(item.BackColor);
            SolidBrush fg = new SolidBrush(item.ForeColor);
            e.Graphics.FillRectangle(bg, item.Bounds);
            int n = 0;
            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                int offset = lvw_messages.Columns[n].Width - (n == 0 ? 2 : (int)e.Graphics.MeasureString("......", font).Width);
                SizeF strSpace = e.Graphics.MeasureString(subItem.Text, font);
                if (strSpace.Width > (float)offset)
                {
                    int place = (int)Math.Floor((float)offset / (strSpace.Width / (float)subItem.Text.Length));
                    if (place > 0) e.Graphics.DrawString(subItem.Text.Substring(0, place) + "...", font, fg, new Rectangle(subItem.Bounds.X, subItem.Bounds.Y, subItem.Bounds.Width, subItem.Bounds.Height), format);
                }
                else
                {
                    e.Graphics.DrawString(subItem.Text, font, fg, new Rectangle(subItem.Bounds.X, subItem.Bounds.Y, subItem.Bounds.Width, subItem.Bounds.Height), format);
                }
                n++;
            }
            e.DrawFocusRectangle();
        }

        private void MessageScroll_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.scr_messages.Value -= scr_messages.Change;
            }
            else
            {
                if (e.Delta >= 0)
                    return;
                this.scr_messages.Value += scr_messages.Change;
            }
        }

        private void scr_messages_Scroll(object sender, EventArgs e)
        {
            lvw_messages.SetScrollPosVert(scr_messages.PercentageValue);
        }

        private void StyleComponent()
        {
            dd_acids.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            dd_acids.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            dd_acids.FocusColor = Color.Cyan;
            scr_messages.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messages.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
            scr_messages.PreferredHeight = 1;
            scr_messages.ActualHeight = 1;
            scr_messages.Enabled = false;

            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_acid.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_acid.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
        }

        private void UpdateCPDLCList(object sender, CPDLCMessage message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateCPDLCList(sender, message)));
                return;
            }
            dd_acids_SelectedIndexChanged(sender, EventArgs.Empty);
        }

        private void UpdateList(object sender, IMessageData message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateList(sender, message)));
                return;
            }
            dd_acids_SelectedIndexChanged(sender, EventArgs.Empty);
        }

        private void UpdateMessages()
        {
            var stationList = getAllStations();
            if (stationList != null)
            {
                stations.Clear();
                dd_acids.Items.Clear();
                foreach (var station in stationList)
                {
                    AddStation(station);
                }
            }
            dd_acids_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void UpdateStationsList(object sender, Station station)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, Station>(UpdateStationsList), sender, station);
                return;
            }
            UpdateMessages();
        }

        private void UpdateTelexList(object sender, TelexMessage message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateTelexList(sender, message)));
                return;
            }
            dd_acids_SelectedIndexChanged(sender, EventArgs.Empty);
        }
    }
}
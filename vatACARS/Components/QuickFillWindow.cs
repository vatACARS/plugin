using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using vatACARS.Lib;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Transceiver;
using static vatsys.FDP2;

namespace vatACARS.Components
{
    public partial class QuickFillWindow : BaseForm
    {
        private static ErrorHandler errorHandler = ErrorHandler.GetInstance();
        private static string FreeText;
        private static Logger logger = new Logger("QuickFillWindow");
        private static ListViewItem selectedItem;
        private string identifier;
        private FDR networkPilotFDR;

        private List<ListViewItem> quickFillItems = new List<ListViewItem>();

        private IMessageData selectedMsg;

        public QuickFillWindow(string identifier, IMessageData selectedMsg, string placeholder = "")
        {
            InitializeComponent();
            StyleComponent();
            this.selectedMsg = selectedMsg;
            this.identifier = identifier;
            selectedItem = new ListViewItem(placeholder);
            FreeText = "";
            OnDataChanged(placeholder.ToUpper());
            tbx_freetext.Text = placeholder;
            if (identifier == "POSITION")
            {
                LoadAddRoute();
            }
            if (identifier == "LEVEL")
            {
                LoadLevel();
            }
            if (identifier == "FREQUENCY")
            {
                LoadFreqs();
            }
            if (identifier == "UNIT NAME")
            {
                LoadFreqs();
            }
            else
            {
                try
                {
                    foreach (string item in JSONReader.quickFillItems.data[identifier])
                    {
                        AddQuickFillItem(item);
                    }
                    UpdateScrollbar();
                }
                catch (Exception ex)
                {
                    logger.Log(ex.ToString());
                }
            }

            FindItem();
            logger.Log("Opened & populated.");
        }

        public delegate void QuickFillChangedHandler(object sender, QuickFillData e);

        public event QuickFillChangedHandler QuickFillDataChanged;

        private void AddQuickFillItem(string label)
        {
            try
            {
                if (!lvw_quickfillselector.Items.Cast<ListViewItem>().Any(item => item.Text == label))
                {
                    ListViewItem item = new ListViewItem(label);
                    item.Font = MMI.eurofont_winsml;
                    item.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                    item.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
                    lvw_quickfillselector.Items.Add(item);
                    quickFillItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                errorHandler.AddError($"Oops: {ex.ToString()}");
                logger.Log($"Oops: {ex.ToString()}");
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (FreeText != "") OnDataChanged(FreeText.ToUpper());
            if (selectedItem.Text != "") OnDataChanged(selectedItem.Text.ToUpper());
            this.Close();
        }

        private void FindItem()
        {
            foreach (ListViewItem item in lvw_quickfillselector.Items)
            {
                if (item.Text == tbx_freetext.Text)
                {
                    selectedItem = item;
                    selectedItem.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                    selectedItem.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                else
                {
                    item.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                    item.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
                }
            }
        }

        private void LoadAddRoute()
        {
            networkPilotFDR = GetFDRs.FirstOrDefault((FDR f) => f.Callsign == selectedMsg.Station);
            if (networkPilotFDR == null || !GetFDRs.Contains(networkPilotFDR))
            {
                errorHandler.AddError("Pilot has invalid or No Route.");
            }
            else
            {
                foreach (FDP2.FDR.ExtractedRoute.Segment segment in networkPilotFDR.ParsedRoute.ToList())
                {
                    if (segment.Type == FDP2.FDR.ExtractedRoute.Segment.SegmentTypes.WAYPOINT)
                        if (segment.Intersection.Name.Length > 5)
                        {
                            if (segment.Intersection.FullName != "")
                            {
                                AddQuickFillItem(segment.Intersection.FullName);
                            }
                            else
                            {
                                AddQuickFillItem(segment.Intersection.Name);
                            }
                        }
                        else
                        {
                            AddQuickFillItem(segment.Intersection.Name);
                        }
                }
                UpdateScrollbar();
            }
        }

        private void LoadFreqs()
        {
            List<string> freqs = new List<string>();

            AddQuickFillItem("UNICOM 122.8");

            foreach (VSCSFrequency vscsFrequency in (IEnumerable<VSCSFrequency>)Audio.VSCSFrequencies)
            {
                if (vscsFrequency.Transmit)
                {
                    try
                    {
                        freqs.Add(vscsFrequency.Name + " " + Conversions.FrequencyToString(vscsFrequency.Frequency));
                    }
                    catch
                    {
                    }
                }
            }

            foreach (NetworkATC networkAtc in Network.GetOnlineATCs.Where<NetworkATC>((Func<NetworkATC, bool>)(a => a.IsRealATC && a.Frequencies != null)))
            {
                foreach (int frequency in networkAtc.Frequencies)
                {
                    if (frequency != 99998)
                    {
                        freqs.Add(networkAtc.Callsign + " " + Conversions.FSDFrequencyToString(frequency));
                    }
                    else
                        break;
                }
            }

            foreach (string freq in freqs)
            {
                AddQuickFillItem(freq);
            }
        }

        private void LoadLevel()
        {
            var networkPilotFDR = GetFDRs.FirstOrDefault((FDR f) => f.Callsign == selectedMsg.Station);
            if (networkPilotFDR == null || !GetFDRs.Contains(networkPilotFDR))
            {
                try
                {
                    foreach (string item in JSONReader.quickFillItems.data[identifier])
                    {
                        AddQuickFillItem(item);
                    }
                    UpdateScrollbar();
                }
                catch (Exception ex)
                {
                    logger.Log(ex.ToString());
                }
            }
            else if (networkPilotFDR.CFLString.Trim() != "")
            {
                string levelPrefix = (networkPilotFDR.CFLString.Trim() != "" && int.Parse(networkPilotFDR.CFLString) < 110 ? "A" : "FL");
                int levelValue = int.Parse(networkPilotFDR.CFLString);

                foreach (string item in JSONReader.quickFillItems.data[identifier])
                {
                    if (item.StartsWith(levelPrefix))
                    {
                        int itemValue = int.Parse(item.Substring(levelPrefix.Length));
                        if (Math.Abs(levelValue - itemValue) <= 100)
                        {
                            AddQuickFillItem(item);
                        }
                    }
                }
                UpdateScrollbar();
            }
        }

        private void lvw_quickfillselector_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Font font = MMI.eurofont_winsml;
            SolidBrush bg = new SolidBrush(e.Item.BackColor);
            SolidBrush fg = new SolidBrush(e.Item.ForeColor);
            e.Graphics.FillRectangle(bg, e.Bounds);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Near;
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-2, -2);
            e.Graphics.DrawString(e.Item.Text, font, fg, bounds, format);
        }

        private void lvw_quickfillselector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvw_quickfillselector.SelectedItems.Count > 0)
            {
                tbx_freetext.Text = lvw_quickfillselector.SelectedItems[0].Text;
                foreach (ListViewItem item in lvw_quickfillselector.Items)
                {
                    item.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                    item.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
                }
                ListViewItem selectedItem = lvw_quickfillselector.SelectedItems[0];
                if (selectedItem != null)
                {
                    selectedItem.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                    selectedItem.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
            }
        }

        private void OnDataChanged(string newData)
        {
            QuickFillDataChanged?.Invoke(this, new QuickFillData { Setting = newData });
        }

        private void QuickFillWindow_Shown(object sender, EventArgs e)
        {
        }

        private void QuickFillWindow_SizeChanged(object sender, EventArgs e)
        {
        }

        private void QuickScroll_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.scr_quickfill.Value -= scr_quickfill.Change;
            }
            else
            {
                if (e.Delta >= 0)
                    return;
                this.scr_quickfill.Value += scr_quickfill.Change;
            }
        }

        private void scr_quickfill_Scroll(object sender, EventArgs e)
        {
            lvw_quickfillselector.SetScrollPosVert(scr_quickfill.PercentageValue);
        }

        private void StyleComponent()
        {
            tbx_freetext.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            tbx_freetext.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_quickfillselector.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lvw_quickfillselector.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            scr_quickfill.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_quickfill.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
            scr_quickfill.PreferredHeight = 1;
            scr_quickfill.ActualHeight = 1;
            scr_quickfill.Enabled = false;
        }

        private void tbx_freetext_KeyUp(object sender, KeyEventArgs e)
        {
            if (selectedItem.Text != "") selectedItem.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
            FreeText = tbx_freetext.Text;
            if (((char)e.KeyCode) == (char)Keys.Enter) btn_confirm_Click(sender, null);
        }

        private void tbx_freetext_TextChanged(object sender, EventArgs e)
        {
            string placeholder = "";
            FreeText = tbx_freetext.Text;
            if (selectedItem.Text != "") selectedItem.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
            selectedItem = new ListViewItem(placeholder);
            FindItem();
            OnDataChanged(FreeText.ToUpper());
        }

        private void UpdateScrollbar()
        {
            int tileHeight = quickFillItems[0].Bounds.Height;
            if (quickFillItems.Count > 0)
            {
                scr_quickfill.PreferredHeight = quickFillItems.Count * tileHeight;
                scr_quickfill.ActualHeight = lvw_quickfillselector.Height;
                scr_quickfill.Enabled = true;
                scr_quickfill.Change = tileHeight;
            }
            else
            {
                scr_quickfill.PreferredHeight = 1;
                scr_quickfill.ActualHeight = 1;
                scr_quickfill.Enabled = false;
            }
            scr_quickfill.Value = 0;
        }

        public class QuickFillData : EventArgs
        {
            public string Setting { get; set; }
        }
    }
}
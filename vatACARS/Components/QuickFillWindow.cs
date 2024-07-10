using System;
using vatsys;
using vatACARS.Lib;
using System.Windows.Forms;
using System.Drawing;
using vatACARS.Util;
using System.Collections.Generic;
using static vatsys.Colours;
using System.Web.Configuration;

namespace vatACARS.Components
{
    public partial class QuickFillWindow : BaseForm
    {
        private static Logger logger = new Logger("QuickFillWindow");
        private static Label SelectedLabel;
        private static string FreeText;
        public delegate void QuickFillChangedHandler(object sender, QuickFillData e);
        public event QuickFillChangedHandler QuickFillDataChanged;
        private static ErrorHandler errorHandler = ErrorHandler.GetInstance();
        private List<Label> quickFillItems = new List<Label>();
        private string identifier;

        public class QuickFillData : EventArgs
        {
            public string Setting { get; set; }
        }

        public QuickFillWindow(string identifier, string placeholder = "")
        {
            InitializeComponent();
            StyleComponent();
            this.identifier = identifier;
            SelectedLabel = new Label();
            FreeText = "";
            OnDataChanged(placeholder.ToUpper());
            tbx_freetext.Text = placeholder;

            try
            {
                foreach (string item in JSONReader.quickFillItems.data[identifier])
                {
                    AddQuickFillItem(item);
                }
                UpdateScrollbar();
            } catch (Exception ex)
            {
                logger.Log(ex.ToString());
            }
            
            logger.Log("Opened & populated.");
        }

        private void StyleComponent()
        {
            tbx_freetext.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            tbx_freetext.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            scr_quickfill.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_quickfill.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
            scr_quickfill.Orientation = ScrollOrientation.HorizontalScroll;
            scr_quickfill.PreferredHeight = 1;
            scr_quickfill.ActualHeight = 1;
            scr_quickfill.Enabled = false;
        }

        private void AddQuickFillItem(string label)
        {
            try
            {
                Label quickFillItemLabel = new Label();
                quickFillItemLabel.Text = label;
                quickFillItemLabel.Size = new Size(62, 40);
                quickFillItemLabel.TextAlign = ContentAlignment.MiddleCenter;
                quickFillItemLabel.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                quickFillItemLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                quickFillItemLabel.Margin = new Padding(3); // A bit of spacing

                quickFillItemLabel.MouseEnter += (sender, e) => quickFillItemLabel.BackColor = Colours.GetColour(SelectedLabel == quickFillItemLabel ? Colours.Identities.CPDLCMessageBackground : Colours.Identities.CPDLCDownlink);
                quickFillItemLabel.MouseLeave += (sender, e) => quickFillItemLabel.BackColor = Colours.GetColour(SelectedLabel == quickFillItemLabel ? Colours.Identities.CPDLCDownlink : Colours.Identities.CPDLCUplink);

                quickFillItemLabel.MouseDown += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (SelectedLabel == quickFillItemLabel)
                        {
                            OnDataChanged(SelectedLabel.Text);
                            this.Close();
                            return;
                        }
                        if (SelectedLabel != null) SelectedLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                        tbx_freetext.Clear();
                        tbx_freetext.Text = quickFillItemLabel.Text;
                        SelectedLabel = quickFillItemLabel;
                    }
                };

                tbl_quickFillSelector.Controls.Add(quickFillItemLabel);

                quickFillItems.Add(quickFillItemLabel);
            }
            catch (Exception ex)
            {
                errorHandler.AddError($"Oops: {ex.ToString()}");
                logger.Log($"Oops: {ex.ToString()}");
            }
        }

        private void OnDataChanged(string newData)
        {
            QuickFillDataChanged?.Invoke(this, new QuickFillData { Setting = newData });
        }

        private void tbx_freetext_KeyUp(object sender, KeyEventArgs e)
        {
            if (SelectedLabel.Text != "") SelectedLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
            FreeText = tbx_freetext.Text;
            if (((char)e.KeyCode) == (char)Keys.Enter) btn_confirm_Click(sender, null);
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (FreeText != "") OnDataChanged(FreeText.ToUpper());
            if (SelectedLabel.Text != "") OnDataChanged(SelectedLabel.Text.ToUpper());
            this.Close();
        }

        private void tbx_freetext_TextChanged(object sender, EventArgs e)
        {
            string placeholder = "";
            FreeText = tbx_freetext.Text;
            if (SelectedLabel.Text != "") SelectedLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
            SelectedLabel = new Label();
            OnDataChanged(placeholder.ToUpper());
        }

        private void UpdateScrollbar()
        {
            if (quickFillItems.Count > 1)
            {
                scr_quickfill.PreferredHeight = quickFillItems.Count * 63;
                scr_quickfill.ActualHeight = (quickFillItems.Count * 63) / 10;
                scr_quickfill.Enabled = true;
                scr_quickfill.Change = (quickFillItems.Count * 63) / 10;
            }
            scr_quickfill.Value = 0;
        }

        private void scr_quickfill_Scroll(object sender, EventArgs e)
        {
            float percentageValue = scr_quickfill.PercentageValue;
            int totalItems = quickFillItems.Count;
            int itemsPerColumn = 4; 
            int totalColumns = (int)Math.Ceiling((double)totalItems / itemsPerColumn);
            tbl_quickFillSelector.SuspendLayout();
            int startColumnIndex = (int)Math.Round(percentageValue * (totalColumns - 1));
            tbl_quickFillSelector.Controls.Clear();
            for (int columnIndex = startColumnIndex; columnIndex < totalColumns; columnIndex++)
            {
                for (int itemIndex = 0; itemIndex < itemsPerColumn; itemIndex++)
                {
                    int index = columnIndex * itemsPerColumn + itemIndex;
                    if (index < totalItems)
                    {
                        Label itemLabel = quickFillItems[index];
                        tbl_quickFillSelector.Controls.Add(itemLabel);
                    }
                }
            }
            tbl_quickFillSelector.ResumeLayout();
        }
    }
}
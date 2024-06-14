using System;
using vatsys;
using vatACARS.Lib;
using System.Windows.Forms;
using System.Drawing;
using vatACARS.Util;

namespace vatACARS.Components
{
    public partial class QuickFillWindow : BaseForm
    {
        private static Logger logger = new Logger("QuickFillWindow");
        private static Label SelectedLabel;
        private static string FreeText;
        public delegate void QuickFillChangedHandler(object sender, QuickFillData e);
        public event QuickFillChangedHandler QuickFillDataChanged;

        public class QuickFillData : EventArgs
        {
            public string Setting { get; set; }
        }

        public QuickFillWindow(string identifier, string placeholder = "")
        {
            InitializeComponent();
            StyleComponent();
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
            } catch (Exception ex)
            {
                logger.Log(ex.ToString());
            }
            
            logger.Log("Opened & populated.");
        }

        private void StyleComponent()
        {
            tbx_freetext.Font = MMI.eurofont_winsml;
            tbx_freetext.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
        }

        private void AddQuickFillItem(string label)
        {
            try
            {
                Label quickFillItemLabel = new Label();
                quickFillItemLabel.Text = label;
                quickFillItemLabel.Size = new Size(62, 30);
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
                        if(SelectedLabel == quickFillItemLabel)
                        {
                            OnDataChanged(SelectedLabel.Text);
                            this.Close();
                            return;
                        }
                        if(SelectedLabel != null) SelectedLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                        tbx_freetext.Clear();
                        SelectedLabel = quickFillItemLabel;
                    }
                };

                tbl_quickFillSelector.Controls.Add(quickFillItemLabel);
            } catch(Exception ex)
            {
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
    }
}

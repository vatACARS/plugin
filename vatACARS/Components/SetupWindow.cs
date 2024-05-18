using System;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Tranceiver;

namespace vatACARS
{
    public partial class SetupWindow : BaseForm
    {

        public SetupWindow()
        {
            InitializeComponent();
            StyleComponent();
        }

        private void StyleComponent()
        {
            lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_enablehop.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_hoplogon.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_error.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lbl_stationCode.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_enablehop.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_hoplogon.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_error.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            btn_connect.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_connect.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
        }



        //JOSH PLEASE FIX :D

        //public void UpdateErrorLabel(string errorMsg)
        //{
        //    if (lbl_error.InvokeRequired)
        //    {
        //        lbl_error.Invoke((MethodInvoker)delegate { UpdateErrorLabel(errorMsg); });
        //    }
        //    else
        //    {
        //        try
        //        {
        //            lbl_error.Text = errorMsg;
        //            lbl_error.Invalidate();
        //        }
        //        catch (Exception ex)
        //        {
        //            // I think this works.
        //            logger.Log($"Error updating label: {ex.Message}");
        //        }
        //    }
        //}


        private void SetupWindow_Shown(object sender, EventArgs e)
        {
            tbx_hoplogon.Text = Properties.Settings.Default.hoplogon;
            tbx_logonCode.Text = Properties.Settings.Default.callsign;
            if (Properties.Settings.Default.toggle_hop)
            {
                toggle_hop.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
                toggle_hop.Invalidate();
            }
            else
            {
                toggle_hop.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                toggle_hop.Invalidate();
            }

            if (Tranceiver.IsConnected())
            {
                btn_connect.Text = ("Disconnect");
                tbx_hoplogon.Enabled = false;
                tbx_logonCode.Enabled = false;
                toggle_hop.Enabled = false;

                if (Properties.Settings.Default.toggle_hop)
                {
                    toggle_hop.BackColor = Colours.GetColour(Colours.Identities.ListSeparator);
                    toggle_hop.Invalidate();
                }
                else
                {
                    toggle_hop.BackColor = Colours.GetColour(Colours.Identities.WindowButtonDepressed);
                    toggle_hop.Invalidate();
                }
            }
            else
            {
                btn_connect.Text = ("Connect");
                tbx_logonCode.Enabled = true;
                toggle_hop.Enabled = true;

                if (Properties.Settings.Default.toggle_hop)
                {
                    toggle_hop.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
                    toggle_hop.Invalidate();
                    tbx_hoplogon.Enabled = true;
                }
                else
                {
                    toggle_hop.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                    toggle_hop.Invalidate();
                    tbx_hoplogon.Enabled = false;
                }
            }
        }


        private void lbl_logonCode_Click(object sender, EventArgs e)
        {

        }

        private void tbx_hoplogon_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hoplogon = tbx_hoplogon.Text;
            Properties.Settings.Default.Save();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (Tranceiver.IsConnected())
            {
                Tranceiver.SetConnected(false);
                btn_connect.Text = ("Connect");
                tbx_logonCode.Enabled = true;
                toggle_hop.Enabled = true;

                if (Properties.Settings.Default.toggle_hop)
                {
                    toggle_hop.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
                    toggle_hop.Invalidate();
                    tbx_hoplogon.Enabled = true;
                }
                else
                {
                    toggle_hop.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                    toggle_hop.Invalidate();
                    tbx_hoplogon.Enabled = false;
                }
            }
            else
            {
                ClientInformation.LogonCode = Properties.Settings.Default.hoplogon;
                ClientInformation.Callsign = tbx_logonCode.Text;
                Logger logger = new Logger("vatACARS");
                logger.Log("Starting Hoppies integration...");
                HoppiesInterface.StartListening();
                Tranceiver.SetConnected(true);
                btn_connect.Text = ("Disconnect");
                tbx_hoplogon.Enabled = false;
                tbx_logonCode.Enabled = false;
                toggle_hop.Enabled = false;

                if (Properties.Settings.Default.toggle_hop)
                {
                    toggle_hop.BackColor = Colours.GetColour(Colours.Identities.ListSeparator);
                    toggle_hop.Invalidate();
                }
                else
                {
                    toggle_hop.BackColor = Colours.GetColour(Colours.Identities.WindowButtonDepressed);
                    toggle_hop.Invalidate();;
                }
            }
        }

        public void tbx_logonCode_TextChanged(object sender, EventArgs e)
        {
            string newText = tbx_logonCode.Text.ToUpper();

            if (newText.Length > 4)
            {
                newText = newText.Substring(0, 4);
            }

            if (tbx_logonCode.Text != newText)
            {
                tbx_logonCode.Text = newText;
                tbx_logonCode.SelectionStart = tbx_logonCode.Text.Length;
            }
            Properties.Settings.Default.callsign = tbx_logonCode.Text;
            Properties.Settings.Default.Save();
        }



        private void toggle_hop_MouseUp(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.toggle_hop)
            {
                toggle_hop.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                toggle_hop.Invalidate();
                SetHoppies(false);
                tbx_hoplogon.Enabled = false;
            }
            else
            {
                toggle_hop.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
                toggle_hop.Invalidate();
                SetHoppies(true);
                tbx_hoplogon.Enabled = true;
            }
        }


        private static bool Hoppies = Properties.Settings.Default.toggle_hop;

        public static void SetHoppies(bool value)
        {
            Logger logger = new Logger("vatACARS");
            if (Hoppies != value)
            {
                Hoppies = value;
                if (Hoppies)
                {
                    Properties.Settings.Default.toggle_hop = true;
                    logger.Log("Hoppies ON.");
                }
                else
                {
                    Properties.Settings.Default.toggle_hop = false;
                    logger.Log("Hoppies OFF.");
                }
                Properties.Settings.Default.Save();
            }
        }
    }
}
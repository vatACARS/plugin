using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
            lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_vatACARSToken.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_enablehop.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_hoplogon.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_vol.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_timeout.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lbl_stationCodePrompt.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_stationCode.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_vatACARSToken.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_enablehop.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_hoplogon.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_vol.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_timeout.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            btn_connect.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_connect.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);

            slider_vol.ForeColor = Colours.GetColour(Colours.Identities.ListSeparator);
            slider_vol.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
        }


        private void SetupWindow_Shown(object sender, EventArgs e)
        {
            tbx_hoplogon.Text = Properties.Settings.Default.hoplogon;
            tbx_stationCode.Text = Properties.Settings.Default.callsign;
            tbx_timeout.Text = Properties.Settings.Default.fin_timeout.ToString();
            slider_vol.Value = Properties.Settings.Default.volume;
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

            /*
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
            */
        }

        private void tbx_hoplogon_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hoplogon = tbx_hoplogon.Text;
            Properties.Settings.Default.Save();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            foreach(Control ctl in Controls)
            {
                if(ctl is TextLabel)
                {
                    ctl.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
                    ctl.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                }
            }

            // Check if any information is missing
            bool checksFailed = false;
            if (!Network.Me.ATIS.Any((string atisLine) => new Regex(@"CPDLC [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0 || new Regex(@"CPDLC LOG[IO]N [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0))
            {
                lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                tbx_stationCode.Text = "Try again.";
                checksFailed = true;
            }

            if(tbx_vatAcarsToken.Text.Length != 0 && (!tbx_vatAcarsToken.Text.StartsWith("vAcV1-") && tbx_vatAcarsToken.Text.Length != 32))
            {
                lbl_vatACARSToken.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                //checksFailed = true; // vatACARSToken is not required
            }

            if(Properties.Settings.Default.toggle_hop && tbx_hoplogon.Text.Length < 15)
            {
                lbl_hoplogon.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                checksFailed = true;
            }

            //if (checksFailed) return;

            ClientInformation.LogonCode = Properties.Settings.Default.hoplogon;
            ClientInformation.Callsign = tbx_stationCode.Text;
            HoppiesInterface.StartListening();
            /*
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
            */
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

        private void SetupWindow_Load(object sender, EventArgs e)
        {

        }

        private void slider_vol_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.volume = slider_vol.Value;
            Properties.Settings.Default.Save();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {

        }

        private void btn_test_MouseUp(object sender, MouseEventArgs e)
        {
            AudioInterface.playSound("incomingMessage");
        }

        public void tbx_timeout_TextChanged(object sender, EventArgs e)
        {
            string newText = new string(tbx_timeout.Text.Where(char.IsDigit).ToArray());

            if (tbx_timeout.Text != newText)
            {
                tbx_timeout.Text = newText;
                tbx_timeout.SelectionStart = tbx_timeout.Text.Length;
            }

            if (int.TryParse(newText, out int timeout))
            {
                Properties.Settings.Default.fin_timeout = timeout;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_checkStationCode_Click(object sender, EventArgs e)
        {
            if (!Network.Me.ATIS.Any((string atisLine) => new Regex(@"CPDLC [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0 || new Regex(@"CPDLC LOG[IO]N [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0))
            {
                lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                tbx_stationCode.Text = "Try again.";
            } else
            {
                Match stationCode = Network.Me.ATIS.Select(atisLine => new {
                Line = atisLine,
                Match = new Regex(@"CPDLC LOG[IO]N [A-Z]{4}").Match(atisLine.ToUpperInvariant()).Success
                         ? new Regex(@"CPDLC LOG[IO]N [A-Z]{4}").Match(atisLine.ToUpperInvariant())
                         : new Regex(@"CPDLC [A-Z]{4}").Match(atisLine.ToUpperInvariant())
                }).FirstOrDefault(result => result.Match.Success)?.Match;
                if (stationCode != null)
                {
                    lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
                    lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
                    tbx_stationCode.Text = stationCode.Value.Split(' ')[1].ToUpperInvariant();
                } else
                {
                    lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                    lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                    tbx_stationCode.Text = "Try again.";
                }
            }
            Invalidate();
            Update();
        }
    }
}
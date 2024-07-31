using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using vatACARS.Components;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Transceiver;

namespace vatACARS
{
    public partial class SetupWindow : BaseForm
    {
        private static HttpClient client = new HttpClient();
        private static DebugWindow debugWindow;

        private static bool Hoppies = Properties.Settings.Default.enableHoppies;
        private static bool sendReports = Properties.Settings.Default.sendReports;

        public SetupWindow()
        {
            InitializeComponent();
            StyleComponent();
            this.Text = ($"vatACARS Setup v{AppData.CurrentVersion}");
        }

        public static void SetHoppies(bool value)
        {
            Logger logger = new Logger("vatACARS");
            if (Hoppies != value)
            {
                Hoppies = value;
                if (Hoppies)
                {
                    Properties.Settings.Default.enableHoppies = true;
                    logger.Log("Hoppies ON.");
                }
                else
                {
                    Properties.Settings.Default.enableHoppies = false;
                    logger.Log("Hoppies OFF.");
                }
                Properties.Settings.Default.Save();
            }
        }

        public static void SetReports(bool value)
        {
            Logger logger = new Logger("vatACARS");
            if (sendReports != value)
            {
                sendReports = value;
                if (sendReports)
                {
                    Properties.Settings.Default.sendReports = true;
                    logger.Log("Reports ON.");
                }
                else
                {
                    Properties.Settings.Default.sendReports = false;
                    logger.Log("Reports OFF.");
                }
                Properties.Settings.Default.Save();
            }
        }

        public void tbx_messageTimeout_TextChanged(object sender, EventArgs e)
        {
            string newText = new string(tbx_messageTimeout.Text.Where(char.IsDigit).ToArray());

            if (tbx_messageTimeout.Text != newText)
            {
                tbx_messageTimeout.Text = newText;
                tbx_messageTimeout.SelectionStart = tbx_messageTimeout.Text.Length;
            }

            if (int.TryParse(newText, out int timeout))
            {
                Properties.Settings.Default.finishedMessageTimeout = timeout;
                Properties.Settings.Default.Save();
            }
        }

        private static void DoShowDebugWindow()
        {
            if (debugWindow == null || debugWindow.IsDisposed)
            {
                debugWindow = new DebugWindow();
            }
            else if (debugWindow.Visible)
            {
                return;
            }

            debugWindow.Show(Form.ActiveForm);
        }

        private void btn_auralAlertVolumeTest_MouseUp(object sender, MouseEventArgs e)
        {
            AudioInterface.playSound("incomingMessage");
        }

        private void btn_checkStationCode_Click(object sender, EventArgs e)
        {
            if (!Network.Me.ATIS.Any((string atisLine) => new Regex(@"PDC [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0 || new Regex(@"CPDLC [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0 || new Regex(@"CPDLC LOG[IO]N [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0))
            {
                lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                tbx_stationCode.Text = "Try again.";
            }
            else
            {
                Match stationCode = Network.Me.ATIS.Select(atisLine => new
                {
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
                    Properties.Settings.Default.stationCode = tbx_stationCode.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    stationCode = Network.Me.ATIS.Select(atisLine => new
                    {
                        Line = atisLine,
                        Match = new Regex(@"PDC [A-Z]{4}").Match(atisLine.ToUpperInvariant())
                    }).FirstOrDefault(result => result.Match.Success)?.Match;

                    if (stationCode != null)
                    {
                        lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
                        lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
                        tbx_stationCode.Text = stationCode.Value.Split(' ')[1].ToUpperInvariant();
                        Properties.Settings.Default.stationCode = tbx_stationCode.Text;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                        lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                        tbx_stationCode.Text = "Try again.";
                    }
                }
            }
            Invalidate();
            Update();
        }

        private async void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    HoppiesInterface.StopListening();
                    VatACARSInterface.StopListening();

                    foreach (Control ctl in Controls) if (ctl is GenericButton || ctl is TextField) ctl.Enabled = true;
                    btn_connect.Text = "Connect";
                    lbl_statusMessage.Text = "Disconnected from vatACARS.";
                    connected = false;
                    return;
                }

                btn_checkStationCode_Click(null, null);

                if (Properties.Settings.Default.netChecks) 
                {

                if (!Network.IsConnected)
                {
                    lbl_statusMessage.Text = "Please connect to VATSIM first.";
                    return;
                }

                if (!Network.IsValidATC)
                {
                    lbl_statusMessage.Text = "Please connect as a non-observer role.";
                    return;
                }
                
                }

                foreach (Control ctl in Controls)
                {
                    if (ctl is TextLabel)
                    {
                        ctl.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
                        ctl.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                    }

                    if (ctl is GenericButton || ctl is TextField)
                    {
                        ctl.Enabled = false;
                    }
                }

                btn_auralAlertVolumeTest.Enabled = true;
                tbx_messageTimeout.Enabled = true;

                Application.DoEvents();

                // Check if any information is missing
                bool checksFailed = false;
                if (!Network.Me.ATIS.Any((string atisLine) => new Regex(@"PDC [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0 || new Regex(@"CPDLC [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0 || new Regex(@"CPDLC LOG[IO]N [A-Z]{4}").Matches(atisLine.ToUpperInvariant()).Count > 0))
                {
                    lbl_stationCodePrompt.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                    lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                    tbx_stationCode.Text = "Try again.";
                    checksFailed = true;
                }

                if (tbx_vatACARSToken.Text.Length != 0 && (!tbx_vatACARSToken.Text.StartsWith("vAcV1-") && tbx_vatACARSToken.Text.Length != 32))
                {
                    lbl_vatACARSToken.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                    lbl_statusMessage.Text = "Your vatACARS token appears invalid.";
                    checksFailed = true;
                }

                if (Properties.Settings.Default.enableHoppies && tbx_hoppiesLogonCode.Text.Length < 10)
                {
                    lbl_hoppiesLogonCode.ForeColor = Colours.GetColour(Colours.Identities.Warning);
                    lbl_statusMessage.Text = "Your hoppies code appears invalid.";
                    checksFailed = true;
                }

                if (!Properties.Settings.Default.enableHoppies)
                {
                    lbl_statusMessage.Text = "Hoppies must be enabled for now.";
                    checksFailed = true;
                }

                if (checksFailed)
                {
                    foreach (Control ctl in Controls) if (ctl is GenericButton || ctl is TextField) ctl.Enabled = true;
                    return;
                }

                string LogonResponse = await client.PostStringTaskAsync("/atsu/logon", new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"station", tbx_stationCode.Text},
                    {"token", tbx_vatACARSToken.Text},
                    {"sectors", JsonConvert.SerializeObject(MMI.SectorsControlled.Where(sector => !MMI.SectorsControlled.SelectMany(s => s.SubSectors).Contains(sector)).ToList().Select(sector => new { name = sector.Name, callsign = sector.Callsign, frequency = sector.Frequency }).ToArray()) },
                    {"approxLoc", JsonConvert.SerializeObject(new { latitude = MMI.PrimePosition.DefaultCenter.Latitude, longitude = MMI.PrimePosition.DefaultCenter.Longitude })}
                }));

                APIResponse ResponseDecoded = JsonConvert.DeserializeObject<APIResponse>(LogonResponse);

                if (ResponseDecoded.Success == false) checksFailed = true;
                lbl_statusMessage.Text = ResponseDecoded.Message;

                if (checksFailed)
                {
                    foreach (Control ctl in Controls) if (ctl is GenericButton || ctl is TextField) ctl.Enabled = true;
                    return;
                }

                Application.DoEvents();

                ClientInformation.LogonCode = Properties.Settings.Default.hoppiesLogonCode;
                ClientInformation.Callsign = tbx_stationCode.Text;
                HoppiesInterface.StartListening();
                VatACARSInterface.StartListening();

                connected = true;
                btn_connect.Text = "Disconnect";
                btn_connect.Enabled = true;
            }
            catch (Exception ex)
            {
                lbl_statusMessage.Text = ex.ToString();
            }
        }

        private void btn_enableHoppies_MouseUp(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.enableHoppies = !Properties.Settings.Default.enableHoppies;
            btn_enableHoppies.Text = Properties.Settings.Default.enableHoppies ? "\u2713" : "";
            btn_enableHoppies.Invalidate();
            SetHoppies(Properties.Settings.Default.enableHoppies);
            tbx_hoppiesLogonCode.Enabled = Properties.Settings.Default.enableHoppies;
            Properties.Settings.Default.Save();
        }

        private void SetupWindow_Shown(object sender, EventArgs e)
        {
            tbx_stationCode.Text = Properties.Settings.Default.stationCode;
            tbx_vatACARSToken.Text = Properties.Settings.Default.vatACARSToken;
            tbx_hoppiesLogonCode.Text = Properties.Settings.Default.hoppiesLogonCode;
            tbx_messageTimeout.Text = Properties.Settings.Default.finishedMessageTimeout.ToString();
            sld_auralAlertVolume.Value = Properties.Settings.Default.auralAlertVolume;

            btn_enableHoppies.Text = Properties.Settings.Default.enableHoppies ? "\u2713" : "";
            btn_enableHoppies.Invalidate();
            btn_sendreports.Text = Properties.Settings.Default.sendReports ? "\u2713" : "";
            btn_sendreports.Invalidate();

            SetReports(Properties.Settings.Default.sendReports);
            SetHoppies(Properties.Settings.Default.enableHoppies);
            tbx_hoppiesLogonCode.Enabled = Properties.Settings.Default.enableHoppies;

            if (connected)
            {
                foreach (Control ctl in Controls) if (ctl is GenericButton || ctl is TextField) ctl.Enabled = false;
                btn_auralAlertVolumeTest.Enabled = true;
                tbx_messageTimeout.Enabled = true;

                btn_connect.Text = "Disconnect";
                btn_connect.Enabled = true;
                lbl_statusMessage.Text = $"Logged in as {tbx_stationCode.Text}";
            }
        }

        private void sld_auralAlertVolume_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.auralAlertVolume = sld_auralAlertVolume.Value;
            Properties.Settings.Default.Save();
        }

        private void StyleComponent()
        {
            foreach (Control ctl in Controls)
            {
                if (ctl is TextLabel)
                {
                    ctl.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
                    ctl.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                }
            }

            btn_connect.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_connect.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);

            sld_auralAlertVolume.ForeColor = Colours.GetColour(Colours.Identities.ListSeparator);
            sld_auralAlertVolume.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            sld_auralAlertVolume.Font = MMI.eurofont_winsml;
        }

        private void tbx_hoppiesLogonCode_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hoppiesLogonCode = tbx_hoppiesLogonCode.Text;
            Properties.Settings.Default.Save();
        }

        private void tbx_vatAcarsToken_TextChanged(object sender, EventArgs e)
        {
            if (tbx_vatACARSToken.Text.StartsWith("vAcV1-") && tbx_vatACARSToken.Text.Length == 32)
            {
                Properties.Settings.Default.vatACARSToken = tbx_vatACARSToken.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_sendreports_MouseUp(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.sendReports = !Properties.Settings.Default.sendReports;
            btn_sendreports.Text = Properties.Settings.Default.sendReports ? "\u2713" : "";
            btn_sendreports.Invalidate();
            SetReports(Properties.Settings.Default.sendReports);
            Properties.Settings.Default.Save();
        }
    }
}
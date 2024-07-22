using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Transceiver;
using static vatsys.FDP2;

namespace vatACARS.Components
{
    public partial class PDCWindow : BaseForm
    {
        private static Logger logger = new Logger("PDCWindow");
        private ErrorHandler errorHandler = ErrorHandler.GetInstance();
        private FDR networkPilotFDR;
        private Dictionary<string, string> PDCElements = new Dictionary<string, string>();
        private IMessageData selectedMsg;

        public PDCWindow()
        {
            InitializeComponent();
            selectedMsg = DispatchWindow.SelectedMessage;

            StyleComponent();
            InitPlaceholders();
            LoadDepFreq();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string encodedMessage = $"{string.Join("\n", PDCElements.Values)}\nDEP FREQ: {dd_freq.Text}{(tbx_freetext.Text != "" ? $"\n{tbx_freetext.Text.ToUpperInvariant()}" : "")}";
            FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedMsg.Station, "CPDLC", $"/data2/{SentMessages}//WU/{encodedMessage}");
            _ = HoppiesInterface.SendMessage(req);

            addSentCPDLCMessage(new SentCPDLCMessage()
            {
                Station = selectedMsg.Station,
                MessageId = SentMessages,
                ReplyMessageId = SentMessages
            });

            addCPDLCMessage(new CPDLCMessage()
            {
                State = MessageState.Uplink,
                Station = selectedMsg.Station,
                Content = encodedMessage.Replace("@", "").Replace("\n", ", "),
                TimeReceived = DateTime.UtcNow,
                MessageId = SentMessages,
                ReplyMessageId = -1
            });

            selectedMsg.setMessageState(MessageState.Finished);
            Close();
        }

        private string CutStringAndAppendT(string input, int maxLength = 36)
        {
            if (input.Length <= maxLength) return input;

            string[] segments = input.Split(' ');
            string result = string.Empty;
            foreach (string segment in segments)
            {
                if ((result + " " + segment).Trim().Length > maxLength) break;
                if (result.Length > 0) result += " ";
                result += segment;
            }
            result = result.Trim();
            if (result.Length <= maxLength) result += " T";

            return result;
        }

        private void dd_freq_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void InitPlaceholders()
        {
            networkPilotFDR = GetFDRs.FirstOrDefault((FDR f) => f.Callsign == selectedMsg.Station);
            if (networkPilotFDR == null || !GetFDRs.Contains(networkPilotFDR))
            {
                Close();
                return;
            }

            var propertiesToCheck = new[] { "Callsign", "AircraftType", "DesAirport", "SID", "DepartureRunway", "Route", "CFLString", "AssignedSSRCode" };
            foreach (var property in propertiesToCheck)
            {
                var propInfo = networkPilotFDR.GetType().GetProperty(property);
                if (propInfo == null || propInfo.GetValue(networkPilotFDR) == null)
                {
                    Close();
                    return;
                }
            }

            Text = $"PDC {networkPilotFDR.Callsign}";

            string route = networkPilotFDR.Route;
            string[] routeSegments = route.Split(' ');
            if (routeSegments[0].Contains(networkPilotFDR.DepAirport) || routeSegments[0].Contains(networkPilotFDR.SID.Name)) route = route.Substring(route.IndexOf(' ') + 1);

            PDCElements = new Dictionary<string, string>()
            {
                { "PDC", $"PDC {DateTime.UtcNow.ToString("ddHHmm")}" },
                { "MetaInfo", $"{networkPilotFDR.Callsign} {networkPilotFDR.AircraftType} {networkPilotFDR.DepAirport} {networkPilotFDR.ETD.ToString("HHmm")}" },
                { "DestRoute", $"CLRD TO {networkPilotFDR.DesAirport} VIA" },
                { "SIDRwy", $"{networkPilotFDR.SID.Name} DEP RWY {networkPilotFDR.DepartureRunway.Name}" },
                { "Route", $"ROUTE: {CutStringAndAppendT(route)}" },
                { "InitAlt", $"CLIMB VIA SID TO: {(networkPilotFDR.CFLString != null && int.Parse(networkPilotFDR.CFLString) < 110 ? "A" : "FL")}{networkPilotFDR.CFLString.PadLeft(3, '0')}" },
                { "SqwkDeps", $"SQUAWK {Convert.ToString(networkPilotFDR.AssignedSSRCode, 8).PadLeft(4, '0')}" }
            };

            lbl_pdcHeader.Text = PDCElements["PDC"];
            lbl_metaInfo.Text = PDCElements["MetaInfo"];
            lbl_destRoute.Text = PDCElements["DestRoute"];
            lbl_sidRwy.Text = PDCElements["SIDRwy"];
            lbl_route.Text = PDCElements["Route"];
            lbl_initAlt.Text = PDCElements["InitAlt"];
            lbl_sqwkDeps.Text = PDCElements["SqwkDeps"];
        }

        private void LoadDepFreq()
        {
            List<string> freqs = new List<string>();

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
                dd_freq.Items.Add(freq);
            }
        }

        private void StyleComponent()
        {
            try
            {
                foreach (Control ctl in Controls)
                {
                    if (ctl is TextLabel)
                    {
                        ctl.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                        ctl.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
                    }
                }
                lbl_pdcHeader.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                lbl_pdcHeader.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
                lbl_metaInfo.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                lbl_metaInfo.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

                dd_freq.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
                dd_freq.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                dd_freq.FocusColor = Color.Cyan;

                btn_send.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
                btn_send.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            }
            catch (Exception ex)
            {
                errorHandler.AddError(ex.ToString());
            }
        }
    }
}
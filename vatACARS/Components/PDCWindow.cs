using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Tranceiver;
using static vatsys.FDP2;

namespace vatACARS.Components
{
    public partial class PDCWindow : BaseForm
    {
        private TelexMessage selectedMsg;
        private static Logger logger = new Logger("PDCWindow");
        private FDR networkPilotFDR;

        public PDCWindow()
        {
            try {
                InitializeComponent();
                selectedMsg = (TelexMessage)DispatchWindow.SelectedMessage;
                networkPilotFDR = GetFDRs.FirstOrDefault((FDR f) => f.Callsign == selectedMsg.Station);
                if(networkPilotFDR == null)
                {
                    Close();
                    return;
                }

                StyleComponent();
                InitPlaceholders();
            } catch (Exception e) {
                logger.Log(e.Message);
            }
        }

        private void StyleComponent()
        {
            Text = $"PDC {networkPilotFDR.Callsign}";

            foreach(Control ctl in Controls)
            {
                if(ctl is TextLabel)
                {
                    ctl.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
                    ctl.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
                }
            }

            btn_send.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_send.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
        }

        private void InitPlaceholders()
        {
            string route = networkPilotFDR.Route;
            string[] routeSegments = route.Split(' ');
            if (routeSegments[0].Contains(networkPilotFDR.DepAirport) || routeSegments[0].Contains(networkPilotFDR.SID.Name)) route = route.Substring(route.IndexOf(' ') + 1);
            
            lbl_pdcHeader.Text = $"PDC {DateTime.UtcNow.ToString("ddHHmm")}";
            lbl_metaInfo.Text = $"{networkPilotFDR.Callsign} {networkPilotFDR.AircraftType} {networkPilotFDR.DepAirport} {networkPilotFDR.ETD.ToString("HHmm")}";
            lbl_destRoute.Text = $"CLRD TO {networkPilotFDR.DesAirport} VIA";
            lbl_sidRwy.Text = $"{networkPilotFDR.SID.Name} DEP RWY {networkPilotFDR.DepartureRunway.Name}";
            lbl_route.Text = $"ROUTE: {CutStringAndAppendT(route)}";
            lbl_initAlt.Text = $"CLIMB VIA SID TO: {(int.Parse(networkPilotFDR.CFLString) < 110 ? "A" : "FL")}{networkPilotFDR.CFLString}";
            lbl_sqwkDeps.Text = $"SQUAWK {networkPilotFDR.AssignedSSRCode.ToString()}";
        }

        private string CutStringAndAppendT(string input, int maxLength = 48)
        {
            string[] segments = input.Split(' ');
            string result = string.Empty;
            foreach (string segment in segments)
            {
                if ((result + " " + segment).Trim().Length > maxLength)
                {
                    break;
                }
                if (result.Length > 0)
                {
                    result += " ";
                }
                result += segment;
            }
            result = result.Trim();
            if (result.Length <= maxLength)
            {
                result += " T";
            }
            return result;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string encodedMessage = $"PDC {DateTime.UtcNow.ToString("ddHHmm")}\n{lbl_metaInfo.Text}\n{lbl_destRoute.Text}\n{lbl_sidRwy.Text}\n{lbl_route.Text}\n{lbl_initAlt.Text}\n{lbl_sqwkDeps.Text}\nDEP FREQ: {tbx_depfreq.Text}\n{tbx_freetext.Text}";
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
                State = 2,
                Station = selectedMsg.Station,
                Content = encodedMessage.Replace("@", "").Replace("\n", ", "),
                TimeReceived = DateTime.Now,
                MessageId = SentMessages,
                ReplyMessageId = -1
            });

            selectedMsg.setMessageState(3);
            Close();
        }
    }
}

using System;
using System.Net.Http;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Transceiver;

namespace vatACARS.Components
{
    public partial class LogonConsentWindow : BaseForm
    {
        private static Logger logger = new Logger("LogonConsentWindow");
        private CPDLCMessage selectedMsg;

        public LogonConsentWindow()
        {
            InitializeComponent();
            selectedMsg = (CPDLCMessage)DispatchWindow.SelectedMessage;

            StyleComponent();
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            try
            {
                selectedMsg.Content = "LOGON ACCEPTED";
                selectedMsg.setMessageState(MessageState.Finished);
                addStation(new Station()
                {
                    Provider = 0,
                    Callsign = selectedMsg.Station
                });
                FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedMsg.Station, "CPDLC", $"/data2/{SentMessages}/{selectedMsg.MessageId}/N/LOGON ACCEPTED");
                _ = HoppiesInterface.SendMessage(req);
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
            }
            Close();
        }

        private void btn_unable_Click(object sender, EventArgs e)
        {
            try
            {
                selectedMsg.setMessageState(MessageState.Finished);
                FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedMsg.Station, "CPDLC", $"/data2/{SentMessages}/{selectedMsg.MessageId}/N/SERVICE UNAVAILABLE");
                _ = HoppiesInterface.SendMessage(req);
            }
            catch (Exception)
            {
                // womp womp
            }
            Close();
        }

        private void StyleComponent()
        {
            lbl_callsign.Text = selectedMsg.Station;
        }
    }
}
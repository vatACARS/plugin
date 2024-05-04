using System;
using System.Net.Http;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;

namespace vatACARS.Components
{
    public partial class LogonConsentWindow : BaseForm
    {
        private CPDLCMessage selectedMsg;

        public LogonConsentWindow()
        {
            InitializeComponent();
            selectedMsg = (CPDLCMessage)DispatchWindow.SelectedMessage;

            StyleComponent();
        }

        private void StyleComponent()
        {
            lbl_callsign.Text = selectedMsg.Station;
        }

        private void btn_accept_Click(object sender, System.EventArgs e)
        {
            try
            {
                selectedMsg.setMessageState(2);
                Tranceiver.addStation(new Station()
                {
                    Provider = 0,
                    Callsign = selectedMsg.Station
                });
                FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedMsg.Station, "CPDLC", $"/data2/{Tranceiver.SentMessages}/{selectedMsg.MessageId}/N/LOGON ACCEPTED");
                _ = HoppiesInterface.SendMessage(req);
            } catch(Exception) {
                // womp womp
            }
            Close();
        }

        private void btn_unable_Click(object sender, System.EventArgs e)
        {
            try
            {
                selectedMsg.setMessageState(2);
                FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedMsg.Station, "CPDLC", $"/data2/{Tranceiver.SentMessages}/{selectedMsg.MessageId}/N/UNABLE");
                _ = HoppiesInterface.SendMessage(req);
            } catch (Exception)
            {
                // womp womp
            }
            Close();
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Transceiver;

namespace vatACARS.Components
{
    public partial class DebugWindow : BaseForm
    {
        private static bool netchecks = Properties.Settings.Default.netChecks;
        private ErrorHandler errorHandler = ErrorHandler.GetInstance();

        public DebugWindow()
        {
            InitializeComponent();
            StyleComponent();
        }

        public static void SetChecks(bool value)
        {
            Logger logger = new Logger("vatACARS");
            if (netchecks != value)
            {
                netchecks = value;
                if (netchecks)
                {
                    Properties.Settings.Default.netChecks = true;
                    logger.Log("NetChecks ON.");
                }
                else
                {
                    Properties.Settings.Default.netChecks = false;
                    logger.Log("NetChecks OFF.");
                }
                Properties.Settings.Default.Save();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (dd_type.Text == "CPDLCMessage")
                {
                    addCPDLCMessage(new CPDLCMessage()
                    {
                        State = (MessageState)int.Parse(dd_state.Text),
                        Station = tbx_station.Text,
                        Content = tbx_content.Text,
                        TimeReceived = DateTime.UtcNow
                    });
                }
                else if (dd_type.Text == "TelexMessage")
                {
                    addTelexMessage(new TelexMessage()
                    {
                        State = (MessageState)int.Parse(dd_state.Text),
                        Station = tbx_station.Text,
                        Content = tbx_content.Text,
                        TimeReceived = DateTime.UtcNow
                    });
                }
                else
                {
                    errorHandler.AddError("Message Type not selected.");
                }
            }
            catch (Exception ex)
            {
                errorHandler.AddError(ex.ToString());
            }
        }

        private void btn_netchecks_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Properties.Settings.Default.netChecks = !Properties.Settings.Default.netChecks;
            btn_netchecks.Text = Properties.Settings.Default.netChecks ? "\u2713" : "";
            btn_netchecks.Invalidate();
            SetChecks(Properties.Settings.Default.netChecks);
            Properties.Settings.Default.Save();
        }

        private void btn_screate_Click(object sender, EventArgs e)
        {
            try
            {
                addStation(new Transceiver.Station()
                {
                    Callsign = tbx_stationc.Text,
                    Provider = int.Parse(dd_prov.Text)
                });
            }
            catch (Exception ex)
            {
                errorHandler.AddError(ex.ToString());
            }
        }

        private void DebugWindow_Shown(object sender, EventArgs e)
        {
            btn_netchecks.Text = Properties.Settings.Default.netChecks ? "\u2713" : "";
            btn_netchecks.Invalidate();
            SetChecks(Properties.Settings.Default.netChecks);
        }

        private void StyleComponent()
        {
            lbl_messagecreate.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_messagecreate.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            lbl_callsign.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_callsign.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            lbl_content.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_content.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            lbl_state.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_state.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            lbl_type.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_type.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            lbl_stationcreate.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_stationcreate.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            lbl_stationc.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_stationc.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            lbl_prov.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_prov.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            lbl_netchecks.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_netchecks.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            dd_state.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            dd_state.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            dd_state.FocusColor = Color.Cyan;

            dd_type.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            dd_type.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            dd_type.FocusColor = Color.Cyan;

            dd_prov.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            dd_prov.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            dd_prov.FocusColor = Color.Cyan;

            btn_add.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_add.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);

            btn_screate.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_screate.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
        }
    }
}
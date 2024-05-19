using System;
using System.Net.Http;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Tranceiver;

namespace vatACARS.Components
{
    public partial class PDCWindow : BaseForm
    {
        private TelexMessage selectedMsg;
        private static Logger logger = new Logger("PDCWindow");
        public PDCWindow()
        {
            InitializeComponent();
            selectedMsg = (TelexMessage)DispatchWindow.SelectedMessage;
            StyleComponent();
        }

        private void StyleComponent()
        {
            btn_callsign.Text = selectedMsg.Station;


            lbl_PDC.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_PDC.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_dep.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_dep.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_route.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_route.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_freq.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_freq.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_ssr.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_ssr.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_type.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_type.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_callsign.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_callsign.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_runway.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_runway.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_clrto.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_clrto.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_climb.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_climb.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_via.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_via.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_free.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_free.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

            btn_time.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_time.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_callsign.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_callsign.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_type.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_type.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_dep.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_dep.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_route.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_route.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_freq.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_freq.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_ssr.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_ssr.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_runway.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_runway.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_dest.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_dest.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_climb.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_climb.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_via.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_via.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_free.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_free.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_send.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_send.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
        }

        private void lvw_messages_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btn_standby_Click(object sender, EventArgs e) { }

        private void btn_reply_Click(object sender, EventArgs e) { }

        private void scr_messageSelector_Scroll(object sender, EventArgs e) { }

        // There has got to be a better way to do this, will look into it
        private void btn_suspend_Click(object sender, EventArgs e) { }

        private void btn_level_Click(object sender, EventArgs e) { }

        private void btn_route_Click(object sender, EventArgs e) { }

        private void btn_transfr_Click(object sender, EventArgs e) { }

        private void btn_cross_Click(object sender, EventArgs e) { }

        private void btn_enq_Click(object sender, EventArgs e) { }

        private void btn_surv_Click(object sender, EventArgs e) { }

        private void btn_expect_Click(object sender, EventArgs e) { }

        private void btn_blk_Click(object sender, EventArgs e) { }

        private void btn_wx_Click(object sender, EventArgs e) { }

        private void btn_comm_Click(object sender, EventArgs e) { }

        private void btn_speed_Click(object sender, EventArgs e) { }

        private void btn_cfm_Click(object sender, EventArgs e) { }

        private void btn_misc_Click(object sender, EventArgs e) { }

        private void btn_emerg_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_def_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void genericButton3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void genericButton8_Click(object sender, EventArgs e)
        {

        }

        private void PDCWindow_Load(object sender, EventArgs e)
        {

        }
    }
}

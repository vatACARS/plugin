using System;
using vatsys;

namespace vatACARS.Components
{
    public partial class PDCWindow : BaseForm
    {
        public PDCWindow()
        {
            InitializeComponent();
            StyleComponent();
        }

        private void StyleComponent()
        {
            lbl_PDC.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_PDC.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_clrto.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_clrto.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_via.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_via.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_dep.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_dep.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_route.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_route.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_clbvia.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_clbvia.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_depfreq.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_depfreq.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_ssr.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_ssr.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_acname.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_acname.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

            btn_time.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_time.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_callsign.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_callsign.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_type.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_type.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_depicao.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_depicao.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_eobt.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_eobt.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_desicao.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_desicao.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_dep.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_dep.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_route.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_route.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_alt.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_alt.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_freq.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_freq.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_ssr.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_ssr.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_freetxt.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            btn_freetxt.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            btn_send.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_escape.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_send.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_escape.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
        }

        private void lvw_messages_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btn_standby_Click(object sender, EventArgs e) { }

        private void btn_reply_Click(object sender, EventArgs e) { }

        private async void scr_messageSelector_Scroll(object sender, EventArgs e) { }

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
    }
}

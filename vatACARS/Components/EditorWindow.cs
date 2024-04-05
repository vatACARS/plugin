using System;
using vatsys;

namespace vatACARS.Components
{
    public partial class EditorWindow : BaseForm
    {
        public EditorWindow()
        {
            InitializeComponent();
            StyleComponent();
        }

        private void StyleComponent()
        {
            lbl_receivedMsgs.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_messages.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lvw_messageSelector.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_messageSelector.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lvw_freetextInput.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_freetextInput.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);

            btn_send.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_send.ForeColor = Colours.GetColour(Colours.Identities.CPDLCUplink);

            scr_messageSelector.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messageSelector.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
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
    }
}

using vatsys;

namespace vatACARS.Components
{
    public partial class DispatchWindow : BaseForm
    {
        public DispatchWindow()
        {
            InitializeComponent();
            StyleComponent();
        }

        private void StyleComponent()
        {
            lbl_receivedMsgs.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lvw_messages.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            scr_cpdlc.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_cpdlc.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
        }

        private void lvw_messages_SelectedIndexChanged(object sender, System.EventArgs e) { }

        private void btn_standby_Click(object sender, System.EventArgs e) { }

        private void btn_reply_Click(object sender, System.EventArgs e) { }
    }
}

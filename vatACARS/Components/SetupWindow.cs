using System;
using vatsys;

namespace vatACARS
{
    public partial class SetupWindow : BaseForm
    {
        public SetupWindow()
        {
            InitializeComponent();
            StyleComponent();
        }

        private void StyleComponent()
        {
            lbl_stationCode.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_enablehop.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_hoplogon.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            lbl_stationCode.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_enablehop.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            lbl_hoplogon.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);

            btn_save.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_connect.ForeColor = Colours.GetColour(Colours.Identities.NonJurisdictionIQL);
            btn_save.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
            btn_connect.BackColor = Colours.GetColour(Colours.Identities.CPDLCSendButton);
        }

        private void SetupWindow_Shown(object sender, EventArgs e)
        {

        }

        private void lbl_logonCode_Click(object sender, EventArgs e)
        {

        }
    }
}

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
            lbl_acarsServer.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);
            lbl_logonCode.ForeColor = Colours.GetColour(Colours.Identities.NonInteractiveText);

            tbx_stationCode.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            tbx_acarsServer.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            tbx_logonCode.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            tbx_stationCode.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            tbx_acarsServer.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            tbx_logonCode.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
        }

        private void SetupWindow_Shown(object sender, EventArgs e)
        {

        }
    }
}

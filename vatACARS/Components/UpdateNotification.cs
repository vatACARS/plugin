using vatACARS.Helpers;
using vatsys;

namespace vatACARS.Components
{
    public partial class UpdateNotification : BaseForm
    {
        public UpdateNotification()
        {
            InitializeComponent();
            StyleComponent();

            lbl_version.Text = string.Format("Version {0}", VersionChecker.updateInfo.version.ToString());
            lbl_changes.Text = string.Join("\n", VersionChecker.updateInfo.Changes.ToArray());
        }

        public void StyleComponent()
        {
            lbl_preamble.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            lbl_changes.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
        }
    }
}
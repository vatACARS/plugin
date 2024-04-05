using System.ComponentModel.Composition;
using vatsys;
using vatsys.Plugin;

namespace vatACARS
{
    [Export(typeof(IPlugin))]
    public class vatACARS : IPlugin
    {
        public string Name { get => "vatACARS"; }

        private CustomToolStripMenuItem acarsWindowMenu;

        public vatACARS()
        {
            // Startup code here.
            return;
        }

        public void OnFDRUpdate(FDP2.FDR updated) { }

        public void OnRadarTrackUpdate(RDP.RadarTrack updated) { }
    }
}

using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using vatACARS.Components;
using vatACARS.Helpers;
using vatACARS.Lib;
using vatACARS.Util;
using vatsys;
using vatsys.Plugin;
using static vatACARS.Helpers.Tranceiver;
using static vatsys.FDP2;

namespace vatACARS
{
    public static class AppData
    {
        public static Version CurrentVersion { get; } = new Version(1, 0, 0);
    }

    [Export(typeof(IPlugin))]
    public class vatACARS : IPlugin
    {
        public string Name { get => "vatACARS"; }

        Logger logger = new Logger("vatACARS");

        private static SetupWindow setupWindow;
        private static DispatchWindow dispatchWindow = new DispatchWindow();

        private CustomToolStripMenuItem setupWindowMenu;
        private CustomToolStripMenuItem dispatchWindowMenu;

        // The following function runs on vatSys startup. Init code should be contained here.
        public vatACARS()
        {
            string fp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (!Directory.Exists($"{fp}\\vatACARS")) Directory.CreateDirectory($"{fp}\\vatACARS");
            if (!Directory.Exists($"{fp}\\vatACARS\\audio")) Directory.CreateDirectory($"{fp}\\vatACARS\\audio");
            if (!Directory.Exists($"{fp}\\vatACARS\\data")) Directory.CreateDirectory($"{fp}\\vatACARS\\data");
            if (File.Exists($"{fp}\\vatACARS\\vatACARS.log")) File.Delete($"{fp}\\vatACARS\\vatACARS.log");
            
            logger.Log("Starting...");
            Start();

            return;
        }

        private async void Start()
        {
            logger.Log("Running updater client...");
            HttpClientUtils.SetBaseUrl("https://api.vatacars.com");
            await UpdateClient.CheckDependencies();

            logger.Log("Populating vatSys toolstrip...");
            // Add our buttons to the vatSys toolstrip
            setupWindowMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Custom, new ToolStripMenuItem("Setup"));
            setupWindowMenu.CustomCategoryName = "ACARS";
            setupWindowMenu.Item.Click += SetupWindowMenu_Click;
            MMI.AddCustomMenuItem(setupWindowMenu);

            dispatchWindowMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Custom, new ToolStripMenuItem("Dispatch Interface"));
            dispatchWindowMenu.CustomCategoryName = "ACARS";
            dispatchWindowMenu.Item.Click += DispatchWindowMenu_Click;
            MMI.AddCustomMenuItem(dispatchWindowMenu);

            // Update Checking
            logger.Log("Starting version checker...");
            VersionChecker.StartListening();


            XMLReader.MakeUplinks();
            JSONReader.MakeQuickFillItems();


            logger.Log("Started successfully.");
        }

        private void SetupWindowMenu_Click(object sender, EventArgs e)
        {
            MMI.InvokeOnGUI(delegate () { DoShowSetupWindow(); });
        }

        private static void DoShowSetupWindow()
        {
            if (setupWindow == null || setupWindow.IsDisposed)
                setupWindow = new SetupWindow();
            else if (setupWindow.Visible)
                return;

            setupWindow.Show(Form.ActiveForm);
        }

        private void DispatchWindowMenu_Click(object sender, EventArgs e)
        {
            MMI.InvokeOnGUI(delegate () { DoShowDispatchWindow(); });
        }

        private static void DoShowDispatchWindow()
        {
            if (dispatchWindow == null || dispatchWindow.IsDisposed)
                dispatchWindow = new DispatchWindow();
            else if (dispatchWindow.Visible)
                return;

            dispatchWindow.Show(Form.ActiveForm);
        }

        public void OnFDRUpdate(FDP2.FDR updated) { }

        public void OnRadarTrackUpdate(RDP.RadarTrack updated) { }

        public CustomLabelItem GetCustomLabelItem(string itemType, Track track, FDR flightDataRecord, RDP.RadarTrack radarTrack)
        {
            Station[] stations = getAllStations();
            Station cStation = stations.FirstOrDefault(station => station.Callsign == flightDataRecord.Callsign);

            TelexMessage[] telexMessages = getAllTelexMessages();
            CPDLCMessage[] CPDLCMessages = getAllCPDLCMessages();
            IMessageData telexDownlink;
            IMessageData combinedDownlink;

            telexDownlink = telexMessages.Cast<IMessageData>().FirstOrDefault(message => message.State == 0 && message.Station == flightDataRecord.Callsign);
            combinedDownlink = telexMessages.Cast<IMessageData>().Concat(CPDLCMessages.Cast<IMessageData>()).FirstOrDefault(message => message.State == 0 && message.Station == flightDataRecord.Callsign);


            switch (itemType)
            {
                case "LABEL_ITEM_CPDLCGROUND":
                    if (telexDownlink == null) return null;

                    if (telexDownlink.Content.StartsWith("REQUEST PREDEP CLEARANCE")) return new CustomLabelItem() { Text = "@ PDC" };
                    return new CustomLabelItem() { Text = "@ REQ" };

                case "LABEL_ITEM_CPDLCAIR":
                    if (cStation == null) return null;
                    if (!MMI.IsMySectorConcerned(flightDataRecord)) return new CustomLabelItem()
                    {
                        Text = "@ HANDOVER",
                        ForeColourIdentity = Colours.Identities.Warning,
                        Border = BorderFlags.Bottom,
                        BorderColourIdentity = Colours.Identities.Warning
                    };

                    int level = radarTrack == null ? flightDataRecord.PRL / 100 : radarTrack.CorrectedAltitude / 100;
                    if (level < 245)
                    {
                        return new CustomLabelItem()
                        {
                            Text = "@ TOO LOW",
                            ForeColourIdentity = Colours.Identities.Warning,
                            OnMouseClick = CPDLCLabelClick
                        };
                    }

                    if (combinedDownlink != null) return new CustomLabelItem()
                    {
                        Text = "@ REQ",
                        ForeColourIdentity = Colours.Identities.CPDLCDownlink,
                        OnMouseClick = CPDLCLabelClick
                    };

                    return new CustomLabelItem()
                    {
                        Text = "@",
                        ForeColourIdentity = Colours.Identities.StaticTools,
                        OnMouseClick = CPDLCLabelClick
                    };
                default:
                    return null;
            }
        }

        private void CPDLCLabelClick(CustomLabelItemMouseClickEventArgs e)
        {
            DispatchWindow.SelectedMessage = new CPDLCMessage()
            {
                State = 0,
                Station = e.Track.GetFDR().Callsign,
                Content = "(no message received)",
                TimeReceived = DateTime.UtcNow
            };

            EditorWindow window = new EditorWindow();
            window.Show(Form.ActiveForm);

            e.Handled = true;
        }

        private void HandoffLabelClick(CustomLabelItemMouseClickEventArgs e)
        {
            FDR fdr = e.Track.GetFDR();
            SectorsVolumes.Volume volume = null;
            SectorsVolumes.Sector nextSector = null;
            FDR.ExtractedRoute.Segment segment = (from s in fdr.ParsedRoute.ToList() where s.Type == FDR.ExtractedRoute.Segment.SegmentTypes.ZPOINT && fdr.ControllingSector != SectorsVolumes.FindSector((SectorsVolumes.Volume)s.Tag) select s).FirstOrDefault((FDR.ExtractedRoute.Segment s) => s.ETO > DateTime.UtcNow);
            if (segment != null) volume = (SectorsVolumes.Volume)segment.Tag;
            if (volume != null) nextSector = SectorsVolumes.FindSector(volume);

            if(nextSector != null && !Network.GetOnlineATCs.Any((NetworkATC a) => a.Callsign == nextSector.Callsign && a.ValidATC && a.ATIS.Any((string atisLine) => new Regex(@"CPDLC [A-Z]{4}").Matches(atisLine).Count > 0 || new Regex(@"CPDLC LOGON [A-Z]{4}").Matches(atisLine).Count > 0)))
            {
                SectorsVolumes.Sector sector = null;
                foreach (SectorsVolumes.Sector s in SectorsVolumes.SectorGroupings.Keys)
                {
                    if (Network.GetOnlineATCs.Any((NetworkATC a) => a.Callsign == s.Callsign && a.ValidATC && a.ATIS.Any((string atisLine) => new Regex(@"CPDLC [A-Z]{4}").Matches(atisLine).Count > 0 || new Regex(@"CPDLC LOGON [A-Z]{4}").Matches(atisLine).Count > 0)) && s.SubSectors.Contains(nextSector) && (sector == null || sector.SubSectors.Count > s.SubSectors.Count)) sector = s;
                }
                if (sector != null) nextSector = sector;
            }

            e.Handled = true;
        }

        public CustomColour SelectASDTrackColour(Track track)
        {
            FDR fdr = track.GetFDR(true);
            if(!MMI.IsMySectorConcerned(fdr)) return null;

            Station[] stations = getAllStations();
            Station cStation = stations.FirstOrDefault(station => station.Callsign == fdr.Callsign);
            if (cStation == null) return null;

            CPDLCMessage[] CPDLCMessages = getAllCPDLCMessages();
            TelexMessage[] telexMessages = getAllTelexMessages();
            IMessageData downlink = telexMessages.Cast<IMessageData>().Concat(CPDLCMessages.Cast<IMessageData>()).FirstOrDefault(message => message.State == 0 && message.Station == cStation.Callsign);
            if(downlink == null) return null;

            // We have an active downlink from this aircraft
            return new CustomColour(41, 178, 144);
        }

        public CustomColour SelectGroundTrackColour(Track track)
        {
            FDR fdr = track.GetFDR(true);

            TelexMessage[] telexMessages = getAllTelexMessages();
            TelexMessage downlink = telexMessages.FirstOrDefault(message => message.State == 0 && message.Station == fdr.Callsign);
            if (downlink == null) return null;

            // We have an active downlink for this aircraft
            return new CustomColour(41, 178, 144);
        }
    }
}

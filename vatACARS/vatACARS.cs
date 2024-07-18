using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public static Version CurrentVersion { get; } = new Version(1, 0, 3);
    }

    [Export(typeof(IPlugin))]
    public class vatACARS : IPlugin
    {
        private static DispatchWindow dispatchWindow = new DispatchWindow();
        private static HandoffSelector HandoffSelector;
        private static SetupWindow setupWindow;
        private readonly Logger logger = new Logger("vatACARS");
        private CustomToolStripMenuItem dispatchWindowMenu;
        private CustomToolStripMenuItem setupWindowMenu;

        // The following function runs on vatSys startup. Init code should be contained here.
        public vatACARS()
        {
            string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vatACARS");

            // Create directories only if they don't exist
            Directory.CreateDirectory(dataPath);
            Directory.CreateDirectory(Path.Combine(dataPath, "audio"));
            Directory.CreateDirectory(Path.Combine(dataPath, "data"));
            if (File.Exists($"{dataPath}\\vatACARS.log")) File.Delete($"{dataPath}\\vatACARS.log");

            logger.Log("Starting...");
            _ = Start();
        }

        public string Name => "vatACARS";

        public CustomLabelItem GetCustomLabelItem(string itemType, Track track, FDR flightDataRecord, RDP.RadarTrack radarTrack)
        {
            try
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

                        if (telexDownlink.Content.StartsWith("REQUEST PREDEP CLEARANCE")) return new CustomLabelItem()
                        {
                            Text = "@ PDC",
                            ForeColourIdentity = Colours.Identities.CPDLCDownlink,
                            OnMouseClick = PDCLabelClick
                        };
                        return new CustomLabelItem()
                        {
                            Text = "@ REQ",
                            ForeColourIdentity = Colours.Identities.CPDLCDownlink,
                            OnMouseClick = CPDLCLabelClick
                        };

                    case "LABEL_ITEM_CPDLCAIR":
                        if (cStation == null) return null;
                        if (!MMI.IsMySectorConcerned(flightDataRecord)) return new CustomLabelItem()
                        {
                            Text = "@ HANDOVER",
                            ForeColourIdentity = Colours.Identities.Warning,
                            Border = BorderFlags.Bottom,
                            BorderColourIdentity = Colours.Identities.Warning,
                            OnMouseClick = HandoffLabelClick
                        };

                        /*if (radarTrack == null) return null;
                        int level = radarTrack == null ? flightDataRecord.PRL / 100 : radarTrack.CorrectedAltitude / 100;
                        if (level < 245)
                        {
                            return new CustomLabelItem()
                            {
                                Text = "@ TOO LOW",
                                ForeColourIdentity = Colours.Identities.Warning,
                                OnMouseClick = HandoffLabelClick
                            };
                        }*/

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
            catch (Exception e)
            {
                logger.Log($"Error in GetCustomLabelItem: {e.Message}");
                return null;
            }
        }

        public void OnFDRUpdate(FDP2.FDR updated)
        { }

        public void OnRadarTrackUpdate(RDP.RadarTrack updated)
        { }

        public CustomColour SelectASDTrackColour(Track track)
        {
            // Something in this is broken.

            if (track == null) return null;
            if (track.Type != Track.TrackTypes.TRACK_TYPE_RADAR) return null;
            FDR fdr = ((RDP.RadarTrack)track.SourceData).CoupledFDR;
            if (fdr == null) return null;
            if (fdr.ControllingSector == null || fdr.HandoffSector == null) return null;

            if (!MMI.IsMySectorConcerned(fdr)) return null; // something here is fucked

            Station[] stations = getAllStations();
            Station cStation = stations.FirstOrDefault(station => station.Callsign == fdr.Callsign);
            if (cStation == null) return null;

            CPDLCMessage[] CPDLCMessages = getAllCPDLCMessages();
            TelexMessage[] telexMessages = getAllTelexMessages();
            IMessageData downlink = telexMessages.Cast<IMessageData>().Concat(CPDLCMessages.Cast<IMessageData>()).FirstOrDefault(message => message.State == 0 && message.Station == cStation.Callsign);
            if (downlink == null) return null;

            // We have an active downlink from this aircraft
            return new CustomColour(41, 178, 144);
        }

        public CustomColour SelectGroundTrackColour(Track track)
        {
            try
            {
                FDR fdr = track.GetFDR(true);
                if (!GetFDRs.Contains(fdr) || fdr == null) return null;

                TelexMessage[] telexMessages = getAllTelexMessages();
                TelexMessage downlink = telexMessages.FirstOrDefault(message => message.State == 0 && message.Station == fdr.Callsign);
                if (downlink == null) return null;

                // We have an active downlink for this aircraft
                return new CustomColour(41, 178, 144);
            }
            catch (Exception e)
            {
                logger.Log($"Error in SelectGroundTrackColour: {e.Message}");
                return null;
            }
        }

        private static void DoShowDispatchWindow()
        {
            if (dispatchWindow == null || dispatchWindow.IsDisposed)
            {
                dispatchWindow = new DispatchWindow();
            }
            else if (dispatchWindow.Visible)
            {
                return;
            }

            dispatchWindow.Show(Form.ActiveForm);
        }

        private static void DoShowSetupWindow()
        {
            if (setupWindow == null || setupWindow.IsDisposed)
            {
                setupWindow = new SetupWindow();
            }
            else if (setupWindow.Visible)
            {
                return;
            }

            setupWindow.Show(Form.ActiveForm);
        }

        private void CPDLCLabelClick(CustomLabelItemMouseClickEventArgs e)
        {
            FDR fdr = e.Track.GetFDR();
            if (fdr == null)
            {
                ErrorHandler.GetInstance().AddError($"Selected aircraft has not submitted a flight plan.");
                return;
            }
            DispatchWindow.SelectedMessage = new CPDLCMessage()
            {
                State = 0,
                Station = fdr.Callsign,
                Content = "(no message received)",
                TimeReceived = DateTime.UtcNow
            };

            EditorWindow window = new EditorWindow();
            window.Show(Form.ActiveForm);

            e.Handled = true;
        }

        private void DispatchWindowMenu_Click(object sender, EventArgs e)
        {
            MMI.InvokeOnGUI(() => DoShowDispatchWindow());
        }

        private void HandoffLabelClick(CustomLabelItemMouseClickEventArgs e)
        {
            DispatchWindow.SelectedStation = getAllStations().FirstOrDefault(station => station.Callsign == e.Track.GetFDR().Callsign);
            HandoffSelector = new HandoffSelector();
            HandoffSelector.Show(Form.ActiveForm);

            e.Handled = true;
        }

        private void PDCLabelClick(CustomLabelItemMouseClickEventArgs e)
        {
            FDR fdr = e.Track.GetFDR();
            if(fdr == null)
            {
                ErrorHandler.GetInstance().AddError($"Selected aircraft has not submitted a flight plan.");
                return;
            }
            TelexMessage telexMessage = getAllTelexMessages().FirstOrDefault(message => message.State == 0 && message.Station == fdr.Callsign && message.Content.StartsWith("REQUEST PREDEP"));
            DispatchWindow.SelectedMessage = telexMessage;

            PDCWindow window = new PDCWindow();
            window.Show(Form.ActiveForm);
        }

        private void SetupWindowMenu_Click(object sender, EventArgs e)
        {
            MMI.InvokeOnGUI(() => DoShowSetupWindow());
        }

        private async Task Start()
        {
            try
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
                LabelsXMLPatcher.Patch();

                ErrorHandler.Initialize(SynchronizationContext.Current); // Init error handler on ui thread

                _ = Task.Run(() => CrashChecker.CheckForCrashes());

                logger.Log("Started successfully.");
            }
            catch (Exception e)
            {
                logger.Log($"Error in Start: {e.Message}");
            }
        }
    }
}
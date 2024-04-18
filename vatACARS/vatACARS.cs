using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows.Forms;
using vatACARS.Components;
using vatACARS.Helpers;
using vatACARS.Lib;
using vatACARS.Util;
using vatsys;
using vatsys.Plugin;

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
        private static DispatchWindow dispatchWindow;
        private static EditorWindow editorWindow;
        private static PDCWindow PDCWindow;

        private CustomToolStripMenuItem setupWindowMenu;
        private CustomToolStripMenuItem dispatchWindowMenu;
        private CustomToolStripMenuItem editorWindowMenu;
        private CustomToolStripMenuItem PDCWindowMenu;

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

            // Temporary for testing
            PDCWindowMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Custom, new ToolStripMenuItem("[DEV] PDC Editor"));
            PDCWindowMenu.CustomCategoryName = "ACARS";
            PDCWindowMenu.Item.Click += PDCWindowMenu_Click;
            MMI.AddCustomMenuItem(PDCWindowMenu);

            // Update Checking
            logger.Log("Starting version checker...");
            VersionChecker.StartListening();

            logger.Log("Starting Hoppies integration...");
            // Start Hoppies Polling
            HoppiesInterface.StartListening();

            Uplinks.MakeUplinks();

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

            setupWindow.Show();
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

        private void PDCWindowMenu_Click(object sender, EventArgs e)
        {
            MMI.InvokeOnGUI(delegate () { DoShowPDCWindow(); });
        }

        private static void DoShowPDCWindow()
        {
            if (PDCWindow == null || PDCWindow.IsDisposed)
                PDCWindow = new PDCWindow();
            else if (PDCWindow.Visible)
                return;
                      
            PDCWindow.Show(Form.ActiveForm);
        }

        public void OnFDRUpdate(FDP2.FDR updated) { }

        public void OnRadarTrackUpdate(RDP.RadarTrack updated) { }
    }
}

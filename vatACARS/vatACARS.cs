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
    }


}

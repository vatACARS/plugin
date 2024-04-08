using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using vatACARS.Components;
using vatACARS.Helpers;
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
            editorWindowMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Custom, new ToolStripMenuItem("[DEV] Response Builder"));
            editorWindowMenu.CustomCategoryName = "ACARS";
            editorWindowMenu.Item.Click += EditorWindowMenu_Click;
            MMI.AddCustomMenuItem(editorWindowMenu);

            // Temporary for testing
            PDCWindowMenu = new CustomToolStripMenuItem(CustomToolStripMenuItemWindowType.Main, CustomToolStripMenuItemCategory.Custom, new ToolStripMenuItem("[DEV] PDC Editor"));
            PDCWindowMenu.CustomCategoryName = "ACARS";
            PDCWindowMenu.Item.Click += PDCWindowMenu_Click;
            MMI.AddCustomMenuItem(PDCWindowMenu);
            
            // Update Checking
            HttpClientUtils.SetBaseUrl("https://api.vatacars.com");
            VersionChecker.CheckForUpdates();

            return;
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

            dispatchWindow.Show();
        }

        // Temporary for testing
        private void EditorWindowMenu_Click(object sender, EventArgs e)
        {
            MMI.InvokeOnGUI(delegate () { DoShowEditorWindow(); });
        }

        private static void DoShowEditorWindow()
        {
            if (editorWindow == null || editorWindow.IsDisposed)
                editorWindow = new EditorWindow();
            else if (editorWindow.Visible)
                return;

            editorWindow.Show();
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

            PDCWindow.ShowDialog();
        }

        public void OnFDRUpdate(FDP2.FDR updated) { }

        public void OnRadarTrackUpdate(RDP.RadarTrack updated) { }
    }
}

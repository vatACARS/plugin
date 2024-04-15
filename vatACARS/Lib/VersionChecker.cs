/*
 * VersionChecker.cs
 * Nuff said..
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using vatACARS.Components;
using vatACARS.Util;

namespace vatACARS.Helpers
{
    public static class VersionChecker
    {
        private static Timer timer;
        private static Logger logger = new Logger("VersionChecker");
        public static VersionInfo updateInfo;

        public static void StartListening()
        {
            logger.Log("Service started.");
            timer = new Timer();
            timer.Elapsed += CheckTimer;
            timer.AutoReset = true; // Keep the timer running
            timer.Interval = 1.8e06;
            timer.Enabled = true;

            CheckLatestVersion();
        }

        private static void CheckTimer(object sender, ElapsedEventArgs e)
        {
            CheckLatestVersion();
        }

        private static async Task CheckLatestVersion()
        {
            logger.Log("Checking for updates...");
            using (var httpClient = new HttpClient())
            {
                string liveVersion = await httpClient.GetStringTaskAsync("/versions/latest");
                updateInfo = JsonConvert.DeserializeObject<VersionInfo>(liveVersion);
                Version currentVersion = AppData.CurrentVersion;
                logger.Log($"Current Version: {currentVersion} | Latest Version: {updateInfo.version}");
                if (updateInfo.version > currentVersion)
                {
                    logger.Log("Update found, stopping the timer & showing update dialog.");
                    timer.Enabled = false;
                    UpdateNotification updateNotification = new UpdateNotification();
                    updateNotification.ShowDialog();
                }
            }
            logger.Log("Finished.");
        }
    }

    public class VersionInfo
    {
        public Version version { get; set; }
        public List<string> Changes { get; set; }
        public DateTime ReleaseDateTime { get; set; }

    }
}

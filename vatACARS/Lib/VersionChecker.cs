/*
 * VersionChecker.cs
 * Nuff said..
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using vatACARS.Components;
using vatACARS.Util;

namespace vatACARS.Helpers
{
    public static class VersionChecker
    {
        public static UpdateInfo updateInfo;

        public static async Task CheckForUpdates()
        {
            using (var httpClient = new HttpClient())
            {
                string liveVersion = await httpClient.DownloadStringTaskAsync("/versions/latest");
                updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(liveVersion);
                Version currentVersion = AppData.CurrentVersion;
                //MessageBox.Show("An new version of vatACARS is available.\n\nVersion " + updateInfo.version.ToString() + "\n" + string.Join("\n", updateInfo.Changes.ToArray()), "vatACARS Update Checker", MessageBoxButtons.OK);
                if(updateInfo.version > currentVersion)
                {
                    UpdateNotification updateNotification = new UpdateNotification();
                    updateNotification.ShowDialog();
                }
            }
        }
    }

    public class UpdateInfo
    {
        public Version version { get; set; }
        public List<string> Changes { get; set; }
        public DateTime ReleaseDateTime { get; set; }

    }
}

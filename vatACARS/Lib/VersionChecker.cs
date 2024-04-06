/*
 * VersionChecker.cs
 * Nuff said..
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using vatACARS.Util;

namespace vatACARS.Helpers
{
    internal class VersionChecker
    {
        static async Task CheckForUpdates()
        {
            using (var httpClient = new HttpClient())
            {
                string liveVersion = await httpClient.DownloadStringTaskAsync("/versions/latest");
                UpdateInfo updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(liveVersion);
                Version currentVersion = AppData.CurrentVersion;
                if(updateInfo.version > currentVersion)
                {

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

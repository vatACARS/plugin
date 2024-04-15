using System.Net.Http;
using System.Threading.Tasks;
using vatACARS.Util;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace vatACARS.Lib
{
    public static class UpdateClient
    {
        private static Logger logger = new Logger("UpdateClient");
        private static string dirPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\vatACARS";

        public static async Task CheckDependencies()
        {
            List<DependencyInfo> dependenciesRequired = new List<DependencyInfo>();
            using (var httpClient = new HttpClient())
            {
                logger.Log("Checking the repository...");
                string dependencies = await httpClient.GetStringTaskAsync("/repository");
                DependencyInfo[] dependencyList = JsonConvert.DeserializeObject<DependencyInfo[]>(dependencies);
                foreach( DependencyInfo dependency in dependencyList )
                {
                    if (!File.Exists($"{dirPath}\\{dependency.subFolder}\\{dependency.fileName}")) {
                        logger.Log($"{dependency.subFolder}\\{dependency.fileName} does not exist locally, adding to update list...");
                        dependenciesRequired.Add(dependency);
                    } else
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead($"{dirPath}\\{dependency.subFolder}\\{dependency.fileName}"))
                            {
                                if (!BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant().SequenceEqual(dependency.hash))
                                {
                                    logger.Log($"{dependency.subFolder}\\{dependency.fileName} md5 checksum mismatch, adding to update list...");
                                    dependenciesRequired.Add(dependency);
                                }
                                else logger.Log($"{dependency.subFolder}\\{dependency.fileName} is up to date, skipping...");
                            }
                        }
                    }
                }
            }

            logger.Log("Starting update...");
            using(var httpClient = new HttpClient())
            {
                foreach (DependencyInfo dependency in dependenciesRequired)
                {
                    logger.Log($"Downloading {dependency.fileName}...");
                    File.Delete($"{dirPath}\\{dependency.subFolder}\\{dependency.fileName}");
                    await httpClient.DownloadFileTaskAsync($"/files/{dependency.fileName}", $"{dirPath}\\{dependency.subFolder}\\{dependency.fileName}", "https://cdn.vatacars.com");
                }
            }
            logger.Log("Finished update!");
        }
    }

    public class DependencyInfo
    {
        public string fileName;
        public string subFolder;
        public string hash;
    }
}

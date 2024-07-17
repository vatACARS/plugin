using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace vatACARS.Util
{
    internal class CrashChecker
    {
        private static ErrorHandler errorHandler = ErrorHandler.GetInstance();

        private static HashSet<string> LoadProcessedEventIds()
        {
            string eventIdsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vatACARS", "crashEvents.map");
            HashSet<string> processedEventIds = new HashSet<string>();

            if (File.Exists(eventIdsFilePath))
            {
                string[] lines = File.ReadAllLines(eventIdsFilePath);
                foreach (string line in lines) processedEventIds.Add(line);
            }

            return processedEventIds;
        }

        private static void SaveProcessedEventIds(List<string> newEventIds)
        {
            string eventIdsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vatACARS", "crashEvents.map");
            using (StreamWriter writer = new StreamWriter(eventIdsFilePath, true)) foreach (string eventId in newEventIds) writer.WriteLine(eventId);
        }

        public async static void CheckForCrashes()
        {
            try
            {
                HashSet<string> processedEventIds = LoadProcessedEventIds();
                List<string> newEventIds = new List<string>();

                EventLog eventLog = new EventLog("Application");
                EventLogEntryCollection entries = eventLog.Entries;

                using (HttpClient client = new HttpClient())
                {
                    foreach (EventLogEntry entry in entries)
                    {
                        if (entry.Message.Contains("vatACARS") && entry.EntryType == EventLogEntryType.Error && entry.TimeGenerated >= DateTime.Now.AddDays(-7))
                        {
                            string uniqueIdentifier = $"vatACARS_plugin_{entry.TimeGenerated.Ticks.ToString().Substring(0, 11)}";
                            if (!processedEventIds.Contains(uniqueIdentifier))
                            {
                                if (Properties.Settings.Default.vatACARSToken == null)
                                {
                                    errorHandler.AddError($"We detected a crash caused by vatACARS from your previous session. Your vatACARS token is not set so a report was not sent.");
                                }
                                else
                                {
                                    await client.PostStringTaskAsync("/reporting", new FormUrlEncodedContent(new Dictionary<string, string>
                                    {
                                        {"token", Properties.Settings.Default.vatACARSToken},
                                        {"source", "plugin"},
                                        {"data", JsonConvert.SerializeObject(new { ident = uniqueIdentifier, raw = entry.Message })}
                                    }), "https://api-dev.vatacars.com");
                                    errorHandler.AddError($"We detected a crash caused by vatACARS from your previous session. A crash report has been generated and sent.\n\nError reference: {uniqueIdentifier}");
                                }

                                newEventIds.Add(uniqueIdentifier);
                            }
                        }
                    }
                }

                SaveProcessedEventIds(newEventIds);
            }
            catch (Exception ex)
            {
                errorHandler.AddError("An error occurred while checking for crashes: " + ex.Message);
            }
        }
    }
}

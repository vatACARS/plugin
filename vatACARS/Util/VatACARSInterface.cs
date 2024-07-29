/*
 * VatACARSInterface.cs
 * Handles the connection to vatACARS ACARS server.
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Timers;
using vatACARS.Helpers;
using vatsys;

namespace vatACARS.Util
{
    public static class VatACARSInterface
    {
        private static HttpClient client = new HttpClient();
        private static Logger logger = new Logger("vatACARSServer");
        private static Timer timer;
        public static StationInformation[] stationsOnline { get; private set; }

        public static async void StartListening()
        {
            logger.Log("Service started.");
            timer = new Timer();
            timer.Elapsed += HeartbeatTimer;
            timer.AutoReset = true; // Keep the timer running
            timer.Interval = 90_000;
            timer.Enabled = true;

            string OnlineStationsResponse = await client.GetStringTaskAsync("/atsu/online");
            StationInformation[] StationsResponseDecoded = JsonConvert.DeserializeObject<StationInformation[]>(OnlineStationsResponse);

            stationsOnline = StationsResponseDecoded;
        }

        public static void StopListening()
        {
            timer.Stop();
            timer.Dispose();
            logger.Log("Service stopped.");
        }

        private static async void HeartbeatTimer(object sender, ElapsedEventArgs e)
        {
            if (!Network.IsConnected || !Network.IsValidATC || Transceiver.ClientInformation.Callsign == null || MMI.SectorsControlled.Count < 1)
            {
                StopListening();
                HoppiesInterface.StopListening();
                Transceiver.connected = false;
                ErrorHandler.GetInstance().AddError("You have been disconnected from vatACARS.");
                if (vatACARS.setupWindow != null)
                {
                    vatACARS.setupWindow.Close();
                }
                return;
            }

            try
            {
                string LogonResponse = await client.PostStringTaskAsync("/atsu/heartbeat", new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"station", Transceiver.ClientInformation.Callsign},
                {"token", Properties.Settings.Default.vatACARSToken},
                {"sectors", JsonConvert.SerializeObject(MMI.SectorsControlled.Where(sector => !MMI.SectorsControlled.SelectMany(s => s.SubSectors).Contains(sector)).ToList().Select(sector => new { name = sector.Name, callsign = sector.Callsign, frequency = sector.Frequency }).ToArray()) },
                {"approxLoc", JsonConvert.SerializeObject(new { latitude = MMI.PrimePosition.DefaultCenter.Latitude, longitude = MMI.PrimePosition.DefaultCenter.Longitude })}
            }));

            APIResponse ResponseDecoded = JsonConvert.DeserializeObject<APIResponse>(LogonResponse);
            if (!ResponseDecoded.Success) ErrorHandler.GetInstance().AddError($"Heartbeat to vatACARS failed: {ResponseDecoded.Message}");

            string OnlineStationsResponse = await client.GetStringTaskAsync("/atsu/online");
            StationInformation[] StationsResponseDecoded = JsonConvert.DeserializeObject<StationInformation[]>(OnlineStationsResponse);

            stationsOnline = StationsResponseDecoded;

            logger.Log("Heartbeat successful.");

            }
            catch (Exception ex) // THIS FIXES CRASH FOR NOW (josh its to do with http client stuff)
            {
                logger.Log($"Crash Saved: {ex.ToString()}");
            }
        }
    }
}
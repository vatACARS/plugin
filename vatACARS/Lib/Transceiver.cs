/*
 * Transceiver.cs
 * Handles communication between vatACARS and ACARS servers.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vatACARS.Components;
using vatACARS.Util;
using vatsys;
using static vatsys.FDP2;

namespace vatACARS.Helpers
{
    public static class Transceiver
    {
        public static bool connected = false;
        public static int SentMessages = 1;
        private static List<string> AgreeMessages = new List<string>() { "WILCO", "ROGER", "AFFIRM" };
        private static List<string> ClosingMessages = new List<string>() { "WILCO", "UNABLE", "ROGER", "STANDBY", "AFFIRM", "NEGATIVE" };
        private static List<CPDLCMessage> CPDLCMessages = new List<CPDLCMessage>();
        private static Logger logger = new Logger("Transceiver");
        private static List<SentCPDLCMessage> SentCPDLCMessages = new List<SentCPDLCMessage>();
        private static List<Station> Stations = new List<Station>();
        private static List<TelexMessage> TelexMessages = new List<TelexMessage>();

        public static event EventHandler<CPDLCMessage> CPDLCMessageReceived;

        public static event EventHandler<IMessageData> MessageUpdated;

        public static event EventHandler<Station> StationAdded;

        public static event EventHandler<Station> StationRemoved;

        public static event EventHandler<TelexMessage> TelexMessageReceived;

        public interface IMessageData
        {
            string Content { get; set; }
            MessageState State { get; set; }
            string Station { get; set; }
            DateTime TimeReceived { get; set; }
        }

        public static void addCPDLCMessage(CPDLCMessage message)
        {
            try
            {
                AudioInterface.playSound("incomingMessage");

                if (message.Content == "LOGOFF") getAllStations().FirstOrDefault(station => station.Callsign == message.Station).removeStation();

                if (message.ReplyMessageId != -1 && ClosingMessages.Contains(message.Content))
                {
                    SentCPDLCMessage sentCPDLCMessage = SentCPDLCMessages.FirstOrDefault(msg => msg.MessageId == message.ReplyMessageId);
                    CPDLCMessage originalMessage = null;
                    if (sentCPDLCMessage != null) originalMessage = CPDLCMessages.FirstOrDefault(msg => msg.MessageId == sentCPDLCMessage.ReplyMessageId);

                    if (originalMessage == null) CPDLCMessages.Add(message);
                    else
                    {
                        FDR fdr = GetFDRs.FirstOrDefault(f => f.Callsign == message.Station);
                        if (fdr != null && originalMessage.Content.Contains("PDC")) fdr.PDCAcknowledged = true;
                        if (AgreeMessages.Contains(message.Content)) useMessageIntent(sentCPDLCMessage);
                        SentCPDLCMessages.Remove(sentCPDLCMessage);
                        originalMessage.Response = message.Content;
                        if (message.Content != "STANDBY") originalMessage.setMessageState(MessageState.Finished);
                    }
                }
                else
                {
                    CPDLCMessages.Add(message);
                    Station station = Stations.FirstOrDefault(s => s.Callsign == message.Station);
                    if (station != null) // cpdlc may not have come from connected station (PDC's)
                    {
                        station.History.Add(message);
                    }
                    else
                    {
                        logger.Log($"Station {message.Station} is not connected.");
                    }
                    if (message.ResponseType == "N") message.setMessageState(MessageState.DownlinkResponseNotRequired);
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Oops: {ex.ToString()}");
            }

            CPDLCMessageReceived?.Invoke(null, message);
        }

        public static void addSentCPDLCMessage(SentCPDLCMessage message)
        {
            SentCPDLCMessages.Add(message);
        }

        public static void addStation(Station station)
        {
            if (!Stations.Any(s => s.Callsign == station.Callsign))
            {
                Stations.Add(station);
                StationAdded?.Invoke(null, station);
            }
            else
            {
                ErrorHandler.GetInstance().AddError($"Station Already Exists: {station.Callsign}");
            }
        }

        public static void addTelexMessage(TelexMessage message)
        {
            AudioInterface.playSound("incomingMessage");
            TelexMessages.Add(message);
            Station station = Stations.FirstOrDefault(s => s.Callsign == message.Station);
            if (station != null) // telex may not have come from connected station.
            {
                station.History.Add(message);
            }
            else
            {
                logger.Log($"Station {message.Station} is not connected.");
            }
            TelexMessageReceived?.Invoke(null, message);
        }

        public static CPDLCMessage[] getAllCPDLCMessages()
        {
            return CPDLCMessages.ToArray();
        }

        public static Station[] getAllStations()
        {
            return Stations.ToArray();
        }

        public static TelexMessage[] getAllTelexMessages()
        {
            return TelexMessages.ToArray();
        }

        public static void removeStation(this Station station)
        {
            Stations.Remove(station);
            StationRemoved?.Invoke(null, station);
        }

        public static async void setMessageState(this IMessageData message, MessageState state)
        {
            message.State = state;

            MessageUpdated.Invoke(null, message);

            if (state == MessageState.Finished)
            {
                await Task.Delay(TimeSpan.FromSeconds(Properties.Settings.Default.finishedMessageTimeout));
                message.removeMessage();
            }
        }

        public static void useMessageIntent(SentCPDLCMessage message)
        {
            FDR fdr = GetFDRs.FirstOrDefault(f => f.Callsign == message.Station);
            if (fdr == null) return;
            Intent intent = message.Intent;
            if (intent.Type == "SPEED")
            {
                if (intent.Value == "CLRSPD") FDP2.SetLabelData(fdr, string.Empty);
                if (intent.Value == "PRSSPD")
                {
                    string s = "S" + fdr.TAS.ToString();
                    FDP2.SetLabelData(fdr, s);
                }
                if (intent.Value == "CSR") FDP2.SetLabelData(fdr, "CSR");
                FDP2.SetLabelData(fdr, intent.Value);
            }
            if (intent.Type == "LEVEL" || intent.Type == "BLOCK")
            {
                var values = intent.Type == "LEVEL" ? new[] { intent.Value } : intent.Value.Split(',');
                if (intent.Type == "LEVEL")
                {
                    string part = values[0].Trim();
                    int levelValue;
                    if (part.StartsWith("FL"))
                    {
                        part = part.Replace("FL", "");
                        if (int.TryParse(part, out levelValue))
                        {
                            FDP2.SetCFL(fdr, levelValue.ToString());
                        }
                    }
                    else if (part.StartsWith("A"))
                    {
                        part = part.Replace("A", "");
                        if (int.TryParse(part, out levelValue))
                        {
                            FDP2.SetCFL(fdr, levelValue.ToString());
                        }
                    }
                }
                else
                {
                    int firstValue = 0;
                    int secondValue = 0;
                    bool firstValueSet = false;
                    bool secondValueSet = false;
                    foreach (var value in values)
                    {
                        string part = value.Trim();
                        int blockValue;
                        if (part.StartsWith("FL"))
                        {
                            part = part.Replace("FL", "");
                            if (int.TryParse(part, out blockValue))
                            {
                                blockValue *= 100; // cus vatsys is silly
                                if (!firstValueSet)
                                {
                                    firstValue = blockValue;
                                    firstValueSet = true;
                                }
                                else
                                {
                                    secondValue = blockValue;
                                    secondValueSet = true;
                                }
                            }
                        }
                        else if (part.StartsWith("A"))
                        {
                            part = part.Replace("A", "");
                            if (int.TryParse(part, out blockValue))
                            {
                                if (!firstValueSet)
                                {
                                    firstValue = blockValue;
                                    firstValueSet = true;
                                }
                                else
                                {
                                    secondValue = blockValue;
                                    secondValueSet = true;
                                }
                            }
                        }
                        if (firstValueSet && secondValueSet)
                        {
                            int lowerValue = Math.Min(firstValue, secondValue);
                            int upperValue = Math.Max(firstValue, secondValue);
                            FDP2.SetCFL(fdr, lowerValue, upperValue, false);
                            break;
                        }
                    }
                }
            }
            else
            {
                logger.Log("Invalid Intent Type");
            }
        }

        private static void removeMessage(this IMessageData message)
        {
            if (message is CPDLCMessage) CPDLCMessages.Remove((CPDLCMessage)message);
            if (message is TelexMessage) TelexMessages.Remove((TelexMessage)message);
        }

        public static class ClientInformation
        {
            public static string Callsign = "";
            public static string LogonCode = ""; // Hoppies logon code
        }

        public class CPDLCMessage : IMessageData
        {
            /* State:
             * 0 = Downlink
             * 1 = Stby/Defer
             * 2 = Uplink
             * 3 = DownlinkRespNotReqd
             * 4 = Finished
             * 5 = ADS-C
             */
            public int MessageId;
            public int ReplyMessageId;
            public string ResponseType;
            public string Content { get; set; }
            public List<CPDLCMessage> History { get; set; } = new List<CPDLCMessage>();
            public string Response { get; set; } = "";
            public MessageState State { get; set; }
            public string Station { get; set; }
            public List<ResponseItem> SuspendedResponses { get; set; } = new List<ResponseItem>();
            public DateTime TimeReceived { get; set; }
        }

        public class Intent
        {
            public string Type;
            public string Value;
        }

        public class SentCPDLCMessage
        {
            public int MessageId;
            public int ReplyMessageId;
            public string Station;
            public Intent Intent { get; set; }
        }

        public class Station
        {
            /* Provider:
             * 0 = Hoppies
             * 1 = vatACARS
             */
            public string Callsign;
            public int Provider;
            public List<IMessageData> History { get; set; } = new List<IMessageData>();
        }

        public class TelexMessage : IMessageData
        {
            /* State:
             * 0 = Downlink
             * 1 = Stby/Defer
             * 2 = Uplink
             * 3 = DownlinkRespNotReqd
             * 4 = Finished
             * 5 = ADS-C
             */
            public string Content { get; set; }
            public MessageState State { get; set; }
            public string Station { get; set; }
            public List<ResponseItem> SuspendedResponses { get; set; } = new List<ResponseItem>();
            public DateTime TimeReceived { get; set; }
        }
    }
}
/*
 * Tranceiver.cs
 * Handles communication between vatACARS and ACARS servers.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vatACARS.Util;

namespace vatACARS.Helpers
{
    public static class Tranceiver
    {
        public static int SentMessages = 1;
        public static bool connected = false;
        private static Logger logger = new Logger("Tranceiver");
        private static List<CPDLCMessage> CPDLCMessages = new List<CPDLCMessage>();
        private static List<SentCPDLCMessage> SentCPDLCMessages = new List<SentCPDLCMessage>();
        private static List<TelexMessage> TelexMessages = new List<TelexMessage>();
        private static List<Station> Stations = new List<Station>();
        private static List<string> ClosingMessages = new List<string>() { "WILCO", "UNABLE", "ROGER", "STANDBY", "AFFIRM", "NEGATIVE" };

        public static event EventHandler<TelexMessage> TelexMessageReceived;
        public static event EventHandler<CPDLCMessage> CPDLCMessageReceived;
        public static event EventHandler<Station> StationAdded;
        public static event EventHandler<Station> StationRemoved;
        public static event EventHandler<IMessageData> MessageUpdated;

        public static TelexMessage[] getAllTelexMessages()
        {
            return TelexMessages.ToArray();
        }

        public static void addTelexMessage(TelexMessage message)
        {
            logger.Log("TelexMessage successfully received.");
            AudioInterface.playSound("incomingMessage");
            TelexMessages.Add(message);
            TelexMessageReceived?.Invoke(null, message);
        }

        public static CPDLCMessage[] getAllCPDLCMessages()
        {
            return CPDLCMessages.ToArray();
        }

        public static void addCPDLCMessage(CPDLCMessage message)
        {
            try
            {
                logger.Log("CPDLCMessage successfully received.");
                AudioInterface.playSound("incomingMessage");

                if (message.ReplyMessageId != -1 && ClosingMessages.Contains(message.Content))
                {
                    logger.Log($"Closing message: '{message.Content}' - ReplyID: {message.ReplyMessageId}");
                    SentCPDLCMessage sentCPDLCMessage = SentCPDLCMessages.FirstOrDefault(msg => msg.MessageId == message.ReplyMessageId);
                    CPDLCMessage originalMessage = null;
                    if (sentCPDLCMessage != null) originalMessage = CPDLCMessages.FirstOrDefault(msg => msg.MessageId == sentCPDLCMessage.ReplyMessageId);

                    if (originalMessage == null)
                    {
                        logger.Log("Original message not found.");
                        CPDLCMessages.Add(message);
                    }
                    else
                    {
                        logger.Log($"Found message: '{originalMessage.Content}' - ID: {originalMessage.MessageId}");
                        SentCPDLCMessages.Remove(sentCPDLCMessage);
                        originalMessage.Response = message.Content;
                        if(message.Content != "STANDBY") originalMessage.setMessageState(3); // Done
                    }
                }
                else
                {
                    CPDLCMessages.Add(message);
                    if(message.ResponseType == "N") message.setMessageState(3);
                }
            } catch (Exception ex)
            {
                logger.Log($"Oops: {ex.ToString()}");
            }

            CPDLCMessageReceived?.Invoke(null, message);
        }

        public static void addSentCPDLCMessage(SentCPDLCMessage message)
        {
            SentCPDLCMessages.Add(message);
        }

        public static async void setMessageState(this IMessageData message, int state)
        {
            message.State = state;
            try
            {
                MessageUpdated.Invoke(null, message); // TODO: Fix this
            } catch (Exception ex)
            {
                logger.Log($"Oops: {ex.ToString()}");
            }

            if (state == 3)
            {
                await Task.Delay(TimeSpan.FromSeconds(Properties.Settings.Default.finishedMessageTimeout));
                message.removeMessage();
            }

            MessageUpdated.Invoke(null, message);
        }

        private static void removeMessage(this IMessageData message)
        {
            if (message is CPDLCMessage) CPDLCMessages.Remove((CPDLCMessage)message);
            if (message is TelexMessage) TelexMessages.Remove((TelexMessage)message);
        }

        public static void removeStation(this Station station)
        {
            Stations.Remove(station);
            StationRemoved?.Invoke(null, station);
        }


        public static Station[] getAllStations()
        {
            return Stations.ToArray();
        }

        public static void addStation(Station station)
        {
            Stations.Add(station);
            StationAdded?.Invoke(null, station);
        }


        public static class ClientInformation
        {
            public static string LogonCode = ""; // Hoppies logon code
            public static string Callsign = "";

        }

        public interface IMessageData
        {
            int State { get; set; }
            DateTime TimeReceived { get; set; }
            string Station { get; set; }
            string Content { get; set; }
        }

        public class CPDLCMessage : IMessageData
        {
            /* State:
             * 0 = Downlink
             * 1 = Stby/Defer
             * 2 = Uplink
             * 3 = Finished
             */
            public int State { get; set; }
            public DateTime TimeReceived { get; set; }
            public string Station { get; set; }
            public int MessageId;
            public int ReplyMessageId;
            public string ResponseType;
            public string Content { get; set; }
            public string Response { get; set; } = "";
        }

        public class SentCPDLCMessage
        {
            public string Station;
            public int MessageId;
            public int ReplyMessageId;
        }

        public class TelexMessage : IMessageData
        {
            /* State:
             * 0 = Downlink
             * 1 = Stby/Defer
             * 2 = Uplink
             * 3 = Finished
             */
            public int State { get; set; }
            public DateTime TimeReceived { get; set; }
            public string Station { get; set; }
            public string Content { get; set; }
        }

        public class Station
        {
            /* Provider:
             * 0 = Hoppies
             * 1 = vatACARS
             */
            public int Provider;
            public string Callsign;
        }
    }
}

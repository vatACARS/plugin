/*
 * Tranceiver.cs
 * Handles communication between vatACARS and ACARS servers.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vatACARS.Util;

namespace vatACARS.Helpers
{
    public static class Tranceiver
    {
        public static int SentMessages = 1;
        private static Logger logger = new Logger("Tranceiver");
        private static List<CPDLCMessage> CPDLCMessages = new List<CPDLCMessage>();
        private static List<TelexMessage> TelexMessages = new List<TelexMessage>();
        private static List<Station> Stations = new List<Station>();

        public static event EventHandler<TelexMessage> TelexMessageReceived;
        public static event EventHandler<CPDLCMessage> CPDLCMessageReceived;
        public static event EventHandler<Station> StationAdded;

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
            logger.Log("CPDLCMessage successfully received.");
            AudioInterface.playSound("incomingMessage");
            CPDLCMessages.Add(message);
            CPDLCMessageReceived?.Invoke(null, message);
        }

        public static async void setMessageState(this IMessageData message, int state)
        {
            message.State = state;

            if (state == 3)
            {
                await Task.Delay(TimeSpan.FromSeconds(120));
                message.removeMessage();
            }
        }

        private static void removeMessage(this IMessageData message)
        {
            if (message is CPDLCMessage) CPDLCMessages.Remove((CPDLCMessage)message);
            if (message is TelexMessage) TelexMessages.Remove((TelexMessage)message);
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
            public string Content;
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
            public string Content;
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

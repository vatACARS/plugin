/*
 * Tranceiver.cs
 * Handles communication between vatACARS and ACARS servers.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using vatACARS.Util;
using vatsys;

namespace vatACARS.Helpers
{
    public static class Tranceiver
    {
        public static int SentMessages = 1;
        private static Logger logger = new Logger("Tranceiver");
        private static List<CPDLCMessage> CPDLCMessages = new List<CPDLCMessage>();
        private static List<TelexMessage> TelexMessages = new List<TelexMessage>();
        private static List<Station> Stations = new List<Station>();

        public static TelexMessage[] getAllTelexMessages()
        {
            return TelexMessages.ToArray();
        }

        public static void addTelexMessage(TelexMessage message)
        {
            logger.Log("TelexMessage successfully received.");
            TelexMessages.Add(message);
        }

        private static bool Connected = false;

        public static bool IsConnected()
        {
            return Connected;
        }

        public static void TryConnect(bool value)
        {
            //FIX THIS PLEASE
        }

        public static void SetConnected(bool value)
        {
            //RUN TRY CONNECT BEFORE LETTING CON NECT

            if (Connected != value)
            {
                Connected = value;
                if (Connected)
                {
                    logger.Log("Connection established.");
                }
                else
                {
                    logger.Log("Connection lost.");
                }
            }
        }

        public static CPDLCMessage[] getAllCPDLCMessages()
        {
            return CPDLCMessages.ToArray();
        }

        public static void addCPDLCMessage(CPDLCMessage message)
        {
            logger.Log("CPDLCMessage successfully received.");
            CPDLCMessages.Add(message);
        }

        public static async void setMessageState(this IMessageData message, int state)
        {
            message.State = state;

            if (state == 2)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                if (message.State == 2) message.State = 3;
                await Task.Delay(TimeSpan.FromSeconds(120));
                if (message.State == 3)
                {
                    message.removeMessage();
                }
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

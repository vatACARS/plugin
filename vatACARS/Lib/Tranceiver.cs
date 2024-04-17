/*
 * Tranceiver.cs
 * Handles communication between vatACARS and ACARS servers.
 */

using System;
using System.Collections.Generic;
using vatACARS.Util;

namespace vatACARS.Helpers
{
    public static class Tranceiver
    {
        private static Logger logger = new Logger("Tranceiver");
        private static List<CPDLCMessage> StoredMessages = new List<CPDLCMessage>();

        public static CPDLCMessage[] getAllCPDLCMessages()
        {
            return StoredMessages.ToArray();
        }
        
        public static void addCPDLCMessage(CPDLCMessage message)
        {
            logger.Log("CPDLCMessage successfully received.");
            StoredMessages.Add(message);
        }

        public static void SetCPDLCMessageState(this CPDLCMessage message, int state)
        {
            message.State = state;
        }
    }

    public static class ClientInformation
    {
        public static string LogonCode = "TqL6XbjhexpHgKPdH"; // Hoppies logon code
        public static string Callsign = "YBCS";

    }

    public class CPDLCMessage
    {
        /* State:
         * 0 = Downlink
         * 1 = Uplink
         * 2 = Ack
         * 3 = Finished
         */
        public int State;
        public DateTime TimeReceived;
        public string Station;
        public string Text;
    }
}

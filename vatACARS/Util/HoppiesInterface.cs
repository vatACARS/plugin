/*
 * HoppiesInterface.cs
 * Handles the connection to Hoppies ACARS Server
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using vatACARS.Helpers;

namespace vatACARS.Util
{
    public static class HoppiesInterface
    {
        private static Timer timer;
        private static Random random = new Random();
        private static Logger logger = new Logger("Hoppies");
        private static HttpClient client = new HttpClient();
        private static readonly Regex hoppieParse = new Regex(@"{(.*?)}"); // easyCPDLC
        private static readonly Regex cpdlcHeaderParse = new Regex(@"(\/\s*)\w*"); // easyCPDLC
        private static readonly Regex cpdlcUnitParse = new Regex(@"_@([\w]*)@_"); // easyCPDLC

        public static void StartListening()
        {
            logger.Log("Service started.");
            timer = new Timer();
            timer.Elapsed += PollTimer;
            timer.AutoReset = true; // Keep the timer running
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        // Set a random interval between 45 and 75 seconds for polling requests as per Hoppies guidelines
        private static void SetRandomInterval()
        {
            int intervalMilliseconds = random.Next(45000, 75001); // 45 to 75 seconds
            timer.Interval = intervalMilliseconds;
        }

        private static async void PollTimer(object sender, ElapsedEventArgs e)
        {
            SetRandomInterval();
            var rawMessages = await PollMessages();
            if (rawMessages == "OK")
            {
                logger.Log("No new messages.");
                return;
            }

            if (rawMessages.StartsWith("ERROR"))
            {
                logger.Log($"Hoppies error: {rawMessages}");
                return;
            }

            var responses = hoppieParse.Matches(rawMessages);
            List<CPDLCMessageReponse> newMessages = new List<CPDLCMessageReponse>();

            logger.Log($"Received {responses.Count} messages.");
            if (responses.Count > 0)
            {
                AudioInterface.playSound("incomingMessage");
                foreach (Match response in responses)
                {
                    string[] rawMessage = response.Groups[1].Value.Replace("}", "").Split('{');
                    string station = rawMessage[0].Split(' ')[0];
                    string type = rawMessage[0].Split(' ')[1];

                    for (int i = 0; i < rawMessage.Length; i++)
                    {
                        if (i > 0 && rawMessage[i].Length > 2)
                        {
                            if (rawMessage[1].StartsWith("/DATA2/"))
                            {
                                var parsedMessage = parseCPDLCMessage(rawMessage[1], station);
                                logger.Log($"CPDLC: {station} | ({parsedMessage.MessageType}) {parsedMessage.PacketData}");
                                newMessages.Add(parsedMessage);
                                break;
                            } else
                            {
                                logger.Log($"TELEX: {station} | {rawMessage[1]}");
                                newMessages.Add(new CPDLCMessageReponse()
                                {
                                    Station = station,
                                    MessageType = "TELEX",
                                    PacketData = rawMessage[1]
                                });
                                break;
                            }
                        }
                    }
                }
            } else
            {
            }

            foreach(var message in newMessages)
            {
                Tranceiver.addCPDLCMessage(new CPDLCMessage()
                {
                    State = 0,
                    Station = message.Station,
                    Text = message.PacketData.ToString(),
                    TimeReceived = DateTime.Now
                });
            }
        }

        private static async Task<string> PollMessages()
        {
            logger.Log("Polling for new messages...");
            var pollResponse = await SendMessage(ConstructMessage(ClientInformation.Callsign, "poll", null));
            logger.Log("Polling cycle completed.");

            return pollResponse.ToUpper().Trim();
        }

        public static FormUrlEncodedContent ConstructMessage(string Recipient, string MessageType, string PacketData)
        {
            CPDLCMessageRequest msg = new CPDLCMessageRequest();
            msg.LogonCode = ClientInformation.LogonCode;
            msg.Callsign = ClientInformation.Callsign;
            msg.Recipient = Recipient;
            msg.MessageType = MessageType;
            msg.PacketData = PacketData;

            string[] msgSplit;
            if (msg.PacketData != null)
            {
                msgSplit = msg.PacketData.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            }
            else msgSplit = new string[] { "(no message data)" };
            logger.Log($"Constructed message: {msg.Callsign} -> {msg.Recipient} ({msg.MessageType}): {string.Join(" | ", msgSplit)}");

            return msg.MakeCPDLCMessageRequest();
        }

        public static async Task<string> SendMessage(FormUrlEncodedContent request)
        {
            return await client.PostStringTaskAsync("/acars/system/connect.html", request, "http://www.hoppie.nl");
        }

        private static CPDLCMessageReponse parseCPDLCMessage(string rawMessage, string station)
        {
            CPDLCMessageReponse msg = new CPDLCMessageReponse();
            msg.Station = station;
            var headerData = cpdlcHeaderParse.Matches(rawMessage);
            msg.MessageType = headerData[0].Value.Trim('/');
            msg.PacketData = rawMessage.Split(new string[] { headerData[3].Value.Trim('/') + "/" }, StringSplitOptions.None)[1];

            return msg;
        }
    }

    public class CPDLCMessageRequest
    {
        public string LogonCode;
        public string Callsign;
        public string Recipient;
        public string MessageType;
        public string PacketData;

        public FormUrlEncodedContent MakeCPDLCMessageRequest() {
            Dictionary<string, string> MessageData = new Dictionary<string, string> {
                {"logon", LogonCode},
                {"from", Callsign},
                {"to", Recipient},
                {"type", MessageType},
                {"packet", PacketData}
            };

            return new FormUrlEncodedContent(MessageData);
        }
    }

    public class CPDLCMessageReponse
    {
        public string Station;
        public string MessageType;
        public string PacketData;
    }
}

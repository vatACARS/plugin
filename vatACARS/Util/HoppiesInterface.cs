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
using static vatACARS.Helpers.Tranceiver;


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
                //Tranceiver.SetConnected(false); //NEEDS TO UPDATE THE SETUP WINDOW CONNECTION STATUS
                return;
            }

            var responses = hoppieParse.Matches(rawMessages);
            List<CPDLCMessage> CPDLCMessages = new List<CPDLCMessage>();
            List<TelexMessage> telexMessages = new List<TelexMessage>();

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
                                CPDLCMessage parsedMessage = parseCPDLCMessage(rawMessage[1], station);
                                logger.Log($"CPDLC: {station} | (M:{parsedMessage.MessageId} / R:{(parsedMessage.ReplyMessageId != -1 ? parsedMessage.ReplyMessageId.ToString() : "X")}) [{parsedMessage.ResponseType}] {parsedMessage.Content}");
                                CPDLCMessages.Add(parsedMessage);
                                break;
                            } else
                            {
                                logger.Log($"TELEX: {station} | {rawMessage[1]}");
                                telexMessages.Add(new TelexMessage()
                                {
                                    State = 0,
                                    Station = station,
                                    TimeReceived = DateTime.Now,
                                    Content = rawMessage[1]
                                });
                                break;
                            }
                        }
                    }
                }
            }

            foreach (var message in telexMessages) Tranceiver.addTelexMessage(message);
            foreach (var message in CPDLCMessages) Tranceiver.addCPDLCMessage(message);
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
            Tranceiver.SentMessages++;
            return await client.PostStringTaskAsync("/acars/system/connect.html", request, "http://www.hoppie.nl");
        }

        private static CPDLCMessage parseCPDLCMessage(string rawMessage, string station)
        {
            string dataPortion = rawMessage.Substring(rawMessage.IndexOf('/') + 1);
            string[] fields = dataPortion.Split('/');

            CPDLCMessage msg;

            try
            {
                msg = new CPDLCMessage()
                {
                    State = 0,
                    TimeReceived = DateTime.Now,
                    Station = station,
                    MessageId = int.Parse(fields[1]),
                    ReplyMessageId = fields[2] != "" ? int.Parse(fields[2]) : -1,
                    ResponseType = fields[3],
                    Content = fields[4]
                };
            } catch (FormatException ex)
            {
                // Somebody forged a CPDLCMessage format that was invalid
                logger.Log($"CPDLCMessage from {station} was invalid! Might have been intentional forgery. {ex.Message}");
                msg = new CPDLCMessage();
            }

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

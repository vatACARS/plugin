/*
 * HoppiesInterface.cs
 * Handles the connection to Hoppies ACARS Server
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using static vatACARS.Helpers.Transceiver;

namespace vatACARS.Util
{
    public static class HoppiesInterface
    {
        private static readonly Regex hoppieParse = new Regex(@"{(.*?)}", RegexOptions.Singleline);
        private static HttpClient client = new HttpClient();
        private static bool discardedFirstRequest = false;
        private static ErrorHandler errorHandler = ErrorHandler.GetInstance();
        private static Logger logger = new Logger("Hoppies");
        private static Random random = new Random();
        private static Timer timer;

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
                msgSplit = msg.PacketData.Split(new string[] { "\n" }, StringSplitOptions.None);
            }
            else msgSplit = new string[] { "(no message data)" };
            logger.Log($"Constructed message: {msg.Callsign} -> {msg.Recipient} ({msg.MessageType}): {string.Join("\\", msgSplit)}");

            return msg.MakeCPDLCMessageRequest();
        }

        public static async Task<string> SendMessage(FormUrlEncodedContent request, bool incrementSentMessages = true)
        {
            if (incrementSentMessages) SentMessages++;
            try
            {
                return await client.PostStringTaskAsync("/acars/system/connect.html", request, "http://www.hoppie.nl");
            }
            catch (Exception e)
            {
                errorHandler.AddError(e.ToString());
                return "ERROR";
            }
        }

        public static void StartListening()
        {
            logger.Log("Service started.");
            timer = new Timer();
            timer.Elapsed += PollTimer;
            timer.AutoReset = true; // Keep the timer running
            timer.Interval = 50;
            timer.Enabled = true;
        }

        public static void StopListening()
        {
            logger.Log("Service stopped.");
            timer.Stop();
            timer.Dispose();
        }

        private static string parseADSCMessage(string rawMessage)
        {
            string[] lines = rawMessage.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < lines.Length; i++)
            {
                sb.Append(lines[i].Trim());
                if (i < lines.Length) sb.Append(" ");
            }

            string content = sb.ToString();
            return content;
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
                    TimeReceived = DateTime.UtcNow,
                    Station = station,
                    MessageId = fields[1] != "" ? int.Parse(fields[1]) : -1,
                    ReplyMessageId = fields[2] != "" ? int.Parse(fields[2]) : -1,
                    ResponseType = fields[3],
                    Content = String.Join(", ", fields.Skip(4))
                };
            }
            catch (FormatException ex)
            {
                logger.Log($"CPDLCMessage from {station} was invalid! {ex.Message}");
                msg = new CPDLCMessage();
            }

            return msg;
        }

        private static async Task<string> PollMessages()
        {
            var pollResponse = await SendMessage(ConstructMessage(ClientInformation.Callsign, "poll", null), false);

            return pollResponse.ToUpper().Trim();
        }

        private static async void PollTimer(object sender, ElapsedEventArgs e)
        {
            SetRandomInterval();
            var rawMessages = await PollMessages();
            if (rawMessages == "OK")
            {
                if (!discardedFirstRequest) discardedFirstRequest = true;
                return;
            }

            if (rawMessages.StartsWith("ERROR"))
            {
                logger.Log($"Hoppies error: {rawMessages}");
                errorHandler.AddError(rawMessages);
                //connected = false;
                return;
            }

            if (!discardedFirstRequest)
            {
                discardedFirstRequest = true;
                return;
            }

            var responses = hoppieParse.Matches(rawMessages);
            List<CPDLCMessage> CPDLCMessages = new List<CPDLCMessage>();
            List<TelexMessage> telexMessages = new List<TelexMessage>();

            if (responses.Count > 0)
            {
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
                            }
                            else if (rawMessage[1].StartsWith("/DATA1/"))
                            {
                                string mContent = parseADSCMessage(rawMessage[1]);
                                logger.Log($"ADS-C: {station} | {mContent}");
                                telexMessages.Add(new TelexMessage()
                                {
                                    State = MessageState.ADSC,
                                    Station = station,
                                    TimeReceived = DateTime.UtcNow,
                                    Content = mContent
                                });
                            }
                            else
                            {
                                logger.Log($"TELEX: {station} | {rawMessage[1]}");
                                telexMessages.Add(new TelexMessage()
                                {
                                    State = 0,
                                    Station = station,
                                    TimeReceived = DateTime.UtcNow,
                                    Content = rawMessage[1]
                                });
                                break;
                            }
                        }
                    }
                }
            }

            foreach (var message in telexMessages) addTelexMessage(message);
            foreach (var message in CPDLCMessages) addCPDLCMessage(message);
        }

        // Set a random interval between 45 and 75 seconds for polling requests as per Hoppies guidelines
        private static void SetRandomInterval()
        {
            int intervalMilliseconds = random.Next(45000, 75001); // 45 to 75 seconds
            timer.Interval = intervalMilliseconds;
        }
    }

    public class CPDLCMessageReponse
    {
        public string MessageType;
        public string PacketData;
        public string Station;
    }

    public class CPDLCMessageRequest
    {
        public string Callsign;
        public string LogonCode;
        public string MessageType;
        public string PacketData;
        public string Recipient;

        public FormUrlEncodedContent MakeCPDLCMessageRequest()
        {
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
}
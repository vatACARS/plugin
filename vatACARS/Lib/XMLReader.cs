using System;
using System.IO;
using System.Xml.Serialization;
using vatACARS.Util;

namespace vatACARS.Lib
{
    public static class XMLReader
    {
        public static XMLInterface uplinks;
        private static string dirPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\vatACARS";
        private static Logger logger = new Logger("XMLReader");

        public static void MakeUplinks()
        {
            try
            {
                logger.Log("Reading uplinks...");
                string uplinksRaw = File.ReadAllText($"{dirPath}\\data\\uplinks.xml");

                logger.Log("Deserializing...");
                using (TextReader reader = new StringReader(uplinksRaw))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XMLInterface));
                    uplinks = serializer.Deserialize(reader) as XMLInterface;
                }
                logger.Log("Done!");
            }
            catch (Exception ex)
            {
                logger.Log($"Something went wrong!\n{ex.ToString()}");
            }
        }
    }
}
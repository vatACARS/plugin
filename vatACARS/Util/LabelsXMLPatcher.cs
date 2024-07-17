using System;
using System.Xml;

namespace vatACARS.Util
{
    public static class LabelsXMLPatcher
    {
        private static string hardcodedFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\vatSys Files\\Profiles\\Australia\\Labels.xml"; // TODO: Dynamically yoink this somehow
        private static Logger logger = new Logger("LabelsXMLPatcher");

        public static void Patch()
        {
            logger.Log($"Patching {hardcodedFilePath}");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(hardcodedFilePath);

                XmlNode normalLabel = doc.SelectSingleNode("//Label[@Type='Normal']");
                if (normalLabel != null)
                {
                    if (normalLabel.SelectSingleNode("DataLine/Item[@Type='LABEL_ITEM_CPDLCAIR']") == null)
                    {
                        doc.Save($"{hardcodedFilePath}.bak");
                        XmlElement newDataLine = doc.CreateElement("DataLine");
                        XmlElement newItem = doc.CreateElement("Item");
                        newItem.SetAttribute("Type", "LABEL_ITEM_CPDLCAIR");
                        newDataLine.AppendChild(newItem);
                        normalLabel.AppendChild(newDataLine);
                    }
                }

                XmlNode groundDepartureLabel = doc.SelectSingleNode("//Label[@Type='GroundDeparture']");
                if (groundDepartureLabel != null)
                {
                    if (groundDepartureLabel.SelectSingleNode("DataLine/Item[@Type='LABEL_ITEM_CPDLCGROUND']") == null)
                    {
                        XmlElement newDataLine = doc.CreateElement("DataLine");
                        XmlElement newItem = doc.CreateElement("Item");
                        newItem.SetAttribute("Type", "LABEL_ITEM_CPDLCGROUND");
                        newDataLine.AppendChild(newItem);
                        groundDepartureLabel.AppendChild(newDataLine);
                    }
                }

                doc.Save(hardcodedFilePath);
                logger.Log("Patch complete!");
            }
            catch (Exception e)
            {
                logger.Log($"Oops: {e}");
            }
        }
    }
}
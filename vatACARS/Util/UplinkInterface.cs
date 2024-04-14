using System.Collections.Generic;
using System.Xml.Serialization;

namespace vatACARS.Util
{
    [XmlRoot("data")]
    public class UplinkInterface
    {
        [XmlElement("Entry")]
        public List<UplinkEntry> Entries { get; set; }
    }

    public class UplinkEntry
    {
        [XmlAttribute("Code")]
        public string Code { get; set; }

        [XmlAttribute("Element")]
        public string Element { get; set; }

        [XmlAttribute("Response")]
        public string Response { get; set; }

        [XmlAttribute("Group")]
        public string Group { get; set; }
    }
}

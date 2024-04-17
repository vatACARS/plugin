using System.Collections.Generic;
using System.Xml.Serialization;

namespace vatACARS.Util
{
    [XmlRoot("data")]
    public class UplinkInterface
    {
        [XmlElement("ENTRY")]
        public List<UplinkEntry> Entries { get; set; }
    }

    public class UplinkEntry
    {
        [XmlAttribute("CODE")]
        public string Code { get; set; }

        [XmlAttribute("MESSAGE")]
        public string Element { get; set; }

        [XmlAttribute("RESP")]
        public string Response { get; set; }

        [XmlAttribute("GROUP")]
        public string Group { get; set; }

        // TODO: "URG" & "ALRT" elems
    }
}

using System.Collections.Generic;
using System.Xml.Serialization;

namespace vatACARS.Util
{
    public class UplinkEntry : System.ICloneable
    {
        [XmlAttribute("CODE")]
        public string Code { get; set; }

        [XmlAttribute("MESSAGE")]
        public string Element { get; set; }

        [XmlAttribute("GROUP")]
        public string Group { get; set; }

        [XmlAttribute("RESP")]
        public string Response { get; set; }

        // TODO: "URG" & "ALRT" elems

        public object Clone()
        {
            return new UplinkEntry
            {
                Code = this.Code,
                Element = this.Element,
                Response = this.Response,
                Group = this.Group
            };
        }
    }

    [XmlRoot("data")]
    public class XMLInterface
    {
        [XmlElement("ENTRY")]
        public List<UplinkEntry> Entries { get; set; }
    }
}
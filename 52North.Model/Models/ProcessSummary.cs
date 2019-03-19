using System;
using System.Xml.Serialization;

namespace _52North.Model.Models
{
    [Serializable]
    [XmlRoot(ElementName = "ProcessSummary", Namespace = WpsNamespace)]
    public class ProcessSummary
    {

        private const string OwsNamespace = "http://www.opengis.net/ows/2.0";
        private const string WpsNamespace = "http://www.opengis.net/wps/2.0";

        [XmlElement("Title", Namespace = OwsNamespace)]
        public string Title { get; set; }

        [XmlElement("Identifier", Namespace = OwsNamespace)]
        public string Identifier { get; set; }

        [XmlAttribute("processVersion", Namespace = WpsNamespace)]
        public string Version { get; set; }

    }
}

using System;
using System.Xml.Serialization;

namespace _52North.Model.Models
{
    [Serializable]
    [XmlRoot(ElementName = "Capabilities", Namespace = WpsNamespace)]
    public class ProcessSummaryCollection
    {

        private const string WpsNamespace = "http://www.opengis.net/wps/2.0";

        [XmlArray("Contents")]
        [XmlArrayItem(ElementName = "ProcessSummary", Type = typeof(ProcessSummary), Namespace = WpsNamespace)]
        public ProcessSummary[] Processes { get; set; }

    }
}

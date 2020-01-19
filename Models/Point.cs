using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="POINT")]
		public class Point {
		[XmlElement(ElementName="TIMESTAMP")]
		public string TIMESTAMP { get; set; }
		[XmlElement(ElementName="SCORE")]
		public string SCORE { get; set; }
	}
}

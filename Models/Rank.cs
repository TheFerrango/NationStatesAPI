using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="RANK")]
	public class Rank {
		[XmlElement(ElementName="SCORE")]
		public string SCORE { get; set; }
		[XmlElement(ElementName="CHANGE")]
		public string CHANGE { get; set; }
		[XmlElement(ElementName="PCHANGE")]
		public string PCHANGE { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

}

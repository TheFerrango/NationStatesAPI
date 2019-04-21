using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="RANK")]
	public class Rank {
		[XmlElement(ElementName="SCORE")]
		public string SCORE { get; set; }
		[XmlElement(ElementName="CHANGE")]
		public double CHANGE { get; set; }
		[XmlElement(ElementName="PCHANGE")]
		public double PCHANGE { get; set; }
		[XmlAttribute(AttributeName="id")]
		public int Id { get; set; }
	}

}

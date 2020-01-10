using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="SCALE")]
	public class Scale {
		[XmlElement(ElementName="SCORE")]
		public string Score { get; set; }
		[XmlElement(ElementName="RANK")]
		public string Rank { get; set; }
		[XmlElement(ElementName="RRANK")]
		public string RRank { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}
}

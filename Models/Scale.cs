using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="SCALE")]
	public class Scale {
		[XmlElement(ElementName="SCORE")]
		public double Score { get; set; }
		[XmlElement(ElementName="RANK")]
		public int Rank { get; set; }
		[XmlElement(ElementName="RRANK")]
		public int RRank { get; set; }
		[XmlAttribute(AttributeName="id")]
		public int Id { get; set; }
	}
}

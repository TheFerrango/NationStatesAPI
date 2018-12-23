using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="ISSUE")]
	public class IssuePlayedResult {
		[XmlElement(ElementName="OK")]
		public string OK { get; set; }
		[XmlElement(ElementName="DESC")]
		public string DESC { get; set; }
		[XmlElement(ElementName="RANKINGS")]
		public Rankings RANKINGS { get; set; }
		[XmlElement(ElementName="UNLOCKS")]
		public BannerUnlocks UNLOCKS { get; set; }
		[XmlElement(ElementName="HEADLINES")]
		public Headlines HEADLINES { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName="choice")]
		public string Choice { get; set; }
	}

}

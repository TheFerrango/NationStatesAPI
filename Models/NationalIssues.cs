using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="NATION")]
	public class NationalIssues {
		[XmlElement(ElementName="ISSUES")]
		public Issues ISSUES { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

}

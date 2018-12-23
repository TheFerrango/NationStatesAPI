using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="NATION")]
	public class IssuePlayedResponse {
		[XmlElement(ElementName="ISSUE")]
		public IssuePlayedResult ISSUE { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

}

using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="OPTION")]
	public class IssueOptions {
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

}

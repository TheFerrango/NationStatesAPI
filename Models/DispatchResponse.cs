using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="NATION")]
	public class DispatchResponse {
		[XmlElement(ElementName="SUCCESS")]
		public string SUCCESS { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

}

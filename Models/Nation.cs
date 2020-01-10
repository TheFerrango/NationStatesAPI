using System.Xml.Serialization;

namespace NationStatesAPI.Models
{

    [XmlRoot(ElementName="NATION")]
	public class Nation {
		[XmlElement(ElementName="CENSUS")]
		public Census CENSUS { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}
}

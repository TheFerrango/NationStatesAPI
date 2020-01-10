using System.Collections.Generic;
using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="CENSUS")]
	public class Census {
		[XmlElement(ElementName="SCALE")]
		public List<Scale> Scale { get; set; }
	}
}

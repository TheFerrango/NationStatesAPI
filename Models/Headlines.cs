using System.Collections.Generic;
using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="HEADLINES")]
	public class Headlines {
		[XmlElement(ElementName="HEADLINE")]
		public List<string> HEADLINE { get; set; }
	}

}

using System.Collections.Generic;
using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="RANKINGS")]
	public class Rankings {
		[XmlElement(ElementName="RANK")]
		public List<Rank> RANK { get; set; }
	}

}

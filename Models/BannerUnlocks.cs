using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="UNLOCKS")]
	public class BannerUnlocks {
		[XmlElement(ElementName="BANNER")]
		public string BANNER { get; set; }
	}

}

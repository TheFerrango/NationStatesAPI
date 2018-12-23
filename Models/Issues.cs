using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="ISSUES")]
	public class Issues {
		[XmlElement(ElementName="ISSUE")]
		public List<Issue> ISSUE { get; set; }
	}
}

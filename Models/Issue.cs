using System.Collections.Generic;
using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="ISSUE")]
	public class Issue {
		[XmlElement(ElementName="TITLE")]
		public string TITLE { get; set; }
		[XmlElement(ElementName="TEXT")]
		public string TEXT { get; set; }
		[XmlElement(ElementName="AUTHOR")]
		public string AUTHOR { get; set; }
		[XmlElement(ElementName="EDITOR")]
		public string EDITOR { get; set; }
		[XmlElement(ElementName="PIC1")]
		public string PIC1 { get; set; }
		[XmlElement(ElementName="PIC2")]
		public string PIC2 { get; set; }
		[XmlElement(ElementName="OPTION")]
		public List<IssueOptions> OPTION { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

}

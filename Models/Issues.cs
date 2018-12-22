using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="OPTION")]
	public class OPTION {
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="ISSUE")]
	public class ISSUE {
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
		public List<OPTION> OPTION { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName="ISSUES")]
	public class ISSUES {
		[XmlElement(ElementName="ISSUE")]
		public List<ISSUE> ISSUE { get; set; }
	}

	[XmlRoot(ElementName="NATION")]
	public class NationalIssues {
		[XmlElement(ElementName="ISSUES")]
		public ISSUES ISSUES { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName="RANK")]
	public class RANK {
		[XmlElement(ElementName="SCORE")]
		public string SCORE { get; set; }
		[XmlElement(ElementName="CHANGE")]
		public string CHANGE { get; set; }
		[XmlElement(ElementName="PCHANGE")]
		public string PCHANGE { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName="RANKINGS")]
	public class RANKINGS {
		[XmlElement(ElementName="RANK")]
		public List<RANK> RANK { get; set; }
	}

	[XmlRoot(ElementName="UNLOCKS")]
	public class UNLOCKS {
		[XmlElement(ElementName="BANNER")]
		public string BANNER { get; set; }
	}

	[XmlRoot(ElementName="HEADLINES")]
	public class HEADLINES {
		[XmlElement(ElementName="HEADLINE")]
		public List<string> HEADLINE { get; set; }
	}

	[XmlRoot(ElementName="ISSUE")]
	public class ISSUERESULT {
		[XmlElement(ElementName="OK")]
		public string OK { get; set; }
		[XmlElement(ElementName="DESC")]
		public string DESC { get; set; }
		[XmlElement(ElementName="RANKINGS")]
		public RANKINGS RANKINGS { get; set; }
		[XmlElement(ElementName="UNLOCKS")]
		public UNLOCKS UNLOCKS { get; set; }
		[XmlElement(ElementName="HEADLINES")]
		public HEADLINES HEADLINES { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName="choice")]
		public string Choice { get; set; }
	}

	[XmlRoot(ElementName="NATION")]
	public class ISSUEPLAYEDRESPONSE {
		[XmlElement(ElementName="ISSUE")]
		public ISSUERESULT ISSUE { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

}

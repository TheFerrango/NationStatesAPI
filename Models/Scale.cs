using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName="SCALE")]
	public class Scale {
		[XmlElement(ElementName="SCORE")]
		public double Score { get; set; }
		[XmlElement(ElementName="RANK")]
		public string _StrRank { get; set; }
		public int? Rank => String.IsNullOrWhiteSpace(_StrRank) ? (int?)null : Convert.ToInt32(_StrRank);
		[XmlElement(ElementName="RRANK")]
		public string _StrRRank { get; set; }
		public int? RRank => String.IsNullOrWhiteSpace(_StrRRank) ? (int?)null : Convert.ToInt32(_StrRRank);

		[XmlAttribute(AttributeName="id")]
		public int Id { get; set; }

		[XmlElement(ElementName="POINT")]
		public List<Point> Point { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NationStatesAPI.Models
{
    [XmlRoot(ElementName = "SCALE")]
    public class Scale
    {
        [XmlElement(ElementName = "SCORE")]
        public double Score { get; set; }
        // private string Score { get; set; }
        [XmlElement(ElementName = "RANK")]
        public int Rank { get; set; }
        [XmlElement(ElementName = "RRANK")]
		public string RRankAsText
        {
            get { return (RRank.HasValue) ? RRank.ToString() : null; }
            set { RRank = !string.IsNullOrEmpty(value) ? int.Parse(value) : default(int?); }
        }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "POINT")]
        public List<Point> Point { get; set; }


        [XmlIgnore]
        public int? RRank { get; set; }
    }
}
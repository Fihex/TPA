using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TPA
{
    interface IProduct
    {
        int Id { get; set; }
        string Category { get; set; }
        string Title { get; set; }
    }
    interface IPrice
    {
        string Unit { get; set; }
        decimal Value { get; set; }
    }
    public class Product : IProduct
    {

        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("category")]
        public string Category { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("price")]
        public Price price { get; set; }
        [XmlElement("description")]
        public Description description { get; set; }
    }
    [XmlRoot("price")]
    public class Price : IPrice
    {   
        [XmlAttribute("unit")]
        public string Unit { get; set; }
        [XmlText]
        public decimal Value { get; set; }
    }
    [XmlRoot("description")]
    public class Description
    {
        [XmlElement("weight")]
        public decimal Weight { get; set; }
    }
}

using System.Collections.Generic;
using System.Xml.Serialization;
using Municipalities.Data.Entities.Entities;

namespace MunicipalitiesApi.Models
{
    [XmlRoot]
    public class MunicipalitityList
    {
        [XmlElement("Municipality")]
        public List<Municipality> Municipalities { get; set; }
    }
}
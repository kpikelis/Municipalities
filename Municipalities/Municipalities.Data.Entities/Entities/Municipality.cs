using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Municipalities.Data.Entities.Entities
{
    [DataContract]
    [XmlRoot]
    public class Municipality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MunicipalityId { get; set; }

        [DataMember]
        [XmlElement]
        [Index(IsUnique = true)]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}

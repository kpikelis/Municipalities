using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Municipalities.Data.Entities.Entities
{
    [DataContract]
    public class MunicipalityTax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MunicipalityTaxId { get; set; }
        
        [Required]
        [ForeignKey(nameof(Municipality))]
        public long MunicipalityId { get; set; }
        
        [Required]
        [ForeignKey(nameof(TaxPeriod))]
        public long TaxPeriodId { get; set; }

        [DataMember]
        public decimal Tax { get; set; }

        [DataMember]
        public virtual Municipality Municipality { get; set; }

        [DataMember]
        public virtual TaxPeriod TaxPeriod { get; set; }
    }
}

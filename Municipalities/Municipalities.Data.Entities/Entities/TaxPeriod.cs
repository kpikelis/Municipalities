using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Municipalities.Data.Entities.Enums;

namespace Municipalities.Data.Entities.Entities
{
    [DataContract]
    public class TaxPeriod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaxPeriodId { get; set; }

        [DataMember]
        public Period Period { get; set; }

        [DataMember]
        public DateTime DateFrom { get; set; }

        [DataMember]
        public DateTime DateTo { get; set; }
    }


}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Municipalities.Data.Entities.Entities
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogId { get; set; }

        [MaxLength(50)]
        public string Level { get; set; }

        [MaxLength(250)]
        public string CallSite { get; set; }

        [MaxLength(250)]
        public string Type { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string InnerException { get; set; }

        public string AdditionalInfo { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}

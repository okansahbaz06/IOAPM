using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APM.Entities.Entities
{
    [Table("ACTIVITIES")]
    public class Activity
    {
        [Key]
        public int ID { get; set; }//PK

        [Required]
        public int PROJECT_NUMBER { get; set; }//FK --

        [Required]
        public string ACTIVITY_DETAIL { get; set; }

        [Required]
        public int ACTIVITY_CREATOR { get; set; }//FK--
        [Required]
        public int ACTIVITY_EMPLOYEE { get; set; }

        [Required]
        public DateTime ACTIVITY_DATE { get; set; }

        [Required]
        public TimeSpan START_TIME { get; set; }

        public TimeSpan? END_TIME { get; set; }

        [Required]
        public double WHOUR { get; set; }

        [Required]
        public bool ACTIVITY_STATUS { get; set; }

        [Required]
        public string LOCATION { get; set; }

        [Required]
        public int ACTIVITY_PRIORITY { get; set; }//FK--

        [Required]
        public DateTime CREATED_DATE { get; set; } = DateTime.Now;

        [Required]
        public TimeSpan CREATED_TIME { get; set; } = DateTime.Now.TimeOfDay;

        [Required]
        public bool INVOICE { get; set; }
        [MaxLength(30)]
        public string REFERENCE_NO { get; set; }

        public string IndirectCustomerName { get; set; }

        public virtual Project PROJECT { get; set; }

        public virtual Employee EMPLOYEE { get; set; } //????

        public virtual Employee CREATED_EMPLOYEE { get; set; }

        public virtual Priority PRIORITY { get; set; }
    }
}

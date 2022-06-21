using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APM.Entities.Entities
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }//PK

        [Required, StringLength(30)]
        public string CUSTOMER_NAME { get; set; }

        [Required, StringLength(20)]
        public string CUSTOMER_TYPE { get; set; }

        [Required, StringLength(15)]
        public string CUSTOMER_PHONE_NO { get; set; }

        [Required, StringLength(100)]
        public string CUSTOMER_ADRESS { get; set; }

        [Required, StringLength(40)]
        public string CUSTOMER_MAIL { get; set; }

        [Required]
        public bool CUSTOMER_STATUS { get; set; }

        [Required]
        public int CUSTOMER_CREATOR { get; set; }//FK --

        [Required]
        public DateTime CREATED_DATE { get; set; } = DateTime.Now;

        [Required]
        public TimeSpan CREATED_TIME { get; set; } = DateTime.Now.TimeOfDay;


        public virtual Employee CREATED_CUSTOMER { get; set; }

        public virtual ICollection<Project> PROJECTS { get; set; }
    }
}

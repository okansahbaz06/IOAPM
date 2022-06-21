using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APM.Entities.Entities
{
    [Table("NOTIFICATION")]
    public class Notification
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TEXT_INFO { get; set; }
        [Required]
        public DateTime START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }

    }
}

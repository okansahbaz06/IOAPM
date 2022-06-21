using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APM.Entities.Entities
{
    [Table("LEVELS")]
    public class Level
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(15)]
        public string LEVEL_NAME { get; set; }
        public int i { get; set; }


        public virtual ICollection<Project> PROJECTS { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APM.Entities.Entities
{
    [Table("PROJECT_TYPE")]
    public class Project_Type
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string TYPE_NAME { get; set; }


        public virtual ICollection<Project> PROJECTS { get; set; }
    }
}

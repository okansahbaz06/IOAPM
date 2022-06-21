using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APM.Entities.Entities
{
    [Table("TITLES")]
    public class Title
    {
        [Key]
        public int ID { get; set; } //PK

        [Required, StringLength(30)]
        public string TITLE_NAME { get; set; }

        public virtual ICollection<Employee> EMPLOYEES { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APM.Entities.Entities
{
    [Table("PROJECTS")]
    public class Project
    {
        public int ID { get; set; }

        [Required]
        public int PROJECT_TYPE { get; set; }//FK--

        [Required, StringLength(50)]
        public string PROJECT_NAME { get; set; }

        [Required]
        public int CUSTOMER_NUMBER { get; set; }//FK --

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ESTIMATE_START_DATE { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ESTIMATE_END_DATE { get; set; }
        [Required]
        public DateTime? START_DATE { get; set; }

        public DateTime? END_DATE { get; set; }

        [Required]
        public bool PROJECT_STATUS { get; set; }

        [Required]
        public int PROJECT_LEVEL { get; set; }//FK --   

        [Required]
        public int PROJECT_CREATOR { get; set; }//FK --

        [Required]
        public DateTime CREATED_DATE { get; set; } = DateTime.Now;

        [Required]
        public TimeSpan CREATED_TIME { get; set; } = DateTime.Now.TimeOfDay;



        public virtual ICollection<Activity> ACTIVITIES { get; set; }

        public virtual Project_Type PROJECT_TYPE_ { get; set; }

        public virtual Customer CUSTOMER { get; set; }

        public List<ProjectEmployee> PROJECTEMPLOYEE { get; set; }

        public virtual Level LEVEL { get; set; }

        public virtual Employee CREATED_EMPLOYEE { get; set; }
    }
}

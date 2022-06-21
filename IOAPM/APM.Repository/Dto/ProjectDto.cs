using APM.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class ProjectDto
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int TYPE { get; set; }
        public int CUSTOMER_ID { get; set; }
        public DateTime EST_START_DATE { get; set; }
        public DateTime EST_END_DATE { get; set; }
        public DateTime? START_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public bool STATUS { get; set; }
        public int LEVEL_ID { get; set; }
        public int CREATOR { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public TimeSpan CREATED_TIME { get; set; }
        public virtual List<int> NEWPROJECTEMPLOYEE { get; set; }

        public virtual ICollection<Activity> ACTIVITIES { get; set; }

        public virtual Project_Type PROJECT_TYPE_ { get; set; }

        public virtual Customer CUSTOMER { get; set; }

        public virtual ICollection<ProjectEmployee> EMPLOYEES { get; set; }

        public virtual Level LEVEL { get; set; }

        public virtual Employee CREATED_EMPLOYEE { get; set; }

    }
}

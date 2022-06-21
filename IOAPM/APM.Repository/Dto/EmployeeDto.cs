using APM.Entities.Entities;
using System;
using System.Collections.Generic;

namespace APM.Repository.Dto
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string PHONE_NO { get; set; }
        public string ADRESS { get; set; }
        public string MAIL { get; set; }
        public bool STATUS { get; set; }
        public int TITLE_ID { get; set; }
        public int CREATOR_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public TimeSpan CREATED_TIME { get; set; }
        public string ROLE { get; set; }
        public string PASSWORD { get; set; }

        public virtual List<double> SumWhour {get; set;}
        public virtual List<ProjectWhour> SumProjectWhour { get; set; }


        virtual public Title TITLE { get; set; }

        public virtual ICollection<Employee> CREATED_EMPLOYEES { get; set; }
        public virtual Employee CREATED_EMPLOYEE { get; set; }

        public virtual ICollection<Activity> ACTIVITIES { get; set; } 

        public virtual ICollection<Activity> CREATED_ACTIVITY { get; set; }

        public virtual ICollection<Customer> CUSTOMERS { get; set; }

        public virtual ICollection<ProjectEmployee> PROJECTS { get; set; }

        public virtual ICollection<Project> CREATED_PROJECTS { get; set; }

    }
}

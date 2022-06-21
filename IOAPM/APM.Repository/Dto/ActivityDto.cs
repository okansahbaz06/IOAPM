using APM.Entities.Entities;
using System;
using System.Collections.Generic;

namespace APM.Repository.Dto
{
    public class ActivityDto
    {
        public int ID { get; set; }//PK

        public int? PROJECT_NUMBER { get; set; }//FK --

        public string ACTIVITY_DETAIL { get; set; }

        public int CREATOR { get; set; }//FK--

        public int ACTIVITY_EMPLOYEE { get; set; }

        public DateTime ACTIVITY_DATE { get; set; }

        public TimeSpan? START_TIME { get; set; }

        public TimeSpan? END_TIME { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public TimeSpan CREATED_TIME { get; set; }

        public bool STATUS { get; set; }

        public int ACTIVITY_PRIORITY { get; set; }//FK--

        public bool INVOICE { get; set; }

        public double WHOUR { get; set; }

        public string LOCATION { get; set; }

        public string REFERENCE_NO { get; set; }

        public string IndirectCustomerName { get; set; }

        public virtual Project PROJECT { get; set; }

        public virtual Employee EMPLOYEE { get; set; } //????

        public virtual Employee CREATED_EMPLOYEE { get; set; }

        public virtual Priority PRIORITY { get; set; }
    }
}
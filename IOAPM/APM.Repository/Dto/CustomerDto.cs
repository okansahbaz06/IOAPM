using APM.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class CustomerDto
    {
        public int ID { get; set; }
        public string TYPE { get; set; }
        public string NAME { get; set; }
        public string PHONE_NO { get; set; }
        public string ADRESS { get; set; }
        public string MAIL { get; set; }
        public bool STATUS { get; set; }
        public int CREATOR_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public TimeSpan CREATED_TIME { get; set; }

        public virtual Employee CREATED_CUSTOMER { get; set; }

    }
}

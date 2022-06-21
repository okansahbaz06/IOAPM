using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class NotificationDto
    {
        public int ID { get; set; }
        public string TEXT_INFO { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
    }
}

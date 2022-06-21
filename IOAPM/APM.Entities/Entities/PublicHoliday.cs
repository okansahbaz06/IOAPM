using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace APM.Entities.Entities
{
    [Table("PUBLICHOLIDAYS")]
    public class PublicHoliday
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string htmlLink { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string summary { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string transparency { get; set; }
        public string visibility { get; set; }
        public string iCalUID { get; set; }
        public int sequence { get; set; }
        public DateTime lastUpdate { get; set; } = DateTime.Now;
    }
}

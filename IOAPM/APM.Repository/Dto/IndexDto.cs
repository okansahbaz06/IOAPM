using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class IndexDto
    {
        public int projectCount { get; set; }
        public int employeeCount { get; set; }
        public int customerCount { get; set; }
        public int activityCount { get; set; }
        public List<NotificationDto> Notification { get; set; }
        public List<ProjectDto> MyProject { get; set; }

        public int myProjectCount { get; set; }
        public int myActivityCount { get; set; }
        public List<double> wHours { get; set; }
        public List<double> projectWhour { get; set; }
        public List<string> DaysSummary { get; set; }
    }
}

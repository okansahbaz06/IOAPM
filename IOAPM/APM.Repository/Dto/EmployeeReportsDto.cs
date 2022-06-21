using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class EmployeeReportsDto
    {
        public List<ProjectDto> Projects { get; set; }
        public List<int> SelectedProjectId{ get; set; }
        public bool? Invoice { get; set; }
        public List<EmployeeDto> Employees { get; set; }
        public List<EmployeeDto> SelectedEmployee { get; set; }
        public List<string> DaysSummary { get; set; }
    }
}

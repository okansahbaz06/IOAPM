using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class ActivityAllDto
    {
        public List<ActivityDto> ActivityDto { get; set; }
        public List<ProjectDto> ProjectDto { get; set; }
        public List<EmployeeDto> EmployeeDto { get; set; }
        public List<PriorityDto> PriorityDto { get; set; }
        public List<CustomerDto> customerDto { get; set; }
    }
}

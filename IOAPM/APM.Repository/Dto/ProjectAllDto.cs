using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class ProjectAllDto
    {
        public List<ProjectDto> ProjectDto { get; set; }
        public List<CustomerDto> CustomerDto { get; set; }
        public List<EmployeeDto> EmployeeDto { get; set; }
        public List<LevelDto> LevelDto { get; set; }
        public List<ProjectTypeDto> ProjectTypeDto { get; set; }
    }
}

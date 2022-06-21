using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class SendEmailDto
    {
        public List<EmployeeDto> Employees { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<CustomerDto> Customers { get; set; }
    }
}

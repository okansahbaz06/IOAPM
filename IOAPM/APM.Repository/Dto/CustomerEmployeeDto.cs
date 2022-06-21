using System.Collections.Generic;

namespace APM.Repository.Dto
{
    public class CustomerEmployeeDto
    {
        public List<EmployeeDto> EmployeeDto { get; set; }
        public List<CustomerDto> CustomerDto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Dto
{
    public class EmpConsDto
    {
        public List<TitleDto> TitleDto { get; set; }
        public List<EmployeeDto> EmployeeDto { get; set; }
        public List<string> RoleDto { get; set; }
    }
}

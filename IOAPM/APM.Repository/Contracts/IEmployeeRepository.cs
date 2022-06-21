using APM.Entities.Entities;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        EmpConsDto GetList();
        void Create(EmployeeDto employee);
        EmployeeDto Get(int id);
        UserDto Get(string email);
        void Delete(int id);
        void Update(EmployeeDto employee);
        void UpdateMyInfo(UserDto user);
        void UpdateMyPass(int id, string pass);
        bool IsAnyEmployee(string mail);
        List<EmployeeDto> EntryDailyActivity();
        EmployeeReportsDto GetEmployeesId();
        EmployeeReportsDto GetReports(List<int> id, int month, int year, List<int> projectId, bool? invoice);
        void SendMailAllEmployees(List<int> employeesId, string subject, bool isInput);
        List<EmployeeDto> GetAllEmployeeNewMember();
        SendEmailDto GetSendEmailDto();
        void SendSpecialMailEmployee(List<int> id, string subject, string header, string content);
        void SendMailProjectEmployee(int projectId, string subject, string header, string content);
        void SendMailCustomer(List<int> customerId, string subject, string header, string content);
    }
}

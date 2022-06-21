using Microsoft.EntityFrameworkCore;
using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APM.Repository
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public void Create(ActivityDto activity)
        {
            _context.Activities.Add(new Activity
            {
                ID = activity.ID,
                PROJECT_NUMBER = (int)activity.PROJECT_NUMBER,
                ACTIVITY_DETAIL = activity.ACTIVITY_DETAIL,
                ACTIVITY_CREATOR = activity.CREATOR,
                ACTIVITY_EMPLOYEE = activity.ACTIVITY_EMPLOYEE,
                ACTIVITY_DATE = activity.ACTIVITY_DATE,
                START_TIME = (TimeSpan)activity.START_TIME,
                END_TIME = activity.END_TIME,
                ACTIVITY_STATUS = true,
                ACTIVITY_PRIORITY = 3,
                INVOICE = activity.INVOICE,
                WHOUR = activity.WHOUR,
                LOCATION = activity.LOCATION,
                REFERENCE_NO = activity.REFERENCE_NO,
                IndirectCustomerName = activity.IndirectCustomerName
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var activity = _context.Activities.FirstOrDefault(p => p.ID == id);

            _context.Activities.Remove(activity);
            _context.SaveChanges();
        }

        public int GetLastActivityId()
        {
            return _context.Activities.Max(a => a.ID);
        }

        public ActivityAllDto GetDateRangeList(DateTime from, DateTime to)
        {
            var activity = _context.Activities.OrderByDescending(a => a.ACTIVITY_DATE).Where(a => a.ACTIVITY_DATE >= from && a.ACTIVITY_DATE <= to).Select(a => new ActivityDto
            {
                ID = a.ID,
                PROJECT_NUMBER = a.PROJECT_NUMBER,
                ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                CREATOR = a.ACTIVITY_CREATOR,
                ACTIVITY_EMPLOYEE = a.ACTIVITY_EMPLOYEE,
                ACTIVITY_DATE = a.ACTIVITY_DATE,
                START_TIME = a.START_TIME,
                END_TIME = a.END_TIME,
                STATUS = a.ACTIVITY_STATUS,
                ACTIVITY_PRIORITY = a.ACTIVITY_PRIORITY,
                INVOICE = a.INVOICE,
                CREATED_DATE = a.CREATED_DATE,
                CREATED_TIME = a.CREATED_TIME,
                PROJECT = a.PROJECT,
                CREATED_EMPLOYEE = a.CREATED_EMPLOYEE,
                PRIORITY = a.PRIORITY,
                EMPLOYEE = a.EMPLOYEE,
                WHOUR = a.WHOUR,
                LOCATION = a.LOCATION,
                REFERENCE_NO = a.REFERENCE_NO,
                IndirectCustomerName = a.IndirectCustomerName
            }).ToList();

            var project = _context.Projects.Select(p => new ProjectDto { ID = p.ID, NAME = p.PROJECT_NAME, CUSTOMER = p.CUSTOMER }).ToList();

            var employee = _context.Employees.Where(e => e.EMPLOYEE_STATUS == true).Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME, PROJECTS = e.PROJECTEMPLOYEE }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            var customer = _context.Customers.Select(c => new CustomerDto { ID = c.ID, NAME = c.CUSTOMER_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority, customerDto = customer };
        }

        public ActivityAllDto GetMonthList()
        {
            DateTime dt = DateTime.Now;

            var activity = _context.Activities.OrderByDescending(a => a.ACTIVITY_DATE).Where(a => a.ACTIVITY_DATE.Month == dt.Month && a.ACTIVITY_DATE.Year == dt.Year).Select(a => new ActivityDto
            {
                ID = a.ID,
                PROJECT_NUMBER = a.PROJECT_NUMBER,
                ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                CREATOR = a.ACTIVITY_CREATOR,
                ACTIVITY_EMPLOYEE = a.ACTIVITY_EMPLOYEE,
                ACTIVITY_DATE = a.ACTIVITY_DATE,
                START_TIME = a.START_TIME,
                END_TIME = a.END_TIME,
                STATUS = a.ACTIVITY_STATUS,
                ACTIVITY_PRIORITY = a.ACTIVITY_PRIORITY,
                INVOICE = a.INVOICE,
                CREATED_DATE = a.CREATED_DATE,
                CREATED_TIME = a.CREATED_TIME,
                PROJECT = a.PROJECT,
                CREATED_EMPLOYEE = a.CREATED_EMPLOYEE,
                PRIORITY = a.PRIORITY,
                EMPLOYEE = a.EMPLOYEE,
                WHOUR = a.WHOUR,
                LOCATION = a.LOCATION,
                REFERENCE_NO = a.REFERENCE_NO,
                IndirectCustomerName = a.IndirectCustomerName
            }).ToList();

            var project = _context.Projects.Select(p => new ProjectDto { ID = p.ID, NAME = p.PROJECT_NAME, CUSTOMER = p.CUSTOMER }).ToList();

            var employee = _context.Employees.Where(e => e.EMPLOYEE_STATUS == true).Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME, PROJECTS = e.PROJECTEMPLOYEE }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            var customer = _context.Customers.Select(c => new CustomerDto { ID = c.ID, NAME = c.CUSTOMER_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority, customerDto = customer };
        }


        public ActivityAllDto GetMyActivity(int id)
        {
            DateTime dt = DateTime.Now;

            var activity = _context.Activities.Include(a => a.PROJECT).ThenInclude(p => p.CUSTOMER)
                .OrderByDescending(a => a.ACTIVITY_DATE).Where(a => a.ACTIVITY_EMPLOYEE == id && a.ACTIVITY_DATE.Month == dt.Month && a.ACTIVITY_DATE.Year == dt.Year)
                .Select(a => new ActivityDto
                {
                    ID = a.ID,
                    PROJECT_NUMBER = a.PROJECT_NUMBER,
                    ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                    CREATOR = a.ACTIVITY_CREATOR,
                    ACTIVITY_EMPLOYEE = a.ACTIVITY_EMPLOYEE,
                    ACTIVITY_DATE = a.ACTIVITY_DATE,
                    START_TIME = a.START_TIME,
                    END_TIME = a.END_TIME,
                    STATUS = a.ACTIVITY_STATUS,
                    ACTIVITY_PRIORITY = a.ACTIVITY_PRIORITY,
                    INVOICE = a.INVOICE,
                    CREATED_DATE = a.CREATED_DATE,
                    CREATED_TIME = a.CREATED_TIME,
                    EMPLOYEE = a.EMPLOYEE,
                    PROJECT = a.PROJECT,
                    CREATED_EMPLOYEE = a.CREATED_EMPLOYEE,
                    PRIORITY = a.PRIORITY,
                    WHOUR = a.WHOUR,
                    LOCATION = a.LOCATION,
                    REFERENCE_NO = a.REFERENCE_NO
                }).ToList();
            var projectID = _context.ProjectEmployees.Where(e => e.EmployeeID == id).Select(p => p.ProjectID);
            var customerID = _context.ProjectEmployees.Where(e => e.EmployeeID == id).Select(p => p.PROJECT.CUSTOMER_NUMBER);

            var project = _context.Projects.Where(p => projectID.Contains(p.ID)).Select(p => new ProjectDto { ID = p.ID, NAME = p.PROJECT_NAME, CUSTOMER = p.CUSTOMER }).ToList();

            var employee = _context.Employees.Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            var customer = _context.Customers.Where(c => customerID.Contains(c.ID)).Select(c => new CustomerDto { ID = c.ID, NAME = c.CUSTOMER_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority, customerDto = customer };
        }
        public ActivityAllDto GetMyDateRangeActivity(int id, DateTime? from, DateTime? to)
        {
            DateTime dt = DateTime.Now;

            var activity = _context.Activities.OrderByDescending(a => a.ACTIVITY_DATE).Where(a => a.ACTIVITY_EMPLOYEE == id && a.ACTIVITY_DATE >= from && a.ACTIVITY_DATE <= to).Select(a => new ActivityDto
            {
                ID = a.ID,
                PROJECT_NUMBER = a.PROJECT_NUMBER,
                ACTIVITY_DETAIL = a.ACTIVITY_DETAIL,
                CREATOR = a.ACTIVITY_CREATOR,
                ACTIVITY_EMPLOYEE = a.ACTIVITY_EMPLOYEE,
                ACTIVITY_DATE = a.ACTIVITY_DATE,
                START_TIME = a.START_TIME,
                END_TIME = a.END_TIME,
                STATUS = a.ACTIVITY_STATUS,
                ACTIVITY_PRIORITY = a.ACTIVITY_PRIORITY,
                INVOICE = a.INVOICE,
                CREATED_DATE = a.CREATED_DATE,
                CREATED_TIME = a.CREATED_TIME,
                EMPLOYEE = a.EMPLOYEE,
                PROJECT = a.PROJECT,
                CREATED_EMPLOYEE = a.CREATED_EMPLOYEE,
                PRIORITY = a.PRIORITY,
                WHOUR = a.WHOUR,
                LOCATION = a.LOCATION,
                REFERENCE_NO = a.REFERENCE_NO
            }).ToList();

            var projectID = _context.ProjectEmployees.Where(e => e.EmployeeID == id).Select(p => p.ProjectID);

            var customerID = _context.ProjectEmployees.Where(e => e.EmployeeID == id).Select(p => p.PROJECT.CUSTOMER_NUMBER);

            var project = _context.Projects.Where(p => projectID.Contains(p.ID)).Select(p => new ProjectDto { ID = p.ID, NAME = p.PROJECT_NAME, CUSTOMER = p.CUSTOMER }).ToList();

            var employee = _context.Employees.Select(e => new EmployeeDto { ID = e.ID, NAME = e.EMPLOYEE_NAME, SURNAME = e.EMPLOYEE_SURNAME }).ToList();

            var priority = _context.Priorities.Select(p => new PriorityDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();

            var customer = _context.Customers.Where(c => customerID.Contains(c.ID)).Select(c => new CustomerDto { ID = c.ID, NAME = c.CUSTOMER_NAME }).ToList();

            return new ActivityAllDto { ActivityDto = activity, ProjectDto = project, EmployeeDto = employee, PriorityDto = priority, customerDto = customer };
        }

        public void Update(ActivityDto activity)
        {
            var thisActivity = _context.Activities.FirstOrDefault(a => a.ID == activity.ID);

            thisActivity.PROJECT_NUMBER = (int)activity.PROJECT_NUMBER;
            thisActivity.ACTIVITY_DETAIL = activity.ACTIVITY_DETAIL;
            thisActivity.ACTIVITY_DATE = activity.ACTIVITY_DATE;
            thisActivity.START_TIME = (TimeSpan)activity.START_TIME;
            thisActivity.END_TIME = activity.END_TIME;
            thisActivity.INVOICE = activity.INVOICE;
            thisActivity.WHOUR = activity.WHOUR;
            thisActivity.LOCATION = activity.LOCATION;
            thisActivity.REFERENCE_NO = activity.REFERENCE_NO;
            thisActivity.IndirectCustomerName = activity.IndirectCustomerName;
            thisActivity.ACTIVITY_EMPLOYEE = activity.CREATOR;
            thisActivity.ACTIVITY_CREATOR = activity.CREATOR;


            _context.Activities.Update(thisActivity);
            _context.SaveChanges();
        }
        public int FindEmployeeId(string fullName)
        {
            return _context.Employees.Where(e => (e.EMPLOYEE_NAME + " " + e.EMPLOYEE_SURNAME) == fullName).Select(e => e.ID).FirstOrDefault();
        }
    }
}

using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APM.Repository
{
    public class IndexRepository : GenericRepository<IndexDto>, IIndexRepository
    {
        public IndexRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public IndexDto GetAdminIndex(int id, bool isAdmin)
        {
            var notifi = _context.Notifications.Where(n => (n.END_TIME >= DateTime.Now || n.END_TIME == null) && n.START_TIME <= DateTime.Now).Select(n => new NotificationDto { TEXT_INFO = n.TEXT_INFO }).ToList();

            var myActivity = GetMyActivity(id, DateTime.Now.Month, DateTime.Now.Year);

            var myProject = GetUserProjectActivity(id, DateTime.Now.Month, DateTime.Now.Year);

            var getIndex = new IndexDto { myProjectCount = myProject.Count(), MyProject = myProject };

            getIndex.myActivityCount = myActivity.Count();

            getIndex.Notification = notifi;

            if (isAdmin == true)
            {
                getIndex.projectCount = _context.Projects.Count();
                getIndex.employeeCount = _context.Employees.Count();
                getIndex.activityCount = _context.Activities.Count();
                getIndex.customerCount = _context.Customers.Count();
            }

            getIndex.wHours = GetSumActivityWhour(myActivity, DateTime.Now.Day, null);
            getIndex.projectWhour = GetSumProjectWhour(myProject);

            return getIndex;
        }

        public List<double> GetSumProjectWhour(List<ProjectDto> projects)
        {
            List<double> projectWhour = new List<double>();

            foreach (var item in projects)
            {
                var sumProjectWhour = item.ACTIVITIES.Select(a => a.WHOUR).Sum();

                projectWhour.Add(sumProjectWhour);
            }
            return projectWhour;
        }
        public double GetSumProjectWhour(ProjectDto projects, bool? invoice)
        {
            if (invoice == null)
                return projects.ACTIVITIES.Select(a => a.WHOUR).Sum();
            else
                return projects.ACTIVITIES.Where(a => a.INVOICE == invoice).Select(a => a.WHOUR).Sum();

        }

        public List<ProjectDto> GetUserProjectActivity(int id, int month, int year)
        {
            var projectID = GetUserProjectID(id);

            return _context.Projects.Where(p => projectID.Contains(p.ID)).Select(p => new ProjectDto
            {
                ID = p.ID,
                NAME = p.PROJECT_NAME,
                STATUS = p.PROJECT_STATUS,
                LEVEL = p.LEVEL,
                ACTIVITIES = p.ACTIVITIES.Where(a => a.ACTIVITY_DATE.Month == month && a.ACTIVITY_EMPLOYEE == id && a.ACTIVITY_DATE.Year == year).ToList(),
                CUSTOMER = p.CUSTOMER
            }).ToList();
        }

        private List<int> GetUserProjectID(int id)
        {
            return _context.ProjectEmployees.Where(pe => pe.EmployeeID == id).Select(p => p.ProjectID).ToList();
        }

        public List<ActivityDto> GetMyActivity(int id, int month, int year)
        {
            return _context.Activities.Where(a => a.ACTIVITY_EMPLOYEE == id && a.ACTIVITY_DATE.Month == month && a.ACTIVITY_DATE.Year == year).Select(a => new ActivityDto
            {
                ACTIVITY_DATE = a.ACTIVITY_DATE,
                ID = a.ID,
                WHOUR = a.WHOUR
            }).ToList();
        }

        public List<double> GetSumActivityWhour(List<ActivityDto> activities, int day, bool? invoice)
        {
            List<double> dailyWHour = new List<double>();

            for (int i = 1; i <= day; i++)
            {
                double sumWHour = 0;
                if (invoice == null)
                    sumWHour = activities.Where(a => a.ACTIVITY_DATE.Day == i).Select(a => a.WHOUR).Sum();
                else
                    sumWHour = activities.Where(a => a.ACTIVITY_DATE.Day == i && a.INVOICE == invoice).Select(a => a.WHOUR).Sum();

                dailyWHour.Add(sumWHour);
            }
            return dailyWHour;
        }
    }
}

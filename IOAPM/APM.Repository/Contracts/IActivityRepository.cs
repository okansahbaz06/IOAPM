using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Contracts
{
    public interface IActivityRepository : IGenericRepository<Activity>
    {
        ActivityAllDto GetDateRangeList(DateTime from, DateTime to);
        ActivityAllDto GetMonthList();
        void Create(ActivityDto activity);
        void Update(ActivityDto activity);
        void Delete(int id);
        ActivityAllDto GetMyActivity(int id);
        ActivityAllDto GetMyDateRangeActivity(int id, DateTime? from, DateTime? to);
        int GetLastActivityId();
        int FindEmployeeId(string fullName);
    }
}

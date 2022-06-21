using APM.Entities.Entities;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Contracts
{
    public interface IPublicHolidays : IGenericRepository<PublicHoliday>
    {
        string IsPublicHoliday(DateTime date);
        void loadPublicHolidays();
        List<string> GetMonthHolidays(int month, int year);
    }
}

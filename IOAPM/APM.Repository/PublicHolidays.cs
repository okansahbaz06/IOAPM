using Newtonsoft.Json;
using APM.Entities.Entities;
using APM.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace APM.Repository
{
    public class PublicHolidays : GenericRepository<PublicHoliday>, IPublicHolidays
    {
        public PublicHolidays(IUnitOfWork uow)
            : base(uow)
        {

        }
        private T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        private void RemoveAllItems()
        {
            _context.PublicHolidays.RemoveRange(_context.PublicHolidays);
        }
        private bool CheckNull()
        {
            var lastUpdate = _context.PublicHolidays.Where(ph => ph.lastUpdate.Month != DateTime.Now.Month).FirstOrDefault();

            if (lastUpdate == null)
                return false;
            else
                return true;
        }
        public void loadPublicHolidays()
        {
            if (!CheckNull())
            {
                RemoveAllItems();

                var url = "https://www.googleapis.com/calendar/v3/calendars/turkish__tr%40holiday.calendar.google.com/events?key=AIzaSyD1rK3TChqmNdL8C8m9qqGCqERuazM0Dmw";
                var holidays = _download_serialized_json_data<Holidays>(url);

                foreach (var item in holidays.items)
                {
                    _context.PublicHolidays.Add(new PublicHoliday
                    {
                        id = item.id,
                        htmlLink = item.htmlLink,
                        etag = item.etag,
                        end = DateTime.Parse(item.end.date),
                        start = DateTime.Parse(item.start.date),
                        created = item.created,
                        iCalUID = item.iCalUID,
                        kind = item.kind,
                        sequence = item.sequence,
                        status = item.status,
                        summary = item.summary,
                        transparency = item.transparency,
                        updated = item.updated,
                        visibility = item.visibility
                    });
                }
                _context.SaveChanges();
            }
        }
        public string IsPublicHoliday(DateTime date)
        {
            foreach (var item in _context.PublicHolidays)
            {
                var holidayDate = item.start;

                if (date.Date == holidayDate)
                    return item.summary;
            }
            return null;
        }

        public List<string> GetMonthHolidays(int month, int year)
        {
            if (!CheckNull())
                loadPublicHolidays();

            List<string> holidays = new List<string>();
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                DateTime date = new DateTime(year, month, i);

                var summary = IsPublicHoliday(date);

                holidays.Add(summary);
            }
            return holidays;
        }
    }
}

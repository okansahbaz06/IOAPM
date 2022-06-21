using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APM.Repository
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(IUnitOfWork uow) : base(uow)
        {

        }
        public List<NotificationDto> GetList()
        {
            return _context.Notifications.OrderBy(n => n.ID).Select(p => new NotificationDto { ID = p.ID, TEXT_INFO = p.TEXT_INFO, START_TIME = p.START_TIME, END_TIME = p.END_TIME }).ToList();
        }
        public NotificationDto Get(int id)
        {
            var notifi = _context.Notifications.FirstOrDefault(t => t.ID == id);
            return new NotificationDto { ID = notifi.ID, TEXT_INFO = notifi.TEXT_INFO, END_TIME = notifi.END_TIME, START_TIME = notifi.START_TIME };
        }
        public void Delete(int id)
        {
            var notifi = _context.Notifications.FirstOrDefault(n => n.ID == id);
            _context.Notifications.Remove(notifi);
            _context.SaveChanges();
        }

        public void Create(NotificationDto notifi)
        {
            _context.Notifications.Add(new Notification { ID = notifi.ID, TEXT_INFO = notifi.TEXT_INFO, END_TIME = notifi.END_TIME, START_TIME = notifi.START_TIME });
            _context.SaveChanges();
        }
        public void Update(NotificationDto notifi)
        {
            var update = _context.Notifications.FirstOrDefault(n => n.ID == notifi.ID);
            update.TEXT_INFO = notifi.TEXT_INFO;
            update.START_TIME = notifi.START_TIME;
            update.END_TIME = notifi.END_TIME;

            _context.Notifications.Update(update);
            _context.SaveChanges();
        }


    }
}

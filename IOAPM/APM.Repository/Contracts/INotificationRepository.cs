using APM.Entities.Entities;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Contracts
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        List<NotificationDto> GetList();
        NotificationDto Get(int id);
        void Delete(int id);
        void Create(NotificationDto notifi);
        void Update(NotificationDto notifi);
    }
}

using APM.Entities.Entities;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Contracts
{
    public interface IPriorityRepository : IGenericRepository<Priority>
    {
        List<ConstantDto> GetList();
        ConstantDto Get(int id);
        void DeletePriority(int id);
        void Create(ConstantDto priority);
        void Update(ConstantDto priority);
    }
}

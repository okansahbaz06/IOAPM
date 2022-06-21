using APM.Entities.Entities;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Contracts
{
    public interface ITitleRepository : IGenericRepository<Title>
    {
        ConstantDto Get(int id);

        List<ConstantDto> GetList();

        void DeleteTitle(int id);
        void Create(ConstantDto title);
        void Update(ConstantDto title);
    }
}

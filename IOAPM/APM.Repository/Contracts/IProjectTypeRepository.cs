using APM.Entities.Entities;
using APM.Repository.Dto;
using System.Collections.Generic;

namespace APM.Repository.Contracts
{
    public interface IProjectTypeRepository : IGenericRepository<Project_Type>
    {
        List<ConstantDto> GetList();
        ConstantDto Get(int id);
        void DeleteProjectType(int id);
        void Create(ConstantDto projectType);
        void Update(ConstantDto projectType);
    }
}

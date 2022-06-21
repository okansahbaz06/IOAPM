using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        ProjectAllDto GetList();
        void Create(ProjectDto project);
        void Delete(int id);
        void Update(ProjectDto project);
        ProjectAllDto GetMyProject(int id);
        bool checkIsHave(ProjectDto project);
    }
}

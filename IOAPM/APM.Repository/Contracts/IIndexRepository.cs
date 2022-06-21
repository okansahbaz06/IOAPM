using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Repository.Contracts
{
    public interface IIndexRepository : IGenericRepository<IndexDto>
    {
        IndexDto GetAdminIndex(int id, bool isAdmin);
        List<ProjectDto> GetUserProjectActivity(int id, int month, int year);
        List<ActivityDto> GetMyActivity(int id, int month, int year);
        List<double> GetSumActivityWhour(List<ActivityDto> activities, int day, bool? invoice);
        List<double> GetSumProjectWhour(List<ProjectDto> projects);
        double GetSumProjectWhour(ProjectDto projects, bool? invoice);
    }
}

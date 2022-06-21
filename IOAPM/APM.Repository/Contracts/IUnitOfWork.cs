using APM.Repository.Context;
using System;
using System.Threading.Tasks;

namespace APM.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        APMDbContext DbContext { get; }

        void SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

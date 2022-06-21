using APM.Repository.Context;
using APM.Repository.Contracts;
using System.Threading.Tasks;

namespace APM.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly APMDbContext _dbContext;

        public APMDbContext DbContext => _dbContext;

        public UnitOfWork(APMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {

        }
    }
}

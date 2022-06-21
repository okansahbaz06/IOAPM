using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APM.Repository.Contracts
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        IQueryable<TEntity> GetQuery<TProperty>(IEnumerable<Expression<Func<TEntity, TProperty>>> includeProperties, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        int Count(Expression<Func<TEntity, bool>> filter = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);

        bool Any(Expression<Func<TEntity, bool>> filter = null);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);

        void Insert(TEntity entity);

        void InsertRange(List<TEntity> entity);

        void Delete(Expression<Func<TEntity, bool>> filter);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        TEntity LastOrDefault(Expression<Func<TEntity, bool>> filter);

        IDbContextTransaction BeginTransaction();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using APM.Repository.Context;
using APM.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APM.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly APMDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        //private readonly IDbContextTransaction _dbContextTransaction;

        public GenericRepository(IUnitOfWork uow)
        {
            _context = uow.DbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }


            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;
        }

        public virtual IQueryable<TEntity> GetQuery<TProperty>(IEnumerable<Expression<Func<TEntity, TProperty>>> includeProperties, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                return query.Count(filter);
            }
            return query.Count();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                return query.CountAsync(filter);
            }
            return query.CountAsync();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                return query.Any(filter);
            }
            return query.Any();
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                return query.AnyAsync(filter);
            }
            return query.AnyAsync();
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;
            return query.SingleOrDefault(filter);
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;
            return await query.SingleOrDefaultAsync(filter);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;
            return query.FirstOrDefault(filter);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;
            return await query.FirstOrDefaultAsync(filter);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void InsertRange(List<TEntity> entity)
        {
            _dbSet.AddRange(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> filter)  //TODO: SOFT DELETE EKLENECEK
        {
            TEntity entityToDelete = _dbSet.SingleOrDefault(filter);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(TEntity entityToDelete) //TODO: SOFT DELETE EKLENECEK
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            //Handled by DI
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public virtual TEntity LastOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;
            return query.LastOrDefault(filter);
        }
    }
}

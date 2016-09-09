using Microsoft.EntityFrameworkCore;
using PureBlack.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PureBlack.Repository.EfCore
{
    public abstract class EntityStore<TEntity, TContext, TKey> : IEntityStore<TEntity>
        where TEntity : class
        where TContext : DbContext
        where TKey : IEquatable<TKey>
    {
        public EntityStore(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Context = context;
        }

        public TContext Context { get; }

        public IQueryable<TEntity> Entities => Context.Set<TEntity>();

        public async Task<GenericResult> CreateAsync(TEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return GenericResult.Success;
        }

        public async Task<GenericResult> UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return GenericResult.Success;
        }

        public async Task<GenericResult> DeleteAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return GenericResult.Success;
        }

        //public IQueryable<TEntity> Load()
        //{
        //    return Context.Set<TEntity>();
        //}

        //public IQueryable<TEntity> LoadAndInclude<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        //{
        //    return Context.Set<TEntity>().Include(navigationPropertyPath);
        //}

        public IQueryable<TEntity> Include<TProperty>(params Expression<Func<TEntity, TProperty>>[] funcSelectedProperties) where TProperty : class
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            foreach (var funcSelectedProperty in funcSelectedProperties)
            {
                query = query.Include(funcSelectedProperty);
            }

            return query;
        }

        //public IQueryable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, IComparable>>[] funcSelectedProperties)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);

        //    foreach (var funcSelectedProperty in funcSelectedProperties)
        //    {
        //        query.Include(funcSelectedProperty);
        //    }

        //    return query;
        //}
        #region IDisposable Support

        private bool _disposed = false;

        public void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}

using PureBlack.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PureBlack.Repository
{
    public class EntityManager<TEntityStore, TEntity>
        where TEntityStore : IEntityStore<TEntity>
        where TEntity : class
    {
        protected TEntityStore Store { get; set; }

        public IQueryable<TEntity> Entities => Store.Entities;

        public EntityManager(TEntityStore store)
        {
            Store = store;
        }

        public virtual async Task<GenericResult> CreateAsync(TEntity entity)
        {
            return await Store.CreateAsync(entity);
        }
        public virtual async Task<GenericResult> UpdateAsync(TEntity entity)
        {
            return await Store.UpdateAsync(entity);
        }

        public virtual async Task<GenericResult> DeleteAsync(TEntity entity)
        {
            return await Store.DeleteAsync(entity);
        }

        //public IQueryable<TEntity> Load()
        //{
        //    return Store.Load();
        //}

        //public IQueryable<TEntity> LoadAndInclude<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        //{
        //    return Store.LoadAndInclude(navigationPropertyPath);
        //}

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] funcSelectedProperties)
        {
            return Store.Include(funcSelectedProperties);
        }
    }
}

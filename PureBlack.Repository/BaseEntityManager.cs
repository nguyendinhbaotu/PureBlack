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

        public virtual async Task<GenericResult> CreateAsync(TEntity claim)
        {
            return await Store.CreateAsync(claim);
        }
        public virtual async Task<GenericResult> UpdateAsync(TEntity claim)
        {
            return await Store.UpdateAsync(claim);
        }

        public virtual async Task<GenericResult> DeleteAsync(TEntity claim)
        {
            return await Store.DeleteAsync(claim);
        }

        //public IQueryable<TEntity> Load()
        //{
        //    return Store.Load();
        //}

        //public IQueryable<TEntity> LoadAndInclude<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        //{
        //    return Store.LoadAndInclude(navigationPropertyPath);
        //}

        public IQueryable<TEntity> Include<TProperty>(params Expression<Func<TEntity, TProperty>>[] funcSelectedProperties) where TProperty : class
        {
            return Store.Include(funcSelectedProperties);
        }
    }
}

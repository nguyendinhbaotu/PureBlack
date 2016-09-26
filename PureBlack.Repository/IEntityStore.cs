using PureBlack.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PureBlack.Repository
{
    public interface IEntityStore<TEntity> : IDisposable
        where TEntity : class
    {
        //IQueryable<TEntity> Entities { get; }

        Task<GenericResult> CreateAsync(TEntity entity);

        Task<GenericResult> CreateAsync(IEnumerable<TEntity> entities);

        Task<GenericResult> UpdateAsync(TEntity entity);

        Task<GenericResult> UpdateAsync(IEnumerable<TEntity> entities);

        Task<GenericResult> DeleteAsync(TEntity entity);

        Task<GenericResult> DeleteAsync(IEnumerable<TEntity> entities);

        //IQueryable<TEntity> Load();

        //IQueryable<TEntity> LoadAndInclude<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);

        IQueryable<TEntity> Load();
        IQueryable<TEntity> LoadAndInclude(params Expression<Func<TEntity, object>>[] funcSelectedProperties);

        //IQueryable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, IComparable>>[] funcSelectedProperties);
    }
}

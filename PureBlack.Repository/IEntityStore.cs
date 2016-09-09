using PureBlack.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PureBlack.Repository
{
    public interface IEntityStore<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        Task<GenericResult> CreateAsync(TEntity entity);

        Task<GenericResult> UpdateAsync(TEntity entity);

        Task<GenericResult> DeleteAsync(TEntity entity);

        //IQueryable<TEntity> Load();

        //IQueryable<TEntity> LoadAndInclude<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);

        IQueryable<TEntity> Include<TProperty>(params Expression<Func<TEntity, TProperty>>[] funcSelectedProperties) where TProperty : class;

        //IQueryable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, IComparable>>[] funcSelectedProperties);
    }
}

using Repository.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.EntityFramework.Component
{
    public interface IEntityFrameworkRepository<TEntity, TDbContext>
    : IRepository<TEntity>
    {
        TDbContext dbContext { get; }
        Task<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> condition,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                           Expression<Func<TEntity, object>>[] includes = null);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> condition,
                 Expression<Func<TEntity, object>>[] includes = null);

    }
}

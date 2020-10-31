using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityFramework.Component
{
    public class EntityFrameworkRepository<TEntity, TDbContext>
       : IEntityFrameworkRepository<TEntity, TDbContext>
       where TEntity : class
       where TDbContext : DbContext
    {
        protected DbSet<TEntity> entity = null;
        public EntityFrameworkRepository(TDbContext dbContext)
        {
            this.dbContext = dbContext;
            entity = dbContext.Set<TEntity>();

        }

        public TDbContext dbContext { get; }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var ctx = dbContext)
            {
                await this.entity.AddAsync(entity);
                await this.dbContext.SaveChangesAsync();
                return entity;
            }


        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            using (var ctx = dbContext)
            {
                this.entity.Remove(entity);
                await this.dbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, object>>[] includes = null)
        {
            using (var ctx = dbContext)
            {


                IQueryable<TEntity> queryable = this.entity.AsQueryable();
                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        queryable = queryable.Include(include);
                    }

                }
                if (orderBy != null)
                {
                    queryable = orderBy(queryable);
                }

                queryable.Where(condition);

                return await queryable.ToListAsync();
            }
        }

        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, object>>[] includes = null)
        {
            using (var ctx = dbContext)
            {
                IQueryable<TEntity> queryable = this.entity.AsQueryable();
                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        queryable = queryable.Include(include);
                    }

                }
                queryable.Where(condition);

                return await queryable.FirstOrDefaultAsync(condition);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var ctx = dbContext)
            {
                return await this.entity.ToListAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            using (var ctx = dbContext)
            {
                return await this.entity.FindAsync(id);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var ctx = dbContext)
            {
                this.entity.Update(entity);
                await this.dbContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}

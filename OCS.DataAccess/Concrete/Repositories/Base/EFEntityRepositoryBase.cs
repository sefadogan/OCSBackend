using Microsoft.EntityFrameworkCore;
using OCS.DataAccess.Concrete.Repositories.Base;
using OCS.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.Utils.Data
{
    public class EFEntityRepositoryBase<TEntity, TContext,TKey> : IEFEntityRepositoryBase<TEntity, TKey>
          where TEntity : EntityBase<TKey>
          where TContext : DbContext
    {
        protected TContext Context { get; }

        public EFEntityRepositoryBase(TContext context) => Context = context;

        public DbContext GetCurrentContext() => Context;
        public DbSet<TEntity> GetEntity() => Context.Set<TEntity>();

        public virtual IQueryable<TEntity> Queryable(bool ignoreGlobalFilters = false) => ignoreGlobalFilters
            ? Context.Set<TEntity>().AsNoTracking().IgnoreQueryFilters()
            : Context.Set<TEntity>().AsNoTracking();

        public async Task<TEntity> GetById(TKey id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await GetEntity().AsQueryable().FirstOrDefaultAsync(expression);
        }
    }
}

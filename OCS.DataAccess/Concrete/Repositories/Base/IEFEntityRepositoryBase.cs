using Microsoft.EntityFrameworkCore;
using OCS.Entities.Abstract;
using System.Linq.Expressions;

namespace OCS.DataAccess.Concrete.Repositories.Base
{
    public interface IEFEntityRepositoryBase<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        DbContext GetCurrentContext();
        DbSet<TEntity> GetEntity();
        IQueryable<TEntity> Queryable(bool ignoreGlobalFilters = false);
        Task<TEntity> GetById(TKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}

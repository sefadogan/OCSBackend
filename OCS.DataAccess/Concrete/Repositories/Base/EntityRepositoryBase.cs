using Core.Utils.Data;
using OCS.DataAccess.Concrete.EntityFramework;
using OCS.Entities.Abstract;

namespace DataAccess.Concrete.Repository.Base;

public class EntityRepositoryBase<TEntity, TKey> : EFEntityRepositoryBase<TEntity, OCSDbContext, TKey>
    where TEntity : EntityBase<TKey>
{
    public EntityRepositoryBase(OCSDbContext context) : base(context)
    {
    }
}

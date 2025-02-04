using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCS.Entities.Abstract;

namespace OCS.DataAccess.Concrete.Configurations.Base;

public class EntityConfigurationBase<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityBase<TKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCS.DataAccess.Concrete.Configurations.Base;
using OCS.Entities.Concrete;

namespace OCS.DataAccess.Concrete.Configurations
{
    public class DistrictConfiguration : EntityConfigurationBase<District, int>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(d => d.Orders)
                .WithOne(o => o.District)
                .HasForeignKey(o => o.DistrictId);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OCS.DataAccess.Concrete.Configurations.Base;
using OCS.Entities.Concrete;
using OCS.DataAccess.Constants;

namespace OCS.DataAccess.Concrete.Configurations
{
    public class OrderConfiguration : EntityConfigurationBase<Order, long>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.OrderTrackingNo).IsRequired().HasMaxLength(50);
            builder.Property(o => o.ShipmentTrackingNo).HasMaxLength(50);
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.ReleasedForDistribution).IsRequired();
            builder.Property(o => o.CreatedDate)
                .IsRequired()
                .HasColumnType(MSSQLDbTypeConstants.Date)
                .HasDefaultValueSql(MSSQLDbConstants.SystemDateGetter);

            builder.HasOne(o => o.Customer)
               .WithMany()
               .HasForeignKey(o => o.CustomerId);
            builder.HasOne(o => o.District)
                .WithMany()
                .HasForeignKey(o => o.DistrictId);

            builder.HasIndex(o => o.OrderTrackingNo).IsUnique();
            builder.HasIndex(o => o.CreatedDate);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCS.DataAccess.Concrete.Configurations.Base;
using OCS.DataAccess.Constants;
using OCS.Entities.Concrete;
using static OCS.Entities.Constants.OrderConstants;

namespace OCS.DataAccess.Concrete.Configurations
{
    public class OrderConfiguration : EntityConfigurationBase<Order, long>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
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
               .WithMany(c => c.Orders)
               .HasForeignKey(o => o.CustomerId);
            builder.HasOne(o => o.District)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DistrictId);

            builder.HasIndex(o => o.OrderTrackingNo).IsUnique();
            builder.HasIndex(o => o.CreatedDate);

            builder.HasData(
                new Order { Id = 1, CustomerId = 1, DistrictId = 1, OrderTrackingNo = "OrderTrackingNo-1", ShipmentTrackingNo = "ShipmentTrackingNo-1", Status = OrderStatus.Delivered, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 4), IsDeleted = false },
                new Order { Id = 2, CustomerId = 2, DistrictId = 2, OrderTrackingNo = "OrderTrackingNo-2", ShipmentTrackingNo = "ShipmentTrackingNo-2", Status = OrderStatus.Waiting, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 4), IsDeleted = false });

            base.Configure(builder);
        }
    }
}

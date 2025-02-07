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
                new Order { Id = 1, CustomerId = 1, DistrictId = 1, OrderTrackingNo = "OT-1001", ShipmentTrackingNo = "ST-2001", Status = OrderStatus.Created, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 1), IsDeleted = false },
                new Order { Id = 2, CustomerId = 2, DistrictId = 2, OrderTrackingNo = "OT-1002", ShipmentTrackingNo = "ST-2002", Status = OrderStatus.Canceled, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 2), IsDeleted = false },
                new Order { Id = 3, CustomerId = 1, DistrictId = 1, OrderTrackingNo = "OT-1003", ShipmentTrackingNo = "ST-2003", Status = OrderStatus.Delivered, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 3), IsDeleted = false },
                new Order { Id = 4, CustomerId = 2, DistrictId = 2, OrderTrackingNo = "OT-1004", ShipmentTrackingNo = "ST-2004", Status = OrderStatus.Waiting, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 4), IsDeleted = false },
                new Order { Id = 5, CustomerId = 1, DistrictId = 1, OrderTrackingNo = "OT-1005", ShipmentTrackingNo = "ST-2005", Status = OrderStatus.NotDelivered, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 5), IsDeleted = false },
                new Order { Id = 6, CustomerId = 2, DistrictId = 2, OrderTrackingNo = "OT-1006", ShipmentTrackingNo = "ST-2006", Status = OrderStatus.Created, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 6), IsDeleted = false },
                new Order { Id = 7, CustomerId = 1, DistrictId = 1, OrderTrackingNo = "OT-1007", ShipmentTrackingNo = "ST-2007", Status = OrderStatus.Canceled, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 7), IsDeleted = false },
                new Order { Id = 8, CustomerId = 2, DistrictId = 2, OrderTrackingNo = "OT-1008", ShipmentTrackingNo = "ST-2008", Status = OrderStatus.Delivered, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 8), IsDeleted = false },
                new Order { Id = 9, CustomerId = 1, DistrictId = 1, OrderTrackingNo = "OT-1009", ShipmentTrackingNo = "ST-2009", Status = OrderStatus.Waiting, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 9), IsDeleted = false },
                new Order { Id = 10, CustomerId = 2, DistrictId = 2, OrderTrackingNo = "OT-1010", ShipmentTrackingNo = "ST-2010", Status = OrderStatus.NotDelivered, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 10), IsDeleted = false },
                new Order { Id = 11, CustomerId = 1, DistrictId = 1, OrderTrackingNo = "OT-1011", ShipmentTrackingNo = "ST-2011", Status = OrderStatus.Created, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 11), IsDeleted = false },
                new Order { Id = 12, CustomerId = 2, DistrictId = 1, OrderTrackingNo = "OT-1012", ShipmentTrackingNo = "ST-2012", Status = OrderStatus.Canceled, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 12), IsDeleted = false },
                new Order { Id = 13, CustomerId = 1, DistrictId = 2, OrderTrackingNo = "OT-1013", ShipmentTrackingNo = "ST-2013", Status = OrderStatus.Delivered, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 13), IsDeleted = false },
                new Order { Id = 14, CustomerId = 2, DistrictId = 1, OrderTrackingNo = "OT-1014", ShipmentTrackingNo = "ST-2014", Status = OrderStatus.Waiting, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 14), IsDeleted = false },
                new Order { Id = 15, CustomerId = 1, DistrictId = 2, OrderTrackingNo = "OT-1015", ShipmentTrackingNo = "ST-2015", Status = OrderStatus.NotDelivered, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 15), IsDeleted = false },
                new Order { Id = 16, CustomerId = 2, DistrictId = 1, OrderTrackingNo = "OT-1016", ShipmentTrackingNo = "ST-2016", Status = OrderStatus.Created, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 16), IsDeleted = false },
                new Order { Id = 17, CustomerId = 1, DistrictId = 2, OrderTrackingNo = "OT-1017", ShipmentTrackingNo = "ST-2017", Status = OrderStatus.Canceled, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 17), IsDeleted = false },
                new Order { Id = 18, CustomerId = 2, DistrictId = 1, OrderTrackingNo = "OT-1018", ShipmentTrackingNo = "ST-2018", Status = OrderStatus.Delivered, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 18), IsDeleted = false },
                new Order { Id = 19, CustomerId = 1, DistrictId = 1, OrderTrackingNo = "OT-1019", ShipmentTrackingNo = "ST-2019", Status = OrderStatus.Waiting, ReleasedForDistribution = true, CreatedDate = new DateTime(2025, 2, 19), IsDeleted = false },
                new Order { Id = 20, CustomerId = 2, DistrictId = 2, OrderTrackingNo = "OT-1020", ShipmentTrackingNo = "ST-2020", Status = OrderStatus.NotDelivered, ReleasedForDistribution = false, CreatedDate = new DateTime(2025, 2, 20), IsDeleted = false }
            );

            base.Configure(builder);
        }
    }
}

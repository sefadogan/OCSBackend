using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCS.DataAccess.Concrete.Configurations.Base;
using OCS.Entities.Concrete;

namespace OCS.DataAccess.Concrete.Configurations
{
    public class CustomerConfiguration : EntityConfigurationBase<Customer, int>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}

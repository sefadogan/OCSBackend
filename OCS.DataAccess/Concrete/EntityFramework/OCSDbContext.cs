using Microsoft.EntityFrameworkCore;
using OCS.Entities.Concrete;

namespace OCS.DataAccess.Concrete.EntityFramework
{
    public class OCSDbContext : DbContext
    {
        public OCSDbContext(DbContextOptions<OCSDbContext> options) : base(options) { }

        #region DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Order> Orders { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OCSDbContext).Assembly);

            modelBuilder.Model.GetEntityTypes()
                .Where(x => !x.IsOwned())
                .SelectMany(x => x.GetForeignKeys())
                .ToList()
                .ForEach(x => x.DeleteBehavior = DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}

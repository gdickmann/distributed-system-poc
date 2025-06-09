using Crud.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud.Database
{
    public class CrudContext : DbContext
    {
        public DbSet<Carrier> Carriers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductKind> ProductKinds { get; set; } = null!;
        public DbSet<Recipient> Recipients { get; set; } = null!;
        public DbSet<Entities.Route> Routes { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string host = "localhost";
#if !DEBUG
            host = "postgres";
#endif
            optionsBuilder.UseNpgsql($"Host={host};Username=postgres;Password=postgres;Database=a3"); // usually we should get these from a KV
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasOne(x => x.Vehicle)
                .WithOne(x => x.Driver);

            modelBuilder.Entity<Driver>()
                .HasOne(x => x.Carrier)
                .WithOne(x => x.Driver);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.ProductKind)
                .WithOne(x => x.Product);

            modelBuilder.Entity<Entities.Route>()
                .HasOne(x => x.Driver)
                .WithOne(x => x.Route);

            modelBuilder.Entity<Entities.Route>()
                .HasOne(x => x.Customer)
                .WithOne(x => x.Route);

            modelBuilder.Entity<Entities.Route>()
                .HasOne(x => x.Recipient)
                .WithOne(x => x.Route);

            modelBuilder.Entity<Entities.Route>()
                .HasOne(x => x.Product)
                .WithOne(x => x.Route);
        }
    }
}

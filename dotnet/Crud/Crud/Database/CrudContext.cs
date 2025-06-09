using Crud.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud.Database
{
    public class CrudContext : DbContext
    {
        public DbSet<Carrier> Carriers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string host = "localhost";
#if !DEBUG
            host = "postgres";
#endif
            optionsBuilder.UseNpgsql($"Host={host};Username=postgres;Password=postgres;Database=a3"); // usually we should get these from a KV
        }
    }
}

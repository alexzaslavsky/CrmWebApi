using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CrmWebApi.Domain.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}

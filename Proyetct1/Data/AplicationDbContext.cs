using Microsoft.EntityFrameworkCore;
using Proyetct1.Models;

namespace Proyetct1.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Routers", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Planes", DisplayOrder = 2 },
                new Category { Id = 3, Name = "FibraOptica", DisplayOrder = 3 }
                );
        }

    }
}

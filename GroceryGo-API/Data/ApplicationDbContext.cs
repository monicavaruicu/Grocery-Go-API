using GroceryGo_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroceryGo_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
    }
}

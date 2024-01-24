using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

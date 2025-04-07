using Microsoft.EntityFrameworkCore;
using Riid.Models;

namespace Riid.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> User { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
    }
}

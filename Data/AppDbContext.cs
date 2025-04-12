using Microsoft.EntityFrameworkCore;
using Riid.Models;

namespace Riid.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> User { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<AuthorModel> Author { get; set; }
        public DbSet<BookModel> Book { get; set; }
        public DbSet<BookPdfModel> BookPdf { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>()
            .HasOne(c => c.Category)
            .WithMany(b => b.Books)
            .HasForeignKey(c => c.Fk_category);

            modelBuilder.Entity<BookModel>()
            .HasOne(a => a.Author)
            .WithMany(b => b.Books)
            .HasForeignKey(a => a.Fk_author);

            modelBuilder.Entity<BookPdfModel>()
            .HasOne(b => b.Book)
            .WithMany(bp => bp.BookPdfs)
            .HasForeignKey(b => b.Fk_book);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Riid.Models;

namespace Riid.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<AuthorModel> Author { get; set; }
        public DbSet<BookModel> Book { get; set; }
        public DbSet<BookPdfModel> BookPdf { get; set; }
        public DbSet<LoanModel> Loan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Importante para Identity funcionar

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

            modelBuilder.Entity<LoanModel>()
                .HasOne(u => u.User)
                .WithMany(l => l.Loans)
                .HasForeignKey(u => u.Fk_user);

            modelBuilder.Entity<LoanModel>()
                .HasOne(bp => bp.BookPdf)
                .WithMany(l => l.Loans)
                .HasForeignKey(bp => bp.Fk_book_pdf);
        }
    }
}

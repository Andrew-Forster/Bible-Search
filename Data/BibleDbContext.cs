using Bible_Search.Models;
using Microsoft.EntityFrameworkCore;

namespace Bible_Search.Data
{
    public class BibleDbContext : DbContext
    {
        public BibleDbContext(DbContextOptions<BibleDbContext> options) : base(options) { }

        // Define DbSets for the tables
        public DbSet<BibleBook> BibleBooks { get; set; }
        public DbSet<BibleVerse> BibleVerses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BibleBook>().ToTable("kjv_books");
            modelBuilder.Entity<BibleVerse>().ToTable("kjv_verses");
            
            modelBuilder.Entity<BibleVerse>()
                .HasOne(v => v.Book)
                .WithMany(b => b.Verses)
                .HasForeignKey(v => v.BookId);
        }
    }
}
using HomeTaskTo02._19.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo02._19.Data.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("tblBook");
            modelBuilder.Entity<Student>().ToTable("tblStudent");
        }
    }
}

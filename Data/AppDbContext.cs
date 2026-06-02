using Microsoft.EntityFrameworkCore;
using DatabaseTutorials.Entities;

namespace DatabaseTutorials.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Department>? Departments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Username)
                .IsUnique();

            modelBuilder.Entity<Student>().Property(s =>s.Username).IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.PasswordHash).IsRequired();
            modelBuilder.Entity<Student>().Property(s=>s.Role).HasDefaultValue("Student").IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using DatabaseTutorials.Entities;

namespace DatabaseTutorials.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }
    }
}
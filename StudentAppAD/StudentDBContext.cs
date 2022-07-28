using Microsoft.EntityFrameworkCore;
using StudentAppAD.Entity;

namespace StudentAppAD
{
    public class StudentDBContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option) =>
            option.UseSqlServer($"Server=localhost;Database=StudentAppAD;Trusted_Connection=True;");
    }
}

using Microsoft.EntityFrameworkCore;
using StudentAppAD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

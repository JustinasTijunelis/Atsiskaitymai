using InvoiceDB.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class InvoiceDBContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tax> Taxs { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder option) =>
        //    option.UseSqlServer($"Server=tcp:kmsqlserver2.database.windows.net,1433;Initial Catalog=DBNi;Persist Security Info=False;User ID=kmsqlserver2;Password=Justinas123//;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        protected override void OnConfiguring(DbContextOptionsBuilder option) =>
           option.UseSqlServer($"Server=localhost;Database=InvoiceDB;Trusted_Connection=True;");
    }
}

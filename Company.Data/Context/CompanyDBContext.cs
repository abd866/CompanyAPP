using Company.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Context
{
    public class CompanyDBContext:IdentityDbContext<ApplicationUser>
    {
        public CompanyDBContext()
        {
            
        }
        public CompanyDBContext(DbContextOptions<CompanyDBContext> options):base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.IsDleted);
            modelBuilder.Entity<Department>().HasQueryFilter(x => !x.IsDleted);

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}

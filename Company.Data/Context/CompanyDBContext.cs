﻿using Company.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Context
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext(DbContextOptions<CompanyDBContext> options):base(options)
        {
            
        }
      
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}

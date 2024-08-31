using Company.Data.Context;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repository
{
    public class EmployeeReposoitory:GenericRepository<Employee>, IEmployeeRepository
    {
        private CompanyDBContext _context;
        public EmployeeReposoitory(CompanyDBContext context):base(context)
        {
            _context = context;
        }

        
    }
}

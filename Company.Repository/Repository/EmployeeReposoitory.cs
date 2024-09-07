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

        public IEnumerable<Employee> GetEmployeeByName(string name)
        => _context.Employees.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();
        

        public IEnumerable<Employee> GetEmployeesByAdress(string adress)
        {
            throw new NotImplementedException();
        }
    }
}

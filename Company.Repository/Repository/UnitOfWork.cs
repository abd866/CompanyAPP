using Company.Data.Context;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDBContext _context;
        public UnitOfWork(CompanyDBContext context)
        {
            _context = context;
            departmentRepsoitory =new DepartmentReposoitory(context);
            employeeRepository =new EmployeeReposoitory(context);
        }
        public IDepartmentRepsoitory departmentRepsoitory { get ; set ; }
        public IEmployeeRepository employeeRepository { get; set; }
        public CompanyDBContext Context { get; }

        public int complate()
        {
            return _context.SaveChanges();
        }
    }
}

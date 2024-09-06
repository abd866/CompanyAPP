using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentRepsoitory departmentRepsoitory { get; set; }
        public IEmployeeRepository employeeRepository { get; set; }
        int complate();
    }
}

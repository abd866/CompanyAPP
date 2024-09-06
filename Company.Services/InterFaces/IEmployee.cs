using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.InterFaces
{
    public interface IEmployee
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAll();
        void Delete(Employee Entity);
        void Update(Employee Entity);
        void Create(Employee Entity);
    }
}

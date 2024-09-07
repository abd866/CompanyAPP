using Company.Data.Models;
using Company.Service.InterFaces.Employee.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.InterFaces
{
    public interface IEmployee
    {
        EmployeeDTO GetEmployee(int id);
        IEnumerable<EmployeeDTO> GetAll();
        void Delete(EmployeeDTO Entity);
        void Update(EmployeeDTO Entity);
        void Create(EmployeeDTO Entity);
        IEnumerable<EmployeeDTO> GetEmployeeByName(string name);
    }
}

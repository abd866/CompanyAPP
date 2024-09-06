using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.InterFaces
{
    public interface IDepartment
    {
        Department GetEmployee(int id);
        IEnumerable<Department> GetAll();
        void Delete(Department Entity);
        void Update(Department Entity);
        void Create(Department Entity);
    }
}

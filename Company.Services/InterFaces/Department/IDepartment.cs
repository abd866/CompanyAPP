using Company.Data.Models;
using Company.Service.InterFaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.InterFaces
{
    public interface IDepartment
    {
        DepartmentDTO GetEmployee(int id);
        IEnumerable<DepartmentDTO> GetAll();
        void Delete(DepartmentDTO Entity);
        void Update(DepartmentDTO Entity);
        void Create(DepartmentDTO Entity);
    }
}

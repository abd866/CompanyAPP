using Company.Data.Models;
using Company.Service.InterFaces.Employee.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.InterFaces.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int code { get; set; }
        public DateTime CreateAT { get; set; }
        public ICollection<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
    }
}

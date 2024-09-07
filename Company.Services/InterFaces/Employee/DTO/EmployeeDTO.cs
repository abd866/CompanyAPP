using Company.Data.Models;
using Company.Service.InterFaces.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.InterFaces.Employee.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAT { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public decimal? salary { get; set; }
        public string? Email { get; set; }
        public string? PhineNumber { get; set; }
        public DateTime HiringDate { get; set; }

        public IFormFile File { get; set; }
        public string? ImageUrl { get; set; }
        public DepartmentDTO Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}

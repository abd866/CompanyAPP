using AutoMapper;
using Company.Service.InterFaces.Employee.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;

namespace Company.Service.Mapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeDTO>().ReverseMap();
        }
    }
}

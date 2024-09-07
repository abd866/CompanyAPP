using AutoMapper;
using Company.Service.InterFaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
namespace Company.Service.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department,DepartmentDTO>().ReverseMap(); 
        }
    }
}

using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.InterFaces;
using Company.Service.InterFaces.DTO;
using Company.Service.InterFaces.Employee.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public void Create(DepartmentDTO employeeDTO)
        {
            Department department = _mapper.Map<Department>(employeeDTO);
            _UnitOfWork.departmentRepsoitory.Create(department);
            _UnitOfWork.complate();

        }

        public void Delete(DepartmentDTO employeeDTO)
        {
            Department department = _mapper.Map<Department>(employeeDTO);

            _UnitOfWork.departmentRepsoitory.Delete(department);
            _UnitOfWork.complate();
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
             var depaertmentS = _UnitOfWork.departmentRepsoitory.GetAll();
          IEnumerable<DepartmentDTO> MappeddepaertmentS = _mapper.Map<IEnumerable<DepartmentDTO>>(depaertmentS);

            return MappeddepaertmentS;
        }

        public DepartmentDTO GetEmployee(int id)
        {
            var department=_UnitOfWork.departmentRepsoitory.GetEmployee(id);
            DepartmentDTO Mappeddepaertment = _mapper.Map<DepartmentDTO>(department);

            return Mappeddepaertment;
        }

        public void Update(DepartmentDTO Entity)
        {
            Department department = _mapper.Map<Department>(Entity);

            _UnitOfWork.departmentRepsoitory.Update(department);
            _UnitOfWork.complate();
        }
    }
}

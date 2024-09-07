using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Repository.Repository;
using Company.Service.Helper;
using Company.Service.InterFaces;
using Company.Service.InterFaces.Employee.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeServices:IEmployee
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public EmployeeServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public void Create(EmployeeDTO Entity)
        {
            Entity.ImageUrl = DocumentPath.UploadFile(Entity.File, "Images");
            Employee employee = _mapper.Map<Employee>(Entity);

            _UnitOfWork.employeeRepository.Create(employee);
            _UnitOfWork.complate();
        }

        public void Delete(EmployeeDTO Entity)
        {
            Employee employee = _mapper.Map<Employee>(Entity);
            _UnitOfWork.employeeRepository.Delete(employee);
            _UnitOfWork.complate();
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = _UnitOfWork.employeeRepository.GetAll();
            IEnumerable<EmployeeDTO> mappedEmp = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return mappedEmp;
        }

        public EmployeeDTO GetEmployee(int id)
        {
            var employee = _UnitOfWork.employeeRepository.GetEmployee(id);
            EmployeeDTO mappedEmp = _mapper.Map<EmployeeDTO>(employee);
            return mappedEmp;
        }

        public IEnumerable<EmployeeDTO> GetEmployeeByName(string name)
        {
            var employee = _UnitOfWork.employeeRepository.GetEmployeeByName(name);
            IEnumerable<EmployeeDTO> mappedEmp = _mapper.Map<IEnumerable<EmployeeDTO>>(employee);

            return mappedEmp;
        }

        public void Update(EmployeeDTO Entity)
        {
            Employee employee = _mapper.Map<Employee>(Entity);

            _UnitOfWork.employeeRepository.Update(employee);
            _UnitOfWork.complate();
        }

       
    }
}

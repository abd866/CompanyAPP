using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Repository.Repository;
using Company.Service.InterFaces;
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

        public EmployeeServices(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public void Create(Employee Entity)
        {
            _UnitOfWork.employeeRepository.Create(Entity);
            _UnitOfWork.complate();
        }

        public void Delete(Employee Entity)
        {
            _UnitOfWork.employeeRepository.Delete(Entity);
            _UnitOfWork.complate();
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _UnitOfWork.employeeRepository.GetAll();
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            var employee = _UnitOfWork.employeeRepository.GetEmployee(id);
            return employee;
        }

        public void Update(Employee Entity)
        {
            _UnitOfWork.employeeRepository.Update(Entity);
            _UnitOfWork.complate();
        }

       
    }
}

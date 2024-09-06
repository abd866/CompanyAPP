using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.InterFaces;
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

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public void Create(Department Entity)
        {
            _UnitOfWork.departmentRepsoitory.Create(Entity);
            _UnitOfWork.complate();

        }

        public void Delete(Department Entity)
        {
            _UnitOfWork.departmentRepsoitory.Delete(Entity);
            _UnitOfWork.complate();
        }

        public IEnumerable<Department> GetAll()
        {
             var depaertment = _UnitOfWork.departmentRepsoitory.GetAll();
            return depaertment;
        }

        public Department GetEmployee(int id)
        {
            var department=_UnitOfWork.departmentRepsoitory.GetEmployee(id);
            return department;
        }

        public void Update(Department Entity)
        {
            _UnitOfWork.departmentRepsoitory.Update(Entity);
            _UnitOfWork.complate();
        }
    }
}

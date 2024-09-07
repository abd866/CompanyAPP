using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.InterFaces;
using Company.Service.InterFaces.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment departmentRepsoitory)
        {
            _department = departmentRepsoitory;
        }

        public IActionResult Index()
        {
            var department= _department.GetAll();
            return View(department);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO department )
        {
           if (ModelState.IsValid)
            {
                _department.Create(department);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }   
        }

        public IActionResult Detalis(int Id)
        {
            var department=_department.GetEmployee(Id);
            return View(department);

        }
        public IActionResult Update(int Id)
        {
            var department=_department.GetEmployee(Id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Update(DepartmentDTO department)
        {
            _department.Update(department);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var department=_department.GetEmployee(Id);
            _department.Delete(department);
            return RedirectToAction("Index");

        }
    }
}

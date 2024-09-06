using Company.Data.Context;
using Company.Data.Models;
using Company.Service.InterFaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        private readonly IDepartment _department;
        private readonly CompanyDBContext _context;

        public EmployeeController(IEmployee employee, IDepartment department, CompanyDBContext context)
        {
            _employee = employee;
            _department = department;
            _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.Employees
                                                      .Include(e => e.Department)
                                                       .ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            var  departments = _department.GetAll();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            
                _employee.Create(employee);
                return RedirectToAction("Index");
            
            
        }
        public IActionResult Detalis(int Id)
        {
            var employee = _context.Employees
                              .Include(e => e.Department)
                              .FirstOrDefault(e => e.Id == Id);
            return View(employee);

        }
        public IActionResult Update(int Id)
        {
            var employee = _employee.GetEmployee(Id);
            var departments = _department.GetAll();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", employee.DepartmentId);

            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _employee.Update(employee);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var employee = _employee.GetEmployee(Id);
            _employee.Delete(employee);
            return RedirectToAction("Index");

        }
    }
}

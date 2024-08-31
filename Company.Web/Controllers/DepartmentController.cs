using Company.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepsoitory _departmentRepsoitory;

        public DepartmentController(IDepartmentRepsoitory departmentRepsoitory)
        {
            _departmentRepsoitory = departmentRepsoitory;
        }

        public IActionResult Index()
        {
            var department=_departmentRepsoitory.GetAll();
            return View(department);
        }
    }
}

using Company.Data.Models;
using Company.Service.InterFaces;
using Company.Service.InterFaces.Employee.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Company.Web.Controllers
{
   
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string searchInput)
        {
            List<ApplicationUser> users;
            if (string.IsNullOrEmpty(searchInput))
                users = await _userManager.Users.ToListAsync();
            else
                users = await _userManager.Users
                    .Where(user => user.NormalizedUserName.Trim().Contains(searchInput.Trim().ToUpper()))
                    .ToListAsync();
                return View(users);
        }
        public async  Task<IActionResult> Detalis(string Id)
        {
            var User =await  _userManager.FindByIdAsync(Id);
            return View(User);

        }

        public async Task<IActionResult> Update(string Id)
        {
            var User = await _userManager.FindByIdAsync(Id);
            return View(User);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ApplicationUser User)
        {
            var Old = await _userManager.FindByIdAsync(User.Id);
            if (Old != null)
            {
                Old.UserName = User.UserName;
                Old.Email = User.Email;
                 await _userManager.UpdateAsync(Old);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string Id)
        {
            var user =await _userManager.FindByIdAsync(Id);
                 await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");

        }
    }
}

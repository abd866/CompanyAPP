using Company.Data.Models;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>SignUP(SignUpViewModel input)
        {
            if (ModelState.IsValid) {
                var user = new ApplicationUser
                {
                    UserName = input.Email.Split("@")[0],
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true
                };
                var ruslut= await _userManager.CreateAsync(user,input.Password);
                if (ruslut.Succeeded) 
                    return RedirectToAction("SignIn");
                foreach(var error in ruslut.Errors) 
                    ModelState.AddModelError("",error.Description);
            
            }
            return View(input);
        }
    }
}

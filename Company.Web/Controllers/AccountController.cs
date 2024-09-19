using Company.Data.Models;
using Company.Service.Helper;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region SignUP
        [HttpGet]
        public IActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUP(SignUpViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = input.Email.Split("@")[0],
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true
                };
                var ruslut = await _userManager.CreateAsync(user, input.Password);
                if (ruslut.Succeeded)
                    return RedirectToAction("Login");
                foreach (var error in ruslut.Errors)
                    ModelState.AddModelError("", error.Description);

            }
            return View(input);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user= await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    if(await _userManager.CheckPasswordAsync(user, input.Password))
                    {
                        var ruslt= await _signInManager.PasswordSignInAsync(user, input.Password,input.RemberMe,true);
                        if (ruslt.Succeeded)
                            return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Incorect Email Or Password");
                return View(input);
            }
            return View(input);
        }
        #endregion

        #region signOut
         public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(FogetPaswordViewModel input)
        {
            if (ModelState.IsValid) 
            {

                var user = await _userManager.FindByEmailAsync(input.Email);
                if(user is not null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ResetPassword", "Account", new {Email=input.Email,Token=token},Request.Scheme);

                    var email = new Email
                    {
                        Body = url,
                        Supject = "Reset Password",
                        to = input.Email
                    };
                    SendEmail.sendEmail(email);
                    return RedirectToAction("checkYorInpox");
                }
            
            }
            return View(input);
        }

        public IActionResult checkYorInpox()
        {
            return View();
        }
        #endregion
        #region ResetPasswor
        [HttpGet]
        public IActionResult ResetPassword( string Email, string Token )
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel input)
        {
            if (ModelState.IsValid) 
            {
                var user =await _userManager.FindByEmailAsync(input.Email);
              if (user is not null)
                {
                    var ruslt =await  _userManager.ResetPasswordAsync(user, input.Token, input.Password);
                    if (ruslt.Succeeded)
                        return RedirectToAction("Login");
                    foreach(var errror in ruslt.Errors)
                        ModelState.AddModelError("",errror.Description);
                }
            
            }
            return View(input);
        }
        #endregion
    }
}

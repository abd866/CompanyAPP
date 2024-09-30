using Company.Data.Models;
using Company.Service.InterFaces.DTO;
using Company.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var role = await _roleManager.Roles.ToListAsync();
            return View(role);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var ruslut = await _roleManager.CreateAsync(role);
                if (ruslut.Succeeded)
                    return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            return View();
        }

        public async Task<IActionResult> Detalis(string Id)
        {
            var User = await _roleManager.FindByIdAsync(Id);
            return View(User);

        }

        public async Task<IActionResult> Update(string Id)
        {
            var Role = await _roleManager.FindByIdAsync(Id);
            return View(Role);
        }
        [HttpPost]
        public async Task<IActionResult> Update(IdentityRole Role)
        {
            var Old = await _roleManager.FindByIdAsync(Role.Id);
            if (Old != null)
            {
                Old.Name = Role.Name;
                Old.NormalizedName = Role.NormalizedName;
                await _roleManager.UpdateAsync(Old);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _roleManager.FindByIdAsync(Id);
            await _roleManager.DeleteAsync(user);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> AddOrRemoveUser(string RoleId)
        {
            ViewBag.RoleId = RoleId;
            var role = await _roleManager.FindByIdAsync(RoleId);
            if (role == null)
                return NotFound();
            var users = await _userManager.Users.ToListAsync();
            var usersInrole = new List<UserInRoleViewModel>();
            foreach (var user in users)
            {

                var userInRole = new UserInRoleViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    userInRole.IsSlected = true;
                else
                    userInRole.IsSlected = false;

                usersInrole.Add(userInRole);
            }
            return View(usersInrole);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUser(string RoleId, List<UserInRoleViewModel> users)
        {
            var role = await _roleManager.FindByIdAsync(RoleId);
            if (role == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                foreach (var user in users)
                {
                    var appUser = await _userManager.FindByIdAsync(user.Id);
                    if (appUser is not null)
                    {
                        if (user.IsSlected && !await _userManager.IsInRoleAsync(appUser, role.Name))
                            await _userManager.AddToRoleAsync(appUser, role.Name);
                        else if (!user.IsSlected && await _userManager.IsInRoleAsync(appUser, role.Name))
                            await _userManager.RemoveFromRoleAsync(appUser, role.Name);

                    }


                }
                return RedirectToAction("Update", new { id = role.Id });

            }
            return View(users);
        }
    }
}
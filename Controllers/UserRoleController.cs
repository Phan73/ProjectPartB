using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPartB.Areas.Identity.Data;
using ProjectPartB.Models;
using System.Data;

namespace ProjectPartB.Controllers
{

    //[Authorize(Roles = "Administrator")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<WebUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole model)
        {
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [Authorize(Roles = "Administrator")]
        // Create a new role
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();

            }

            var model = new EditRoleViewModel { RoleId = role.Id, RoleName = role.Name };
            return View(model);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);

                if (role == null)
                {
                    return NotFound();
                }

                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        // Delete a role
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return RedirectToAction("Index");
        }

        // Users CRUD

        // View all users
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.ToListAsync();
            var model = new List<AssignRoleViewModel>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var identityRoles = userRoles.Select(role => new IdentityRole { Name = role });


                var userWithRoles = new AssignRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Roles = identityRoles
                };

                model.Add(userWithRoles);
            }

            return View(model);
        }
        [Authorize(Roles = "Administrator")]
        // Assign user to a different role
        [HttpGet]
        public async Task<IActionResult> AssignRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new AssignRoleViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = await _roleManager.Roles.ToListAsync()

            };

            return View(model);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                ModelState.AddModelError("", "Role not found.");
                model.Roles = await _roleManager.Roles.ToListAsync();
                return View(model);
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction("Users");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }


            model.Roles = await _roleManager.Roles.ToListAsync();
            return View(model);
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> UpdateRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new AssignRoleViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = _roleManager.Roles,
                RoleId = userRoles.FirstOrDefault(),
                RoleName = userRoles.FirstOrDefault()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(AssignRoleViewModel model)
        {

            var user = await _userManager.FindByIdAsync(model.UserId);
            var currentRole = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRoleAsync(user, currentRole.FirstOrDefault());

            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, model.RoleName);

                if (result.Succeeded)
                {
                    return RedirectToAction("Users");
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }


            model.Roles = _roleManager.Roles;
            return View(model);
        }


        // Other user CRUD operations: Create, Update, Delete
        // ... (Implement these methods based on your requirements)
        
    }
}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPartB.Areas.Identity.Data;
using ProjectPartB.Models;
using System.Data;

namespace ProjectPartB.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<WebUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserRoles/Edit/5
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var model = new EditUserRolesViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                Roles = new List<UserRoleViewModel>()
            };

            foreach (var role in _roleManager.Roles)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                };

                model.Roles.Add(userRoleViewModel);
            }

            return View(model);
        }

        // POST: UserRoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
                return View("NotFound");
            }
            else
            {
                var roles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, roles);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user existing roles");
                    return View(model);
                }

                result = await _userManager.AddToRolesAsync(user, model.Roles.Where(x => x.IsSelected).Select(y => y.RoleName));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected roles to user");
                    return View(model);
                }

                return RedirectToAction("Index");
            }
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPartB.Areas.Identity.Data;
using ProjectPartB.Models;

namespace ProjectPartB.Controllers
{
    public class CartController : Controller
    {
        private readonly FS23_Group4_ProjectContext _context;

        private readonly UserManager<WebUser> _userManager;
        public CartController(FS23_Group4_ProjectContext context, UserManager<WebUser> userManager)
        {
            _context = context;

            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string userId)
        {
            var users = await _userManager.Users.ToListAsync(); // Retrieves all users
            var userCarts = new List<UserCartViewModel>(); // This will hold the data we want to pass to the view

            foreach (var user in users)
            {
                var cartItems = await _context.CartItems
                                              .Include(ci => ci.Car)
                                              .Where(ci => ci.AspNetUserId == user.Id)
                                              .Select(ci => new CartDetailsViewModel
                                              {
                                                  CarId = ci.Car.CarDescriptionId,
                                                  Quantity = ci.Quantity,
                                                  RentalDuration = ci.RentalDuration,
                                                  StartDate = ci.StartDate
                                              }).ToListAsync();

                userCarts.Add(new UserCartViewModel
                {
                    DriverLicense = user.DrivingLicense,
                    FullName = user.FullName,
                    CartItems = cartItems
                });
            }

            return View(userCarts); // Pass the list of user carts to the view

        }
    }
}

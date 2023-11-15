using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPartB.Models;
using System.Data;

namespace ProjectPartB.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly FS23_Group4_ProjectContext _context;
        public ShoppingCartController(FS23_Group4_ProjectContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Visitor,Administrator,Editor")]
        public IActionResult Index()
        {
            var cartItems =  GetCartItems();
            return View(cartItems);

        }
        [Authorize(Roles = "Visitor,Administrator,Editor")]
        public IActionResult AddToCart(int Id)
        {
            var car = _context.CarDescriptions.FirstOrDefault(p => p.CarDescriptionId == Id);
            if (car != null)
            {
                var cartItems = GetCartItems();
                var cartItem = cartItems.FirstOrDefault(item => item.Car.CarDescriptionId == Id);
                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    cartItems.Add(new CartItem { Car = car , Quantity=1});
                }
                SaveCartItems(cartItems); // Update your cart in the session
            }
           return RedirectToAction("Index");
        }
        [Authorize(Roles = "Visitor,Administrator,Editor")]
        public IActionResult RemoveFromCart(int productId) 
        {
            var cartItems = GetCartItems();
            var cartItem = cartItems.FirstOrDefault(item => item.Car.CarDescriptionId == productId);
            if (cartItem != null)
            {
                if(cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cartItems.Remove(cartItem);
                }
            }
            SaveCartItems(cartItems);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Visitor,Administrator,Editor")]
        public IActionResult ClearCart()
        {
            SaveCartItems(new List<CartItem>());
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Visitor,Administrator,Editor")]
        private List<CartItem> GetCartItems()
        {
            var cartItems = HttpContext.Session.Get<List<CartItem>>("CartItems");
            if (cartItems == null)
            {
                cartItems = new List<CartItem>();
            }
            return cartItems;
        }
        private void SaveCartItems(List<CartItem> cartItems)
        {
            HttpContext.Session.Set("CartItems", cartItems); // Update your cart in the session

        }
    }
}

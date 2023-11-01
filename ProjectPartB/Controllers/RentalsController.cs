using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectPartB.Models;

namespace ProjectPartB.Controllers
{
    public class RentalsController : Controller
    {
        private readonly FS23_Group4_ProjectContext _context;

        public RentalsController(FS23_Group4_ProjectContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var fS23_Group4_ProjectContext = _context.Rentals.Include(r => r.CarDescription).Include(r => r.User);
            return View(await fS23_Group4_ProjectContext.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.CarDescription)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["CarDescriptionId"] = new SelectList(_context.CarDescriptions, "CarDescriptionId", "CarDescriptionId");
            ViewData["UserId"] = new SelectList(_context.UserDescriptions, "UserId", "UserId");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalId,CarDescriptionId,UserId,StartDate,EndDate,TotalCost")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarDescriptionId"] = new SelectList(_context.CarDescriptions, "CarDescriptionId", "CarDescriptionId", rental.CarDescriptionId);
            ViewData["UserId"] = new SelectList(_context.UserDescriptions, "UserId", "UserId", rental.UserId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["CarDescriptionId"] = new SelectList(_context.CarDescriptions, "CarDescriptionId", "CarDescriptionId", rental.CarDescriptionId);
            ViewData["UserId"] = new SelectList(_context.UserDescriptions, "UserId", "UserId", rental.UserId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalId,CarDescriptionId,UserId,StartDate,EndDate,TotalCost")] Rental rental)
        {
            if (id != rental.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.RentalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarDescriptionId"] = new SelectList(_context.CarDescriptions, "CarDescriptionId", "CarDescriptionId", rental.CarDescriptionId);
            ViewData["UserId"] = new SelectList(_context.UserDescriptions, "UserId", "UserId", rental.UserId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.CarDescription)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }
        public IActionResult ConfirmRental()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart != null && cart.Items.Any())
            {
                foreach (var item in cart.Items)
                {
                    var rental = new Rental
                    {
                        CarDescriptionId = item.CarDescriptionId,
                        UserId = item.UserId,
                        StartDate = item.StartDate,
  
                        TotalCost = item.Car.RatePerDay * item.RentalDuration
            };

                    _context.Rentals.Add(rental);
                }
                _context.SaveChanges();
                HttpContext.Session.Remove("Cart"); // Clear the cart after successful rental processing
                return RedirectToAction("RentalConfirmation"); // Redirect to a confirmation page
            }

            return RedirectToAction("Index"); // Or redirect to an error or cart page if the cart is empty
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rentals == null)
            {
                return Problem("Entity set 'FS23_Group4_ProjectContext.Rentals'  is null.");
            }
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
          return (_context.Rentals?.Any(e => e.RentalId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectPartB.Models;

namespace ProjectPartB.Controllers
{
    public class CarDescriptionsController : Controller
    {
        private readonly FS23_Group4_ProjectContext _context;

        public CarDescriptionsController(FS23_Group4_ProjectContext context)
        {
            _context = context;
        }

        // GET: CarDescriptions
        //public async Task<IActionResult> Index()
        //{
        //    var fS23_Group4_ProjectContext = _context.CarDescriptions.Include(c => c.CarType);
        //    return View(await fS23_Group4_ProjectContext.ToListAsync());
        //}
        public async Task<IActionResult> Index(string searchString)
        {
            var carDescription = from e in _context.CarDescriptions select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                carDescription = carDescription.Where(s => s.Brand.Contains(searchString));
            }
            return View(await carDescription.ToListAsync());
        }
        public string IndexAJAX(string searchString)

        {

            string sql = "SELECT * FROM CarDescription WHERE Brand LIKE @b0"; // Contains An      

            string wrapString = "%" + searchString + "%";

            List<CarDescription> carDescriptions = _context.CarDescriptions.FromSqlRaw(sql, wrapString).ToList();

            string jason = JsonConvert.SerializeObject(carDescriptions);

            return jason;

        }
        // GET: CarDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarDescriptions == null)
            {
                return NotFound();
            }

            var carDescription = await _context.CarDescriptions
                .Include(c => c.CarType)
                .FirstOrDefaultAsync(m => m.CarDescriptionId == id);
            if (carDescription == null)
            {
                return NotFound();
            }

            return View(carDescription);
        }
        [Authorize(Roles ="Administrator")]
        // GET: CarDescriptions/Create
        public IActionResult Create()
        {
            ViewData["CarTypeId"] = new SelectList(_context.CarTypes, "CarTypeId", "CarTypeId");
            return View();
        }

        // POST: CarDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarDescriptionId,CarTypeId,Description,Brand,Model,Color,RatePerDay,Available")] CarDescription carDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarTypeId"] = new SelectList(_context.CarTypes, "CarTypeId", "CarTypeId", carDescription.CarTypeId);
            return View(carDescription);
        }

        // GET: CarDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarDescriptions == null)
            {
                return NotFound();
            }

            var carDescription = await _context.CarDescriptions.FindAsync(id);
            if (carDescription == null)
            {
                return NotFound();
            }
            ViewData["CarTypeId"] = new SelectList(_context.CarTypes, "CarTypeId", "CarTypeId", carDescription.CarTypeId);
            return View(carDescription);
        }

        // POST: CarDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarDescriptionId,CarTypeId,Description,Brand,Model,Color,RatePerDay,Available")] CarDescription carDescription)
        {
            if (id != carDescription.CarDescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarDescriptionExists(carDescription.CarDescriptionId))
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
            ViewData["CarTypeId"] = new SelectList(_context.CarTypes, "CarTypeId", "CarTypeId", carDescription.CarTypeId);
            return View(carDescription);
        }

        // GET: CarDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarDescriptions == null)
            {
                return NotFound();
            }

            var carDescription = await _context.CarDescriptions
                .Include(c => c.CarType)
                .FirstOrDefaultAsync(m => m.CarDescriptionId == id);
            if (carDescription == null)
            {
                return NotFound();
            }

            return View(carDescription);
        }

        // POST: CarDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarDescriptions == null)
            {
                return Problem("Entity set 'FS23_Group4_ProjectContext.CarDescriptions'  is null.");
            }
            var carDescription = await _context.CarDescriptions.FindAsync(id);
            if (carDescription != null)
            {
                _context.CarDescriptions.Remove(carDescription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarDescriptionExists(int id)
        {
          return (_context.CarDescriptions?.Any(e => e.CarDescriptionId == id)).GetValueOrDefault();
        }
    }
}

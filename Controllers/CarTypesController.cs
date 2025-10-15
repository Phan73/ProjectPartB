using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectPartB.Models;

namespace ProjectPartB.Controllers
{
    public class CarTypesController : Controller
    {
        private readonly FS23_Group4_ProjectContext _context;

        public CarTypesController(FS23_Group4_ProjectContext context)
        {
            _context = context;
        }

        // GET: CarTypes
        [Authorize(Roles = "Administrator,Editor")]
        public async Task<IActionResult> Index()
        {
              return _context.CarTypes != null ? 
                          View(await _context.CarTypes.ToListAsync()) :
                          Problem("Entity set 'FS23_Group4_ProjectContext.CarTypes'  is null.");
        }

        // GET: CarTypes/Details/5
        [Authorize(Roles = "Administrator,Editor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarTypes == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // GET: CarTypes/Create
        [Authorize(Roles = "Administrator,Editor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CarType carType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carType);
        }

        // GET: CarTypes/Edit/5
        [Authorize(Roles = "Administrator,Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarTypes == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes.FindAsync(id);
            if (carType == null)
            {
                return NotFound();
            }
            return View(carType);
        }

        // POST: CarTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CarType carType)
        {
            if (id != carType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarTypeExists(carType.Id))
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
            return View(carType);
        }

        // GET: CarTypes/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarTypes == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // POST: CarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarTypes == null)
            {
                return Problem("Entity set 'FS23_Group4_ProjectContext.CarTypes'  is null.");
            }
            var carType = await _context.CarTypes.FindAsync(id);
            if (carType != null)
            {
                _context.CarTypes.Remove(carType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarTypeExists(int id)
        {
          return (_context.CarTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

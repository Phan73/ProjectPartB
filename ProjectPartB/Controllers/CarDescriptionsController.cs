using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectPartB.Models;
using X.PagedList;

namespace ProjectPartB.Controllers
{
    public class CarDescriptionsController : Controller
    {
        private readonly FS23_Group4_ProjectContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public CarDescriptionsController(FS23_Group4_ProjectContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnviroment = webHostEnvironment;
        }


        //// GET: CarDescriptions
        //public async Task<IActionResult> Index()
        //{
        //    var fS23_Group4_ProjectContext = _context.CarDescriptions.Include(c => c.CarType);
        //    return View(await fS23_Group4_ProjectContext.ToListAsync());
        //}

        public IActionResult Index(string searchString, int? page, string sortOrder)
        {
            var pageNumber = page ?? 1;
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var carDescription = from e in _context.CarDescriptions select e;
            if (!string.IsNullOrEmpty(searchString))
            {
                carDescription = carDescription.Where(s => s.Brand.Contains(searchString));
            }
            //sort car by car availability
            carDescription = carDescription.OrderBy(s => s.Brand);
            switch (sortOrder)
            {
                case "name_desc":
                    carDescription = carDescription.OrderByDescending(s => s.Brand);
                    break;
            }
            //return View(await carDescription.ToListAsync());
            return View(carDescription.ToPagedList(pageNumber, 10));
        }
        public string IndexAJAX(string searchString)

        {

            string sql = "SELECT * FROM CarDescription WHERE Brand LIKE @p0";

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
        [Authorize(Roles = "Administrator,Editor")]
        // GET: CarDescriptions/Create
        public IActionResult Create()
        {
            ViewData["CarTypeName"] = new SelectList(_context.CarTypes, "Name", "Name");
            return View();
        }
        [Authorize(Roles = "Administrator,Editor")]
        // POST: CarDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarDescriptionId,CarTypeId,Description,Brand,Model,Color,RatePerDay,Available,Image,CarTypeName")] CarDescription carDescription, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string uploadFolder = Path.Combine(_webHostEnviroment.WebRootPath, "uploads");
                    string uniqueName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);

                    }
                    carDescription.Image = uniqueName;
                }
                _context.Add(carDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarTypeName"] = new SelectList(_context.CarTypes, "Name", "Name", carDescription.CarTypeName);
            return View(carDescription);
        }

        // GET: CarDescriptions/Edit/5
        [Authorize(Roles = "Administrator,Editor")]
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
            ViewData["CarTypeName"] = new SelectList(_context.CarTypes, "Name", "Name", carDescription.CarTypeName);
            return View(carDescription);
        }
        [Authorize(Roles = "Administrator,Editor")]
        // POST: CarDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarDescriptionId,CarTypeId,Description,Brand,Model,Color,RatePerDay,Available,Image,CarTypeName")] CarDescription carDescription, IFormFile image)
        {
            if (id != carDescription.CarDescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string uploadFolder = Path.Combine(_webHostEnviroment.WebRootPath, "uploads");
                    string uniqueName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                    carDescription.Image = uniqueName;
                }

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
            ViewData["CarTypeName"] = new SelectList(_context.CarTypes, "Name", "Name", carDescription.CarTypeName);
            return View(carDescription);
        }


        // GET: CarDescriptions/Delete/5
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeRentCar.Models;

namespace SistemaDeRentCar.Controllers
{
    public class TipoDeCombustiblesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDeCombustiblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeCombustibles

        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            var result = from s in _context.TipoDeCombustibles
                         select s;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.Description.Contains(searchString));
            }
            int pageSize = 3;
            return View(await PaginatedList<TipoDeCombustible>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: TipoDeCombustibles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDeCombustibles == null)
            {
                return NotFound();
            }

            var tipoDeCombustible = await _context.TipoDeCombustibles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeCombustible == null)
            {
                return NotFound();
            }

            return View(tipoDeCombustible);
        }

        // GET: TipoDeCombustibles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeCombustibles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Estado")] TipoDeCombustible tipoDeCombustible)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeCombustible);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeCombustible);
        }

        // GET: TipoDeCombustibles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDeCombustibles == null)
            {
                return NotFound();
            }

            var tipoDeCombustible = await _context.TipoDeCombustibles.FindAsync(id);
            if (tipoDeCombustible == null)
            {
                return NotFound();
            }
            return View(tipoDeCombustible);
        }

        // POST: TipoDeCombustibles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Estado")] TipoDeCombustible tipoDeCombustible)
        {
            if (id != tipoDeCombustible.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeCombustible);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeCombustibleExists(tipoDeCombustible.Id))
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
            return View(tipoDeCombustible);
        }

        // GET: TipoDeCombustibles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDeCombustibles == null)
            {
                return NotFound();
            }

            var tipoDeCombustible = await _context.TipoDeCombustibles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeCombustible == null)
            {
                return NotFound();
            }

            return View(tipoDeCombustible);
        }

        // POST: TipoDeCombustibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDeCombustibles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoDeCombustibles'  is null.");
            }
            var tipoDeCombustible = await _context.TipoDeCombustibles.FindAsync(id);
            if (tipoDeCombustible != null)
            {
                _context.TipoDeCombustibles.Remove(tipoDeCombustible);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeCombustibleExists(int id)
        {
          return (_context.TipoDeCombustibles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

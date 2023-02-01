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
    public class TipoDeVehiculoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDeVehiculoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeVehiculoes


        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            var result = from s in _context.TipoDeVehiculos
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
            return View(await PaginatedList<TipoDeVehiculo>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        // GET: TipoDeVehiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDeVehiculos == null)
            {
                return NotFound();
            }

            var tipoDeVehiculo = await _context.TipoDeVehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeVehiculo == null)
            {
                return NotFound();
            }

            return View(tipoDeVehiculo);
        }

        // GET: TipoDeVehiculoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeVehiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Estado")] TipoDeVehiculo tipoDeVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeVehiculo);
        }

        // GET: TipoDeVehiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDeVehiculos == null)
            {
                return NotFound();
            }

            var tipoDeVehiculo = await _context.TipoDeVehiculos.FindAsync(id);
            if (tipoDeVehiculo == null)
            {
                return NotFound();
            }
            return View(tipoDeVehiculo);
        }

        // POST: TipoDeVehiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Estado")] TipoDeVehiculo tipoDeVehiculo)
        {
            if (id != tipoDeVehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeVehiculoExists(tipoDeVehiculo.Id))
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
            return View(tipoDeVehiculo);
        }

        // GET: TipoDeVehiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDeVehiculos == null)
            {
                return NotFound();
            }

            var tipoDeVehiculo = await _context.TipoDeVehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeVehiculo == null)
            {
                return NotFound();
            }

            return View(tipoDeVehiculo);
        }

        // POST: TipoDeVehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDeVehiculos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoDeVehiculos'  is null.");
            }
            var tipoDeVehiculo = await _context.TipoDeVehiculos.FindAsync(id);
            if (tipoDeVehiculo != null)
            {
                _context.TipoDeVehiculos.Remove(tipoDeVehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeVehiculoExists(int id)
        {
          return (_context.TipoDeVehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

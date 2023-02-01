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
    public class VehiculoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehiculoes



        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            var result = from s in _context.Vehiculos.Include(v => v.Marca).Include(v => v.Modelo).Include(v => v.TipoDeCombustible).Include(v => v.TipoDeVehiculo)
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
                result = result.Where(x => x.Description == searchString || x.NChasis == searchString || x.Id == int.Parse(searchString) || x.Marca.Description == searchString || x.Modelo.Description == searchString || x.TipoDeCombustible.Description == searchString || x.TipoDeVehiculo.Description == searchString);
            }
            int pageSize = 3;
            return View(await PaginatedList<Vehiculo>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        // GET: Vehiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.Marca)
                .Include(v => v.Modelo)
                .Include(v => v.TipoDeCombustible)
                .Include(v => v.TipoDeVehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculoes/Create
        public IActionResult Create()
        {
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Description");
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Description");
            ViewData["IdTipoCombustible"] = new SelectList(_context.TipoDeCombustibles, "Id", "Description");
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoDeVehiculos, "Id", "Description");
            return View();
        }

        // POST: Vehiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,NChasis,NMotor,NPlaca,IdTipoVehiculo,IdMarca,IdModelo,IdTipoCombustible,Estado")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Description", vehiculo.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Description", vehiculo.IdModelo);
            ViewData["IdTipoCombustible"] = new SelectList(_context.TipoDeCombustibles, "Id", "Description", vehiculo.IdTipoCombustible);
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoDeVehiculos, "Id", "Description", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Description", vehiculo.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Description", vehiculo.IdModelo);
            ViewData["IdTipoCombustible"] = new SelectList(_context.TipoDeCombustibles, "Id", "Description", vehiculo.IdTipoCombustible);
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoDeVehiculos, "Id", "Description", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // POST: Vehiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,NChasis,NMotor,NPlaca,IdTipoVehiculo,IdMarca,IdModelo,IdTipoCombustible,Estado")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
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
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Description", vehiculo.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Description", vehiculo.IdModelo);
            ViewData["IdTipoCombustible"] = new SelectList(_context.TipoDeCombustibles, "Id", "Description", vehiculo.IdTipoCombustible);
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoDeVehiculos, "Id", "Description", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.Marca)
                .Include(v => v.Modelo)
                .Include(v => v.TipoDeCombustible)
                .Include(v => v.TipoDeVehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehiculos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehiculos'  is null.");
            }
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
          return (_context.Vehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

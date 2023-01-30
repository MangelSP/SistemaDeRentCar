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
    public class InspeccionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InspeccionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inspeccions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Inspeccions.Include(i => i.Cliente).Include(i => i.Empleado).Include(i => i.Vehiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inspeccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inspeccions == null)
            {
                return NotFound();
            }

            var inspeccion = await _context.Inspeccions
                .Include(i => i.Cliente)
                .Include(i => i.Empleado)
                .Include(i => i.Vehiculo)
                .FirstOrDefaultAsync(m => m.IdTransacción == id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            return View(inspeccion);
        }

        // GET: Inspeccions/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["IdEmpleadoInspeccuion"] = new SelectList(_context.Empleados, "Id", "Nombre");
            ViewData["IdVehículo"] = new SelectList(_context.Vehiculos, "Id", "Description");
            return View();
        }

        // POST: Inspeccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransacción,IdVehículo,IdCliente,TieneRalladuras,CantidadCombustible,TieneGomaRespuesta,TieneGato,EstadoGomas,Fecha,IdEmpleadoInspeccuion,Estado")] Inspeccion inspeccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspeccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", inspeccion.IdCliente);
            ViewData["IdEmpleadoInspeccuion"] = new SelectList(_context.Empleados, "Id", "Nombre", inspeccion.IdEmpleadoInspeccuion);
            ViewData["IdVehículo"] = new SelectList(_context.Vehiculos, "Id", "Description", inspeccion.IdVehículo);
            return View(inspeccion);
        }

        // GET: Inspeccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inspeccions == null)
            {
                return NotFound();
            }

            var inspeccion = await _context.Inspeccions.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", inspeccion.IdCliente);
            ViewData["IdEmpleadoInspeccuion"] = new SelectList(_context.Empleados, "Id", "Nombre", inspeccion.IdEmpleadoInspeccuion);
            ViewData["IdVehículo"] = new SelectList(_context.Vehiculos, "Id", "Description", inspeccion.IdVehículo);
            return View(inspeccion);
        }

        // POST: Inspeccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransacción,IdVehículo,IdCliente,TieneRalladuras,CantidadCombustible,TieneGomaRespuesta,TieneGato,EstadoGomas,Fecha,IdEmpleadoInspeccuion,Estado")] Inspeccion inspeccion)
        {
            if (id != inspeccion.IdTransacción)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspeccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspeccionExists(inspeccion.IdTransacción))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", inspeccion.IdCliente);
            ViewData["IdEmpleadoInspeccuion"] = new SelectList(_context.Empleados, "Id", "Nombre", inspeccion.IdEmpleadoInspeccuion);
            ViewData["IdVehículo"] = new SelectList(_context.Vehiculos, "Id", "Description", inspeccion.IdVehículo);
            return View(inspeccion);
        }

        // GET: Inspeccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inspeccions == null)
            {
                return NotFound();
            }

            var inspeccion = await _context.Inspeccions
                .Include(i => i.Cliente)
                .Include(i => i.Empleado)
                .Include(i => i.Vehiculo)
                .FirstOrDefaultAsync(m => m.IdTransacción == id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            return View(inspeccion);
        }

        // POST: Inspeccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inspeccions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Inspeccions'  is null.");
            }
            var inspeccion = await _context.Inspeccions.FindAsync(id);
            if (inspeccion != null)
            {
                _context.Inspeccions.Remove(inspeccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspeccionExists(int id)
        {
          return (_context.Inspeccions?.Any(e => e.IdTransacción == id)).GetValueOrDefault();
        }
    }
}

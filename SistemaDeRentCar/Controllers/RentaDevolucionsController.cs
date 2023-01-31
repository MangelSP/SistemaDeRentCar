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
    public class RentaDevolucionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentaDevolucionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentaDevolucions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentaDevolucions.Include(r => r.Cliente).Include(r => r.Empleado).Include(r => r.Vehiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RentaDevolucions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RentaDevolucions == null)
            {
                return NotFound();
            }

            var rentaDevolucion = await _context.RentaDevolucions
                .Include(r => r.Cliente)
                .Include(r => r.Empleado)
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentaDevolucion == null)
            {
                return NotFound();
            }

            return View(rentaDevolucion);
        }

        // GET: RentaDevolucions/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Nombre");
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Description");
            return View();
        }

        // POST: RentaDevolucions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,IdVehiculo,IdEmpleado,FechaRenta,FechaDevolucion,MontoDia,CantidadDia,Comentario,Estado")] RentaDevolucion rentaDevolucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentaDevolucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", rentaDevolucion.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Nombre", rentaDevolucion.IdEmpleado);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Description", rentaDevolucion.IdVehiculo);
            return View(rentaDevolucion);
        }

        // GET: RentaDevolucions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RentaDevolucions == null)
            {
                return NotFound();
            }

            var rentaDevolucion = await _context.RentaDevolucions.FindAsync(id);
            if (rentaDevolucion == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", rentaDevolucion.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Nombre", rentaDevolucion.IdEmpleado);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Description", rentaDevolucion.IdVehiculo);
            return View(rentaDevolucion);
        }

        // POST: RentaDevolucions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,IdVehiculo,IdEmpleado,FechaRenta,FechaDevolucion,MontoDia,CantidadDia,Comentario,Estado")] RentaDevolucion rentaDevolucion)
        {
            if (id != rentaDevolucion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentaDevolucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentaDevolucionExists(rentaDevolucion.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", rentaDevolucion.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Nombre", rentaDevolucion.IdEmpleado);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Description", rentaDevolucion.IdVehiculo);
            return View(rentaDevolucion);
        }

        // GET: RentaDevolucions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RentaDevolucions == null)
            {
                return NotFound();
            }

            var rentaDevolucion = await _context.RentaDevolucions
                .Include(r => r.Cliente)
                .Include(r => r.Empleado)
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentaDevolucion == null)
            {
                return NotFound();
            }

            return View(rentaDevolucion);
        }

        // POST: RentaDevolucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RentaDevolucions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RentaDevolucions'  is null.");
            }
            var rentaDevolucion = await _context.RentaDevolucions.FindAsync(id);
            if (rentaDevolucion != null)
            {
                _context.RentaDevolucions.Remove(rentaDevolucion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentaDevolucionExists(int id)
        {
          return (_context.RentaDevolucions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

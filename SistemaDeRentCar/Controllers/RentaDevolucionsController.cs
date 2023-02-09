using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeRentCar.Models;

namespace SistemaDeRentCar.Controllers
{
    public class RentaDevolucionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RentaDevolucionsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

            _context = context;
        }

        // GET: RentaDevolucions

 
        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            var result = from s in _context.RentaDevolucions.Include(r => r.Cliente).Include(r => r.Empleado).Include(r => r.Vehiculo)
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
                result = result.Where(x => x.Comentario == searchString || x.Id == int.Parse(searchString) || x.Cliente.Nombre == searchString);
            }
            int pageSize = 3;
            ViewData["IdTipoVehiculo"] = new SelectList(_context.TipoDeVehiculos, "Id", "Description");

            return View(await PaginatedList<RentaDevolucion>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));

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

        public IActionResult Print(DateTime fechaRenta, string tipoVehiculo)
        {
            if (!fechaRenta.Equals(null) || !tipoVehiculo.Equals(null))
            {
                ViewData["fechaRenta"] = fechaRenta;
                ViewData["tipoVehiculo"] = tipoVehiculo;
                var dt = new DataTable();
                dt = GetRentaDevolucion(fechaRenta, tipoVehiculo);
                string mimeType = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\ReportRenta.rdlc";

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("prm", "Sistema de rentar carro");
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("dtReport", dt);
                var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
                return File(result.MainStream, "application/pdf");
            }

            return RedirectToAction("Index");
        }
        public DataTable GetRentaDevolucion(DateTime fechaRenta,string tipoVehiculo)
        {
            var result = _context.RentaDevolucions.Include(r => r.Cliente)
                .Include(r => r.Empleado)
                .Include(r => r.Vehiculo)
                .Include(r => r.Vehiculo.Modelo)
                .Include(r => r.Vehiculo.Marca)
                .Include(r => r.Vehiculo.TipoDeVehiculo)
                .Include(r => r.Vehiculo.TipoDeCombustible).Where(x => x.FechaRenta == fechaRenta || x.Vehiculo.TipoDeVehiculo.Description == tipoVehiculo ).ToListAsync();
            var dt = new DataTable();

            return ConvertToDatatable(result.Result);
        }

        static DataTable ConvertToDatatable(List<RentaDevolucion> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Cliente");
            dt.Columns.Add("Vehiculo");
            dt.Columns.Add("Empleado");
            dt.Columns.Add("FechaRenta");
            dt.Columns.Add("FechaDevolucion");
            dt.Columns.Add("MontoDia");
            dt.Columns.Add("CantidadDia");
            dt.Columns.Add("Comentario");
            dt.Columns.Add("Marca");
            dt.Columns.Add("Modelo");
            dt.Columns.Add("TipoGasolina");
            dt.Columns.Add("TipoVehiculo");
            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["Id"] = item.Id;
                row["Cliente"] = item.Cliente.Nombre.ToString();
                row["Marca"] = item.Vehiculo.Marca.Description.ToString();
                row["Modelo"] = item.Vehiculo.Modelo.Description.ToString();
                row["TipoGasolina"] = item.Vehiculo.TipoDeCombustible.Description.ToString();
                row["TipoVehiculo"] = item.Vehiculo.TipoDeVehiculo.Description.ToString();
                row["Vehiculo"] = item.Vehiculo.Modelo.Description.ToString();
                row["Empleado"] = item.Empleado.Nombre.ToString();
                row["FechaRenta"] = item.FechaRenta.ToString();
                row["FechaDevolucion"] = item.FechaDevolucion.ToString();
                row["MontoDia"] = item.MontoDia.ToString();
                row["CantidadDia"] = item.CantidadDia.ToString();
                row["Comentario"] = item.Comentario.ToString();

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}

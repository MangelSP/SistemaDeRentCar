using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaDeRentCar.Models;
using System.Diagnostics;

namespace SistemaDeRentCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (searchString != null)
            {
                ViewData["ListVehiculosEnable"] = await _context.Vehiculos
               .Include(v => v.Marca)
               .Include(v => v.Modelo)
               .Include(v => v.TipoDeCombustible)
               .Include(v => v.TipoDeVehiculo)
               .Where(x => x.Description == searchString || x.NChasis == searchString || x.Marca.Description == searchString || x.Modelo.Description == searchString).ToListAsync();
            }else
            {
                ViewData["ListVehiculosEnable"] = await _context.Vehiculos
          .Include(v => v.Marca)
          .Include(v => v.Modelo)
          .Include(v => v.TipoDeCombustible)
          .Include(v => v.TipoDeVehiculo)
          .ToListAsync();
            }
          
            return View();
            
        }
   

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ConsultaCriterio(string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            var rentadevoluciones = from s in _context.RentaDevolucions.Include(r => r.Cliente)
                                                     .Include(r => r.Empleado)
                                                     .Include(r => r.Vehiculo)
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
                rentadevoluciones = rentadevoluciones.Include(r => r.Cliente)
                                                     .Include(r => r.Empleado)
                                                     .Include(r => r.Vehiculo).Include(x => x.Vehiculo.Modelo).Include(x => x.Vehiculo.Marca)
                                                     .Where(s => s.Cliente.Nombre.Contains(searchString)
                                                        || s.Comentario.Contains(searchString));
            }
            int pageSize = 3;
            return View(await PaginatedList<RentaDevolucion>.CreateAsync(rentadevoluciones.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
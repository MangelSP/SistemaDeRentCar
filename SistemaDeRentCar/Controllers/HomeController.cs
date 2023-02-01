using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaDeRentCar.Models;
using System.Data;
using System.Diagnostics;

namespace SistemaDeRentCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
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


        public IActionResult Print(int id)
        {
            if (id > 0)
            {
                ViewData["CurrentFilter"] = id;
                var dt = new DataTable();
                dt = GetRentaDevolucion(id);
                string mimeType = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rptRentaDevolucion.rdlc";

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("prm", "Sistema de rentar carro");
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("dtRentaDevolucion", dt);
                var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
                return File(result.MainStream, "application/pdf");
            }
           
            return RedirectToAction("Index");
        }

        public DataTable GetRentaDevolucion(int id)
        {
            var result =  _context.RentaDevolucions.Include(r => r.Cliente).Include(r => r.Empleado).Include(r => r.Vehiculo).Include(r=>r.Vehiculo.Modelo).Include(r => r.Vehiculo.Marca).Include(r => r.Vehiculo.TipoDeVehiculo).Include(r => r.Vehiculo.TipoDeCombustible).Where( x=>x.Id == id).FirstOrDefault();
            var dt = new DataTable();

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
            DataRow row;
       
                row = dt.NewRow();
                row["Id"] = result.Id;
                row["Cliente"] = result.Cliente.Nombre.ToString();
                row["Marca"] = result.Vehiculo.Marca.Description.ToString();
                row["Modelo"] = result.Vehiculo.Modelo.Description.ToString();
                row["TipoGasolina"] = result.Vehiculo.TipoDeCombustible.Description.ToString();
                row["TipoVehiculo"] = result.Vehiculo.TipoDeVehiculo.Description.ToString();
                row["Vehiculo"] = result.Vehiculo.Modelo.Description.ToString();
                row["Empleado"] = result.Empleado.Nombre.ToString();
                row["FechaRenta"] = result.FechaRenta.ToString();
                row["FechaDevolucion"] = result.FechaDevolucion.ToString();
                row["MontoDia"] = result.MontoDia.ToString();
                row["CantidadDia"] = result.CantidadDia.ToString();
                row["Comentario"] = result.Comentario.ToString();
                dt.Rows.Add(row);
            
            return dt;
        }
    }
}
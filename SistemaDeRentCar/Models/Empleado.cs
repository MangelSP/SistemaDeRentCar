using System.ComponentModel.DataAnnotations;

namespace SistemaDeRentCar.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string TandaLabor { get; set; } = string.Empty;
        public decimal ProcientoComision { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.UtcNow;
        public bool Estado { get; set; }
        public ICollection<Inspeccion>? Inspeccion { get; set; }
        public ICollection<RentaDevolucion>? RentaDevolucion { get; set; }


    }
}

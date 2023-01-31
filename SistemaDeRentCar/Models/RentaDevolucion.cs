using System.ComponentModel.DataAnnotations;

namespace SistemaDeRentCar.Models
{
    public class RentaDevolucion
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdVehiculo  { get; set; }
        public int IdEmpleado { get; set; }
        public Cliente? Cliente { get; set; }
        public Vehiculo? Vehiculo { get; set; }
        public Empleado? Empleado { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaRenta { get; set; } = DateTime.UtcNow;
        [DataType(DataType.DateTime)]
        public DateTime FechaDevolucion { get; set; } = DateTime.UtcNow;
        public int MontoDia { get; set; }
        public int CantidadDia { get; set; }
        public string Comentario { get; set; } =  string.Empty;
        public bool Estado { get; set; }
    }
}

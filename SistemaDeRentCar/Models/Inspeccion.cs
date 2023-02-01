using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;

namespace SistemaDeRentCar.Models
{
    public class Inspeccion
    {
        [Key]
        public int IdTransacción { get; set; }
        public int IdVehículo { get; set; }
        public virtual Vehiculo? Vehiculo { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public bool TieneRalladuras { get; set; }
        public string CantidadCombustible { get; set; } = string.Empty;
        public bool TieneGomaRespuesta { get; set; }
        public bool TieneGato { get; set; }
        public string EstadoGomas { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        public int IdEmpleado {get; set; }
        public virtual Empleado? Empleado { get; set; }
        public bool Estado { get; set; }


    }
}

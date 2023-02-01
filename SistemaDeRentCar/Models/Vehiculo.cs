using System.ComponentModel.DataAnnotations;

namespace SistemaDeRentCar.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        [StringLength(40)]
        public string NChasis { get; set; } = string.Empty;
        [StringLength(40)]
        public string NMotor { get; set; } = string.Empty;
        [StringLength(40)]
        public string NPlaca { get; set; } = string.Empty;
        public int IdTipoVehiculo { get; set; }
        public  TipoDeVehiculo? TipoDeVehiculo { get; set; }
        public int IdMarca { get; set; }
        public  Marca? Marca { get; set; }
        public int IdModelo { get; set; }
        public  Modelo? Modelo { get; set; }
        public int IdTipoCombustible { get; set; }
        public  TipoDeCombustible? TipoDeCombustible { get; set; }
        public bool Estado { get; set; }
        public  ICollection<Inspeccion>? Inspeccion { get; set; }
        public ICollection<RentaDevolucion>? RentaDevolucion { get; set; }

    }
}

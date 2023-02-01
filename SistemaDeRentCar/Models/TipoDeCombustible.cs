using System.ComponentModel.DataAnnotations;

namespace SistemaDeRentCar.Models
{
    public class TipoDeCombustible
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public  ICollection<Vehiculo>? Vehiculo { get; set; }

    }
}

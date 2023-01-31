using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeRentCar.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string  Nombre  { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string NTarjetaCR { get; set; } = string.Empty;
        public string LimiteCredito { get; set; } = string.Empty;
        public string TipoPersona { get; set;} = string.Empty;
        public bool Estado { get; set; }
        [NotMapped]
        public virtual Inspeccion? Inspeccion { get; set; }
        [NotMapped]
        public virtual RentaDevolucion? RentaDevolucion { get; set; }
    }
}

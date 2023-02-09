using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeRentCar.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Nombre  { get; set; } = string.Empty;
        [StringLength(maximumLength: 20,MinimumLength = 5,ErrorMessage ="El valor maximo es 20 y el minimo es 5.")]
        public string Cedula { get; set; } = string.Empty;
        public string NTarjetaCR { get; set; } = string.Empty;
        public string LimiteCredito { get; set; } = string.Empty;
        public string TipoPersona { get; set;} = string.Empty;
        public bool Estado { get; set; }
        public ICollection<Inspeccion>? Inspeccion { get; set; }
        public ICollection<RentaDevolucion>? RentaDevolucion { get; set; }
    }
}

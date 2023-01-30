﻿using System.ComponentModel.DataAnnotations;

namespace SistemaDeRentCar.Models
{
    public class TipoDeVehiculo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public virtual Vehiculo? Vehiculo { get; set; }
    }
}

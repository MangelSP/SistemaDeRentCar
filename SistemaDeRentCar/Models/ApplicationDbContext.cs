using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Diagnostics;

namespace SistemaDeRentCar.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Temp\MyDatabase.db");
            Batteries.Init();

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Inspeccion> Inspeccions { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<RentaDevolucion> RentaDevolucions { get; set; }
        public DbSet<TipoDeCombustible> TipoDeCombustibles { get; set; }
        public DbSet<TipoDeVehiculo> TipoDeVehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // configures one-to-many relationship
            modelBuilder.Entity<Inspeccion>()
            .HasOne<Cliente>(s => s.Cliente)
            .WithMany(g => g.Inspeccion)
            .HasForeignKey(s => s.IdCliente);

            modelBuilder.Entity<Inspeccion>()
            .HasOne<Empleado>(s => s.Empleado)
            .WithMany(g => g.Inspeccion)
            .HasForeignKey(s => s.IdEmpleado);

            modelBuilder.Entity<Inspeccion>()
            .HasOne<Vehiculo>(s => s.Vehiculo)
            .WithMany(g => g.Inspeccion)
            .HasForeignKey(s => s.IdVehículo);

            modelBuilder.Entity<Modelo>()
            .HasOne<Marca>(s => s.Marca)
            .WithMany(g => g.Modelo)
            .HasForeignKey(s => s.IdMarca);

            modelBuilder.Entity<Vehiculo>()
            .HasOne<TipoDeVehiculo>(s => s.TipoDeVehiculo)
            .WithMany(g => g.Vehiculo)
            .HasForeignKey(s => s.IdTipoVehiculo);

            modelBuilder.Entity<Vehiculo>()
            .HasOne<Marca>(s => s.Marca)
            .WithMany(g => g.Vehiculo)
            .HasForeignKey(s => s.IdMarca);

            modelBuilder.Entity<Vehiculo>()
            .HasOne<Modelo>(s => s.Modelo)
            .WithMany(g => g.Vehiculo)
            .HasForeignKey(s => s.IdModelo);

            modelBuilder.Entity<Vehiculo>()
            .HasOne<TipoDeCombustible>(s => s.TipoDeCombustible)
            .WithMany(g => g.Vehiculo)
            .HasForeignKey(s => s.IdTipoCombustible);

            modelBuilder.Entity<Vehiculo>()
            .HasOne<TipoDeCombustible>(s => s.TipoDeCombustible)
            .WithMany(g => g.Vehiculo)
            .HasForeignKey(s => s.IdTipoCombustible);

            modelBuilder.Entity<RentaDevolucion>()
           .HasOne<Cliente>(s => s.Cliente)
           .WithMany(g => g.RentaDevolucion)
           .HasForeignKey(s => s.IdCliente);


            modelBuilder.Entity<RentaDevolucion>()
           .HasOne<Vehiculo>(s => s.Vehiculo)
           .WithMany(g => g.RentaDevolucion)
           .HasForeignKey(s => s.IdVehiculo);

            modelBuilder.Entity<RentaDevolucion>()
           .HasOne<Empleado>(s => s.Empleado)
           .WithMany(g => g.RentaDevolucion)
           .HasForeignKey(s => s.IdEmpleado);

        }
    }
}

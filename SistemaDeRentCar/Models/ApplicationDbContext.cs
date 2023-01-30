using Microsoft.EntityFrameworkCore;
using SQLitePCL;

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
            modelBuilder.Entity<Modelo>().HasOne(x => x.Marca).WithOne(x => x.Modelo).HasForeignKey<Modelo>(x => x.IdMarca);

            modelBuilder.Entity<Inspeccion>().HasOne(x => x.Cliente).WithOne(x => x.Inspeccion).HasForeignKey<Inspeccion>(x=> x.IdCliente);
            modelBuilder.Entity<Inspeccion>().HasOne(x => x.Empleado).WithOne(x => x.Inspeccion).HasForeignKey<Inspeccion>(x => x.IdEmpleadoInspeccuion);
            modelBuilder.Entity<Inspeccion>().HasOne(x => x.Vehiculo).WithOne(x => x.Inspeccion).HasForeignKey<Inspeccion>(x => x.IdVehículo);
           
            modelBuilder.Entity<Vehiculo>().HasOne(x => x.TipoDeVehiculo).WithOne(x => x.Vehiculo).HasForeignKey<Vehiculo>(x => x.IdTipoVehiculo);
            modelBuilder.Entity<Vehiculo>().HasOne(x => x.Marca).WithOne(x => x.Vehiculo).HasForeignKey<Vehiculo>(x => x.IdMarca);
            modelBuilder.Entity<Vehiculo>().HasOne(x => x.Modelo).WithOne(x => x.Vehiculo).HasForeignKey<Vehiculo>(x => x.IdModelo);
            modelBuilder.Entity<Vehiculo>().HasOne(x => x.TipoDeCombustible).WithOne(x => x.Vehiculo).HasForeignKey<Vehiculo>(x => x.TipoCombustible);



        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeRentCar.Models;

#nullable disable

namespace SistemaDeRentCar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230130221410_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("SistemaDeRentCar.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LimiteCredito")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NTarjetaCR")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPersona")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ProcientoComision")
                        .HasColumnType("TEXT");

                    b.Property<string>("TandaLabor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Inspeccion", b =>
                {
                    b.Property<int>("IdTransacción")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CantidadCombustible")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EstadoGomas")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdEmpleadoInspeccuion")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdVehículo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TieneGato")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TieneGomaRespuesta")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TieneRalladuras")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdTransacción");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.HasIndex("IdEmpleadoInspeccuion")
                        .IsUnique();

                    b.HasIndex("IdVehículo")
                        .IsUnique();

                    b.ToTable("Inspeccions");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMarca")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdMarca")
                        .IsUnique();

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.RentaDevolucion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RentaDevolucions");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.TipoDeCombustible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TipoDeCombustibles");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.TipoDeVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TipoDeVehiculos");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMarca")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdModelo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdTipoVehiculo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NChasis")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("NMotor")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("NPlaca")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoCombustible")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdMarca")
                        .IsUnique();

                    b.HasIndex("IdModelo")
                        .IsUnique();

                    b.HasIndex("IdTipoVehiculo")
                        .IsUnique();

                    b.HasIndex("TipoCombustible")
                        .IsUnique();

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Inspeccion", b =>
                {
                    b.HasOne("SistemaDeRentCar.Models.Cliente", "Cliente")
                        .WithOne("Inspeccion")
                        .HasForeignKey("SistemaDeRentCar.Models.Inspeccion", "IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeRentCar.Models.Empleado", "Empleado")
                        .WithOne("Inspeccion")
                        .HasForeignKey("SistemaDeRentCar.Models.Inspeccion", "IdEmpleadoInspeccuion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeRentCar.Models.Vehiculo", "Vehiculo")
                        .WithOne("Inspeccion")
                        .HasForeignKey("SistemaDeRentCar.Models.Inspeccion", "IdVehículo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Modelo", b =>
                {
                    b.HasOne("SistemaDeRentCar.Models.Marca", "Marca")
                        .WithOne("Modelo")
                        .HasForeignKey("SistemaDeRentCar.Models.Modelo", "IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Vehiculo", b =>
                {
                    b.HasOne("SistemaDeRentCar.Models.Marca", "Marca")
                        .WithOne("Vehiculo")
                        .HasForeignKey("SistemaDeRentCar.Models.Vehiculo", "IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeRentCar.Models.Modelo", "Modelo")
                        .WithOne("Vehiculo")
                        .HasForeignKey("SistemaDeRentCar.Models.Vehiculo", "IdModelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeRentCar.Models.TipoDeVehiculo", "TipoDeVehiculo")
                        .WithOne("Vehiculo")
                        .HasForeignKey("SistemaDeRentCar.Models.Vehiculo", "IdTipoVehiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeRentCar.Models.TipoDeCombustible", "TipoDeCombustible")
                        .WithOne("Vehiculo")
                        .HasForeignKey("SistemaDeRentCar.Models.Vehiculo", "TipoCombustible")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("Modelo");

                    b.Navigation("TipoDeCombustible");

                    b.Navigation("TipoDeVehiculo");
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Cliente", b =>
                {
                    b.Navigation("Inspeccion")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Empleado", b =>
                {
                    b.Navigation("Inspeccion")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Marca", b =>
                {
                    b.Navigation("Modelo")
                        .IsRequired();

                    b.Navigation("Vehiculo")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Modelo", b =>
                {
                    b.Navigation("Vehiculo")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.TipoDeCombustible", b =>
                {
                    b.Navigation("Vehiculo")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.TipoDeVehiculo", b =>
                {
                    b.Navigation("Vehiculo")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeRentCar.Models.Vehiculo", b =>
                {
                    b.Navigation("Inspeccion")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

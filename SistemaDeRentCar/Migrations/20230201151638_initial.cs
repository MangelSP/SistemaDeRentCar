using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeRentCar.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: false),
                    NTarjetaCR = table.Column<string>(type: "TEXT", nullable: false),
                    LimiteCredito = table.Column<string>(type: "TEXT", nullable: false),
                    TipoPersona = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: false),
                    TandaLabor = table.Column<string>(type: "TEXT", nullable: false),
                    ProcientoComision = table.Column<decimal>(type: "TEXT", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeCombustibles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeCombustibles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeVehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeVehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdMarca = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    NChasis = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    NMotor = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    NPlaca = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    IdTipoVehiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    IdModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTipoCombustible = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Modelos_IdModelo",
                        column: x => x.IdModelo,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TipoDeCombustibles_IdTipoCombustible",
                        column: x => x.IdTipoCombustible,
                        principalTable: "TipoDeCombustibles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TipoDeVehiculos_IdTipoVehiculo",
                        column: x => x.IdTipoVehiculo,
                        principalTable: "TipoDeVehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspeccions",
                columns: table => new
                {
                    IdTransacción = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdVehículo = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    TieneRalladuras = table.Column<bool>(type: "INTEGER", nullable: false),
                    CantidadCombustible = table.Column<string>(type: "TEXT", nullable: false),
                    TieneGomaRespuesta = table.Column<bool>(type: "INTEGER", nullable: false),
                    TieneGato = table.Column<bool>(type: "INTEGER", nullable: false),
                    EstadoGomas = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdEmpleado = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspeccions", x => x.IdTransacción);
                    table.ForeignKey(
                        name: "FK_Inspeccions_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspeccions_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspeccions_Vehiculos_IdVehículo",
                        column: x => x.IdVehículo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentaDevolucions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdVehiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEmpleado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaRenta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MontoDia = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadDia = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentaDevolucions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentaDevolucions_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentaDevolucions_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentaDevolucions_Vehiculos_IdVehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccions_IdCliente",
                table: "Inspeccions",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccions_IdEmpleado",
                table: "Inspeccions",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccions_IdVehículo",
                table: "Inspeccions",
                column: "IdVehículo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdMarca",
                table: "Modelos",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucions_IdCliente",
                table: "RentaDevolucions",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucions_IdEmpleado",
                table: "RentaDevolucions",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucions_IdVehiculo",
                table: "RentaDevolucions",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdMarca",
                table: "Vehiculos",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdModelo",
                table: "Vehiculos",
                column: "IdModelo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdTipoCombustible",
                table: "Vehiculos",
                column: "IdTipoCombustible");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdTipoVehiculo",
                table: "Vehiculos",
                column: "IdTipoVehiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspeccions");

            migrationBuilder.DropTable(
                name: "RentaDevolucions");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "TipoDeCombustibles");

            migrationBuilder.DropTable(
                name: "TipoDeVehiculos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}

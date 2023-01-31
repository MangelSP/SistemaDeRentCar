using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeRentCar.Migrations
{
    /// <inheritdoc />
    public partial class ADDEDNEWENTITY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadDia",
                table: "RentaDevolucions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "RentaDevolucions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "RentaDevolucions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDevolucion",
                table: "RentaDevolucions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRenta",
                table: "RentaDevolucions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "RentaDevolucions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpleado",
                table: "RentaDevolucions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdVehiculo",
                table: "RentaDevolucions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MontoDia",
                table: "RentaDevolucions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucions_IdCliente",
                table: "RentaDevolucions",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucions_IdEmpleado",
                table: "RentaDevolucions",
                column: "IdEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucions_IdVehiculo",
                table: "RentaDevolucions",
                column: "IdVehiculo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RentaDevolucions_Clientes_IdCliente",
                table: "RentaDevolucions",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentaDevolucions_Empleados_IdEmpleado",
                table: "RentaDevolucions",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentaDevolucions_Vehiculos_IdVehiculo",
                table: "RentaDevolucions",
                column: "IdVehiculo",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentaDevolucions_Clientes_IdCliente",
                table: "RentaDevolucions");

            migrationBuilder.DropForeignKey(
                name: "FK_RentaDevolucions_Empleados_IdEmpleado",
                table: "RentaDevolucions");

            migrationBuilder.DropForeignKey(
                name: "FK_RentaDevolucions_Vehiculos_IdVehiculo",
                table: "RentaDevolucions");

            migrationBuilder.DropIndex(
                name: "IX_RentaDevolucions_IdCliente",
                table: "RentaDevolucions");

            migrationBuilder.DropIndex(
                name: "IX_RentaDevolucions_IdEmpleado",
                table: "RentaDevolucions");

            migrationBuilder.DropIndex(
                name: "IX_RentaDevolucions_IdVehiculo",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "CantidadDia",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "FechaDevolucion",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "FechaRenta",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "IdEmpleado",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "IdVehiculo",
                table: "RentaDevolucions");

            migrationBuilder.DropColumn(
                name: "MontoDia",
                table: "RentaDevolucions");
        }
    }
}

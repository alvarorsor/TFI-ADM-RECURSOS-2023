using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cuentaCorrientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recursos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<bool>(
                name: "finalizado",
                table: "Proyectos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "finalizado",
                table: "Proyectos");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CUIT", "apellido", "direccion", "email", "fecha_alta", "nombre", "telefono" },
                values: new object[] { 1, "23-39572450-9", "perez", "av alem 330", "juanperez@gmail.com", new DateTime(2023, 10, 29, 16, 5, 6, 759, DateTimeKind.Local).AddTicks(5928), "Juan", 1234567L });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CUIT", "apellido", "direccion", "email", "fecha_alta", "nombre", "telefono" },
                values: new object[] { 2, "23-39572450-9", "perez", "av alem 330", "juanperez@gmail.com", new DateTime(2023, 10, 29, 16, 5, 6, 759, DateTimeKind.Local).AddTicks(5942), "Juan", 1234567L });

            migrationBuilder.InsertData(
                table: "Recursos",
                columns: new[] { "Id", "apellido", "nombre", "rol" },
                values: new object[] { 1, "Roman", "Juan", "Analista funcional" });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "ClienteId", "descripcion", "fechaEstimadaEntrega", "fechaFinalizacion", "fechaInicio", "nombre" },
                values: new object[] { 1, 2, "desarrollo de una aplicacion web", new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "proyecto A" });

            migrationBuilder.InsertData(
                table: "cuentaCorrientes",
                columns: new[] { "Id", "ClienteId", "debe", "haber", "saldo" },
                values: new object[] { 1, 1, 0.0, 1000.0, 1000.0 });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "Id", "ClienteId", "ProyectoId", "condicionTributaria", "fechaEmision", "fechaVencimiento", "total" },
                values: new object[] { 1, 1, 1, "Responsable inscripto", new DateTime(2023, 10, 29, 16, 5, 6, 759, DateTimeKind.Local).AddTicks(5973), new DateTime(2024, 3, 29, 16, 5, 6, 759, DateTimeKind.Local).AddTicks(5975), 5000.0 });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "ProyectoId", "RecursoId", "descripcion", "estadoTarea", "fechaInicio", "horasEstimadas", "nombre" },
                values: new object[] { 1, 1, 1, "descripcion de la tarea1", "pendiente", new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 1200, "Tarea1" });
        }
    }
}

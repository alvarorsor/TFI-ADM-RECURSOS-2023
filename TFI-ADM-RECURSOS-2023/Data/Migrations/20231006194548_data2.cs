using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class data2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 6, 16, 45, 47, 966, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CUIT", "apellido", "direccion", "email", "fecha_alta", "nombre", "telefono" },
                values: new object[] { 2, "23-39572450-9", "perez", "av alem 330", "juanperez@gmail.com", new DateTime(2023, 10, 6, 16, 45, 47, 966, DateTimeKind.Local).AddTicks(4076), "Juan", 1234567 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 6, 16, 43, 46, 74, DateTimeKind.Local).AddTicks(8504));
        }
    }
}

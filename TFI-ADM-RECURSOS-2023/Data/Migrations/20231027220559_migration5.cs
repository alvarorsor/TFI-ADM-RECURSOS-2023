using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 19, 5, 58, 983, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 19, 5, 58, 983, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 19, 5, 58, 983, DateTimeKind.Local).AddTicks(6837), new DateTime(2024, 3, 27, 19, 5, 58, 983, DateTimeKind.Local).AddTicks(6839) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 15, 53, 2, 115, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 15, 53, 2, 115, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 15, 53, 2, 115, DateTimeKind.Local).AddTicks(7911), new DateTime(2024, 3, 27, 15, 53, 2, 115, DateTimeKind.Local).AddTicks(7913) });
        }
    }
}

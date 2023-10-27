using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class agregarcuentacorrienteentidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 8, 1, 19, 47, 420, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 8, 1, 19, 47, 420, DateTimeKind.Local).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 8, 1, 19, 47, 420, DateTimeKind.Local).AddTicks(3019), new DateTime(2024, 3, 8, 1, 19, 47, 420, DateTimeKind.Local).AddTicks(3021) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 8, 1, 14, 12, 452, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 8, 1, 14, 12, 452, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 8, 1, 14, 12, 452, DateTimeKind.Local).AddTicks(4221), new DateTime(2024, 3, 8, 1, 14, 12, 452, DateTimeKind.Local).AddTicks(4222) });
        }
    }
}

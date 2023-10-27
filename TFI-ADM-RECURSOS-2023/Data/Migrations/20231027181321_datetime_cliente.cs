using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class datetime_cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_alta",
                table: "Clientes");

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 15, 13, 21, 77, DateTimeKind.Local).AddTicks(1620), new DateTime(2024, 3, 27, 15, 13, 21, 77, DateTimeKind.Local).AddTicks(1622) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_alta",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 14, 55, 3, 45, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 14, 55, 3, 45, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 55, 3, 45, DateTimeKind.Local).AddTicks(4396), new DateTime(2024, 3, 27, 14, 55, 3, 45, DateTimeKind.Local).AddTicks(4397) });
        }
    }
}

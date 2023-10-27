using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class datetime_cliente5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2023, 10, 27, 15, 25, 25, 568, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 15, 25, 25, 568, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 15, 25, 25, 568, DateTimeKind.Local).AddTicks(5597), new DateTime(2024, 3, 27, 15, 25, 25, 568, DateTimeKind.Local).AddTicks(5598) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_alta",
                table: "Clientes");

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 15, 23, 34, 903, DateTimeKind.Local).AddTicks(8720), new DateTime(2024, 3, 27, 15, 23, 34, 903, DateTimeKind.Local).AddTicks(8722) });
        }
    }
}

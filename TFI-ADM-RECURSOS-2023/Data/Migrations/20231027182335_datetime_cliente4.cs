using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class datetime_cliente4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 15, 23, 34, 903, DateTimeKind.Local).AddTicks(8720), new DateTime(2024, 3, 27, 15, 23, 34, 903, DateTimeKind.Local).AddTicks(8722) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 15, 21, 52, 347, DateTimeKind.Local).AddTicks(6934), new DateTime(2024, 3, 27, 15, 21, 52, 347, DateTimeKind.Local).AddTicks(6935) });
        }
    }
}

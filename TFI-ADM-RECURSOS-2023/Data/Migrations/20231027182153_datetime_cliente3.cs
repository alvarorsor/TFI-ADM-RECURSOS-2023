using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class datetime_cliente3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 15, 21, 52, 347, DateTimeKind.Local).AddTicks(6934), new DateTime(2024, 3, 27, 15, 21, 52, 347, DateTimeKind.Local).AddTicks(6935) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 15, 19, 37, 947, DateTimeKind.Local).AddTicks(5148), new DateTime(2024, 3, 27, 15, 19, 37, 947, DateTimeKind.Local).AddTicks(5149) });
        }
    }
}

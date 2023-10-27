using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class long_int_telefonocliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "telefono",
                table: "Clientes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fecha_alta", "telefono" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 55, 3, 45, DateTimeKind.Local).AddTicks(4358), 1234567L });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "fecha_alta", "telefono" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 55, 3, 45, DateTimeKind.Local).AddTicks(4373), 1234567L });

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 55, 3, 45, DateTimeKind.Local).AddTicks(4396), new DateTime(2024, 3, 27, 14, 55, 3, 45, DateTimeKind.Local).AddTicks(4397) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "telefono",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fecha_alta", "telefono" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 48, 23, 122, DateTimeKind.Local).AddTicks(7962), 1234567 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "fecha_alta", "telefono" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 48, 23, 122, DateTimeKind.Local).AddTicks(7976), 1234567 });

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 48, 23, 122, DateTimeKind.Local).AddTicks(8057), new DateTime(2024, 3, 27, 14, 48, 23, 122, DateTimeKind.Local).AddTicks(8059) });
        }
    }
}

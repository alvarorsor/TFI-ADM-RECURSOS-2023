using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class cambiar_tel_cliene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 14, 48, 23, 122, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 14, 48, 23, 122, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 48, 23, 122, DateTimeKind.Local).AddTicks(8057), new DateTime(2024, 3, 27, 14, 48, 23, 122, DateTimeKind.Local).AddTicks(8059) });

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEstimadaEntrega", "fechaFinalizacion", "fechaInicio" },
                values: new object[] { new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1,
                column: "fechaInicio",
                value: new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 8, 1, 22, 38, 136, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 8, 1, 22, 38, 136, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 8, 1, 22, 38, 136, DateTimeKind.Local).AddTicks(3186), new DateTime(2024, 3, 8, 1, 22, 38, 136, DateTimeKind.Local).AddTicks(3188) });

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEstimadaEntrega", "fechaFinalizacion", "fechaInicio" },
                values: new object[] { new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1,
                column: "fechaInicio",
                value: new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}

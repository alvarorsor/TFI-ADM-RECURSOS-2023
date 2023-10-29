using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaFinalizacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 29, 16, 5, 6, 759, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 29, 16, 5, 6, 759, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 29, 16, 5, 6, 759, DateTimeKind.Local).AddTicks(5973), new DateTime(2024, 3, 29, 16, 5, 6, 759, DateTimeKind.Local).AddTicks(5975) });

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEstimadaEntrega", "fechaFinalizacion", "fechaInicio" },
                values: new object[] { new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1,
                column: "fechaInicio",
                value: new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaFinalizacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 20, 57, 29, 75, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "fecha_alta",
                value: new DateTime(2023, 10, 27, 20, 57, 29, 75, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fechaEmision", "fechaVencimiento" },
                values: new object[] { new DateTime(2023, 10, 27, 20, 57, 29, 75, DateTimeKind.Local).AddTicks(4339), new DateTime(2024, 3, 27, 20, 57, 29, 75, DateTimeKind.Local).AddTicks(4340) });

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class agregarcuentacorrienteentidad2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cuentaCorrientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    debe = table.Column<double>(type: "float", nullable: true),
                    haber = table.Column<double>(type: "float", nullable: true),
                    saldo = table.Column<double>(type: "float", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuentaCorrientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cuentaCorrientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "cuentaCorrientes",
                columns: new[] { "Id", "ClienteId", "debe", "haber", "saldo" },
                values: new object[] { 1, 1, 0.0, 1000.0, 1000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_cuentaCorrientes_ClienteId",
                table: "cuentaCorrientes",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cuentaCorrientes");

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
    }
}

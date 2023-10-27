using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linea_de_factura");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linea_de_factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea_de_factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linea_de_factura_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Linea_de_factura",
                columns: new[] { "Id", "FacturaId", "item", "precio" },
                values: new object[] { 1, 1, "Producto 1", 500.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Linea_de_factura_FacturaId",
                table: "Linea_de_factura",
                column: "FacturaId");
        }
    }
}

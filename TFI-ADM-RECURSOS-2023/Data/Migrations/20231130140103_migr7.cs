using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class migr7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cuentaCorrientes_Facturas_FacturaId",
                table: "cuentaCorrientes");

            migrationBuilder.DropIndex(
                name: "IX_cuentaCorrientes_FacturaId",
                table: "cuentaCorrientes");

            migrationBuilder.RenameColumn(
                name: "FacturaId",
                table: "cuentaCorrientes",
                newName: "codigoDocumento");

            migrationBuilder.AlterColumn<double>(
                name: "saldo",
                table: "cuentaCorrientes",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "haber",
                table: "cuentaCorrientes",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "debe",
                table: "cuentaCorrientes",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "codigoDocumento",
                table: "cuentaCorrientes",
                newName: "FacturaId");

            migrationBuilder.AlterColumn<double>(
                name: "saldo",
                table: "cuentaCorrientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "haber",
                table: "cuentaCorrientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "debe",
                table: "cuentaCorrientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cuentaCorrientes_FacturaId",
                table: "cuentaCorrientes",
                column: "FacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_cuentaCorrientes_Facturas_FacturaId",
                table: "cuentaCorrientes",
                column: "FacturaId",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

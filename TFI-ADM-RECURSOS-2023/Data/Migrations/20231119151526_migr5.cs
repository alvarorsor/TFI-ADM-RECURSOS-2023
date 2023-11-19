using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class migr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Clientes_ClienteId",
                table: "Proyectos");

            migrationBuilder.RenameColumn(
                name: "Clientenombre",
                table: "Proyectos",
                newName: "ClienteNombre");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Proyectos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Clientes_ClienteId",
                table: "Proyectos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Clientes_ClienteId",
                table: "Proyectos");

            migrationBuilder.RenameColumn(
                name: "ClienteNombre",
                table: "Proyectos",
                newName: "Clientenombre");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Proyectos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Clientes_ClienteId",
                table: "Proyectos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

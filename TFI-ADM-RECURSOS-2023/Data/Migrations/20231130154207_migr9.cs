using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFI_ADM_RECURSOS_2023.Data.Migrations
{
    public partial class migr9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CUIT",
                table: "Clientes",
                type: "bigint",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CUIT",
                table: "Clientes",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 11);
        }
    }
}

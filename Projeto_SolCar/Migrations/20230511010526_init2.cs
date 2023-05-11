using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_SolCar.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planos_Clientes_ClientesId",
                table: "Planos");

            migrationBuilder.AlterColumn<int>(
                name: "ClientesId",
                table: "Planos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Planos_Clientes_ClientesId",
                table: "Planos",
                column: "ClientesId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planos_Clientes_ClientesId",
                table: "Planos");

            migrationBuilder.AlterColumn<int>(
                name: "ClientesId",
                table: "Planos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Planos_Clientes_ClientesId",
                table: "Planos",
                column: "ClientesId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}

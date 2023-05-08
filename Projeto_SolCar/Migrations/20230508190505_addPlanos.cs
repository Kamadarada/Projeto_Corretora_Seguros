using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_SolCar.Migrations
{
    public partial class addPlanos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientesId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chassi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoFabricacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoModelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quilometragem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCobertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoResedência = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeguroCasa_TipoCobertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Basica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanosMorais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanosEletricos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equipamentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aluguel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vidros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roubo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendaval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alagamentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desmoronamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planos_CLIENTES_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "CLIENTES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planos_ClientesId",
                table: "Planos",
                column: "ClientesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planos");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMuralis.Migrations
{
    public partial class CriandoTabelaPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pediodos",
                columns: table => new
                {
                    Id_prod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_prod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao_prod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca_prod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor_prod = table.Column<double>(type: "float", nullable: false),
                    Quantidade_prod = table.Column<int>(type: "int", nullable: false),
                    DataCadastro_prod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao_prod = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pediodos", x => x.Id_prod);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pediodos");
        }
    }
}

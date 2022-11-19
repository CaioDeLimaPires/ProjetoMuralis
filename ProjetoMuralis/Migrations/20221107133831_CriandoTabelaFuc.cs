using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMuralis.Migrations
{
    public partial class CriandoTabelaFuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id_func = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_func = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_func = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login_fuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha_func = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil_func = table.Column<int>(type: "int", nullable: false),
                    DataCadastro_func = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao_func = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id_func);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMuralis.Migrations
{
    public partial class RelacionandoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                 

            migrationBuilder.AddColumn<int>(
                name: "Func_id",
                table: "Pediodos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Pediodos_Func_id",
                table: "Pediodos",
                column: "Func_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pediodos_Funcionarios_Func_id",
                table: "Pediodos",
                column: "Func_id",
                principalTable: "Funcionarios",
                principalColumn: "Id_func",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pediodos_Funcionarios_Func_id",
                table: "Pediodos");

            migrationBuilder.DropIndex(
                name: "IX_Pediodos_Func_id",
                table: "Pediodos");

            migrationBuilder.DropColumn(
                name: "Func_id",
                table: "Pediodos");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId_func",
                table: "Pediodos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pediodos_UsuarioId_func",
                table: "Pediodos",
                column: "UsuarioId_func");

            migrationBuilder.AddForeignKey(
                name: "FK_Pediodos_Funcionarios_UsuarioId_func",
                table: "Pediodos",
                column: "UsuarioId_func",
                principalTable: "Funcionarios",
                principalColumn: "Id_func");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMuralis.Migrations
{
    public partial class CorrigindoErro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pediodos_Funcionarios_Func_id",
                table: "Pediodos");

            migrationBuilder.AlterColumn<int>(
                name: "Func_id",
                table: "Pediodos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pediodos_Funcionarios_Func_id",
                table: "Pediodos",
                column: "Func_id",
                principalTable: "Funcionarios",
                principalColumn: "Id_func");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pediodos_Funcionarios_Func_id",
                table: "Pediodos");

            migrationBuilder.AlterColumn<int>(
                name: "Func_id",
                table: "Pediodos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pediodos_Funcionarios_Func_id",
                table: "Pediodos",
                column: "Func_id",
                principalTable: "Funcionarios",
                principalColumn: "Id_func",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

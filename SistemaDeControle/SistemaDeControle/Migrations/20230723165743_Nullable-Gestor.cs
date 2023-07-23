using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeControle.Migrations
{
    /// <inheritdoc />
    public partial class NullableGestor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gestores_Departamentos_DepartamentoId",
                table: "Gestores");

            migrationBuilder.DropForeignKey(
                name: "FK_Gestores_Funcionarios_FuncionarioId",
                table: "Gestores");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Gestores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Gestores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Gestores_Departamentos_DepartamentoId",
                table: "Gestores",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gestores_Funcionarios_FuncionarioId",
                table: "Gestores",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gestores_Departamentos_DepartamentoId",
                table: "Gestores");

            migrationBuilder.DropForeignKey(
                name: "FK_Gestores_Funcionarios_FuncionarioId",
                table: "Gestores");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Gestores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Gestores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gestores_Departamentos_DepartamentoId",
                table: "Gestores",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gestores_Funcionarios_FuncionarioId",
                table: "Gestores",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

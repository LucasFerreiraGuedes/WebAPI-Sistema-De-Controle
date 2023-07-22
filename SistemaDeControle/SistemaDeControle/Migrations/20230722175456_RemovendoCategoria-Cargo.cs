using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeControle.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoCategoriaCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Categorias_CategoriaId",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_CategoriaId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Cargos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CategoriaId",
                table: "Funcionarios",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Categorias_CategoriaId",
                table: "Funcionarios",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Categorias_CategoriaId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_CategoriaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Cargos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_CategoriaId",
                table: "Cargos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Categorias_CategoriaId",
                table: "Cargos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

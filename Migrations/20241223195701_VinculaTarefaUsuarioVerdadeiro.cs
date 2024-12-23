using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemadeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class VinculaTarefaUsuarioVerdadeiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioId",
                table: "Tarefa");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Tarefa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioId",
                table: "Tarefa");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

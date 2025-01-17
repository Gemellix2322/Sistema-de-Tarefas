﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemadeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class VinculaTarefaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_UsuarioId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Tarefa");
        }
    }
}

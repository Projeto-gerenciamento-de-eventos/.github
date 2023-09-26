using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorEventos.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaEventoModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaEventoModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarioModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarioModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    TipoUsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsuarioModel_TipoUsuarioModel_TipoUsuarioID",
                        column: x => x.TipoUsuarioID,
                        principalTable: "TipoUsuarioModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventoModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "int", nullable: false),
                    OrganizadorID = table.Column<int>(type: "int", nullable: false),
                    CategoriaEventoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventoModel_CategoriaEventoModel_CategoriaEventoID",
                        column: x => x.CategoriaEventoID,
                        principalTable: "CategoriaEventoModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventoModel_UsuarioModel_OrganizadorID",
                        column: x => x.OrganizadorID,
                        principalTable: "UsuarioModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    TextoComentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComentarioModel_EventoModel_EventoID",
                        column: x => x.EventoID,
                        principalTable: "EventoModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioModel_UsuarioModel_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "UsuarioModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InscricaoModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscricaoModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InscricaoModel_EventoModel_EventoID",
                        column: x => x.EventoID,
                        principalTable: "EventoModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscricaoModel_UsuarioModel_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "UsuarioModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioModel_EventoID",
                table: "ComentarioModel",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioModel_UsuarioID",
                table: "ComentarioModel",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_EventoModel_CategoriaEventoID",
                table: "EventoModel",
                column: "CategoriaEventoID");

            migrationBuilder.CreateIndex(
                name: "IX_EventoModel_OrganizadorID",
                table: "EventoModel",
                column: "OrganizadorID");

            migrationBuilder.CreateIndex(
                name: "IX_InscricaoModel_EventoID",
                table: "InscricaoModel",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_InscricaoModel_UsuarioID",
                table: "InscricaoModel",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModel_TipoUsuarioID",
                table: "UsuarioModel",
                column: "TipoUsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioModel");

            migrationBuilder.DropTable(
                name: "InscricaoModel");

            migrationBuilder.DropTable(
                name: "EventoModel");

            migrationBuilder.DropTable(
                name: "CategoriaEventoModel");

            migrationBuilder.DropTable(
                name: "UsuarioModel");

            migrationBuilder.DropTable(
                name: "TipoUsuarioModel");
        }
    }
}

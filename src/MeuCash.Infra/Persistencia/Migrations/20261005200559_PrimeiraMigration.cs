using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuCash.Infra.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    TipoMovimentacao = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MotivoInativacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(320)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MotivoInativacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Movimentacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Origem = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TipoDespesa = table.Column<int>(type: "int", nullable: true),
                    DataSistema = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroParcela = table.Column<int>(type: "int", nullable: true),
                    TotalParcelas = table.Column<int>(type: "int", nullable: true),
                    Periodicidade = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MotivoInativacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Movimentacao_tb_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tb_Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Conta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroConta = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Agencia = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Banco = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MotivoInativacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Conta_tb_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Meta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    ValorMeta = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Prazo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MotivoInativacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Meta_tb_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "tb_Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Meta_tb_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Conta_UsuarioId",
                table: "tb_Conta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Meta_ContaId",
                table: "tb_Meta",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Meta_UsuarioId",
                table: "tb_Meta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Movimentacao_CategoriaId",
                table: "tb_Movimentacao",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Meta");

            migrationBuilder.DropTable(
                name: "tb_Movimentacao");

            migrationBuilder.DropTable(
                name: "tb_Conta");

            migrationBuilder.DropTable(
                name: "tb_Categoria");

            migrationBuilder.DropTable(
                name: "tb_Usuario");
        }
    }
}

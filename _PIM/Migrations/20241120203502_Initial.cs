using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _PIM.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinhos_AspNetUsers_UsuarioId",
                table: "Carrinhos");

            migrationBuilder.DropTable(
                name: "ItemCarrinho");

            migrationBuilder.DropTable(
                name: "ItensVenda");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinhos",
                table: "Carrinhos");

            migrationBuilder.RenameTable(
                name: "Carrinhos",
                newName: "Carrinho");

            migrationBuilder.RenameColumn(
                name: "Finalizado",
                table: "Carrinho",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "Carrinho",
                newName: "DataAdicao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carrinho",
                newName: "CarrinhoId");

            migrationBuilder.RenameIndex(
                name: "IX_Carrinhos_UsuarioId",
                table: "Carrinho",
                newName: "IX_Carrinho_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Carrinho",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_ProdutoId",
                table: "Carrinho",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_AspNetUsers_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Produto_ProdutoId",
                table: "Carrinho",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_AspNetUsers_UsuarioId",
                table: "Carrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Produto_ProdutoId",
                table: "Carrinho");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho");

            migrationBuilder.DropIndex(
                name: "IX_Carrinho_ProdutoId",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Carrinho");

            migrationBuilder.RenameTable(
                name: "Carrinho",
                newName: "Carrinhos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Carrinhos",
                newName: "Finalizado");

            migrationBuilder.RenameColumn(
                name: "DataAdicao",
                table: "Carrinhos",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "CarrinhoId",
                table: "Carrinhos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinhos",
                newName: "IX_Carrinhos_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinhos",
                table: "Carrinhos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    CEP = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCarrinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarrinhoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusEnvio = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensVenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    VendaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_CarrinhoId",
                table: "ItemCarrinho",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_ProdutoId",
                table: "ItemCarrinho",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_ProdutoId",
                table: "ItensVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_VendaId",
                table: "ItensVenda",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_EnderecoId",
                table: "Vendas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UserId",
                table: "Vendas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinhos_AspNetUsers_UsuarioId",
                table: "Carrinhos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _PIM.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCarrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensCarrinho_Carrinhos_CarrinhoId",
                table: "ItensCarrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensCarrinho_Produto_ProdutoId",
                table: "ItensCarrinho");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensCarrinho",
                table: "ItensCarrinho");

            migrationBuilder.RenameTable(
                name: "ItensCarrinho",
                newName: "ItemCarrinho");

            migrationBuilder.RenameIndex(
                name: "IX_ItensCarrinho_ProdutoId",
                table: "ItemCarrinho",
                newName: "IX_ItemCarrinho_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensCarrinho_CarrinhoId",
                table: "ItemCarrinho",
                newName: "IX_ItemCarrinho_CarrinhoId");

            migrationBuilder.AlterColumn<int>(
                name: "CarrinhoId",
                table: "ItemCarrinho",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCarrinho",
                table: "ItemCarrinho",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinho_Carrinhos_CarrinhoId",
                table: "ItemCarrinho",
                column: "CarrinhoId",
                principalTable: "Carrinhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinho_Produto_ProdutoId",
                table: "ItemCarrinho",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinho_Carrinhos_CarrinhoId",
                table: "ItemCarrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinho_Produto_ProdutoId",
                table: "ItemCarrinho");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCarrinho",
                table: "ItemCarrinho");

            migrationBuilder.RenameTable(
                name: "ItemCarrinho",
                newName: "ItensCarrinho");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarrinho_ProdutoId",
                table: "ItensCarrinho",
                newName: "IX_ItensCarrinho_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarrinho_CarrinhoId",
                table: "ItensCarrinho",
                newName: "IX_ItensCarrinho_CarrinhoId");

            migrationBuilder.AlterColumn<int>(
                name: "CarrinhoId",
                table: "ItensCarrinho",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensCarrinho",
                table: "ItensCarrinho",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCarrinho_Carrinhos_CarrinhoId",
                table: "ItensCarrinho",
                column: "CarrinhoId",
                principalTable: "Carrinhos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCarrinho_Produto_ProdutoId",
                table: "ItensCarrinho",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _PIM.Migrations
{
    /// <inheritdoc />
    public partial class AddEnderecoPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendaId",
                table: "Vendas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemVendaId",
                table: "ItensVenda",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Vendas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Vendas",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    CEP = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_EnderecoId",
                table: "Vendas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Enderecos_EnderecoId",
                table: "Vendas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Enderecos_EnderecoId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_EnderecoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vendas",
                newName: "VendaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItensVenda",
                newName: "ItemVendaId");
        }
    }
}

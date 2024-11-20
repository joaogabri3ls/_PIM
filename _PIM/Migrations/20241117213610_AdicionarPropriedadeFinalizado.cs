using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _PIM.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarPropriedadeFinalizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "Carrinhos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "Carrinhos");
        }
    }
}

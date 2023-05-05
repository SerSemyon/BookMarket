using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMarket.Migrations
{
    /// <inheritdoc />
    public partial class LegalName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "legal_entity",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "legal_entity");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebay.Data.Migrations
{
    public partial class ArtikelName_hinzu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtikelName",
                table: "artikels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtikelName",
                table: "artikels");
        }
    }
}

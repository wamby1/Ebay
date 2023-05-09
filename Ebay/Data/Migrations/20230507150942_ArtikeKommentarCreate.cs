using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebay.Data.Migrations
{
    public partial class ArtikeKommentarCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kommentar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inhalt = table.Column<string>(nullable: true),
                    Erstellungsdatum = table.Column<DateTime>(nullable: false),
                    OwnerUser = table.Column<string>(nullable: true),
                    Artikelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kommentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kommentar_artikels_Artikelid",
                        column: x => x.Artikelid,
                        principalTable: "artikels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kommentar_Artikelid",
                table: "kommentar",
                column: "Artikelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kommentar");
        }
    }
}

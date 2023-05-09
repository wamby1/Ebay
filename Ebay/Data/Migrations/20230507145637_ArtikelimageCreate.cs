using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebay.Data.Migrations
{
    public partial class ArtikelimageCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artikels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikelKategorie = table.Column<string>(nullable: true),
                    ArtikelLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Preis = table.Column<int>(nullable: false),
                    PostDate = table.Column<DateTime>(nullable: false),
                    OwnerUser = table.Column<string>(nullable: true),
                    gesehen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artikels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "artikelsImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(nullable: true),
                    OwnerUser = table.Column<string>(nullable: true),
                    Artikelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artikelsImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_artikelsImage_artikels_Artikelid",
                        column: x => x.Artikelid,
                        principalTable: "artikels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_artikelsImage_Artikelid",
                table: "artikelsImage",
                column: "Artikelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "artikelsImage");

            migrationBuilder.DropTable(
                name: "artikels");
        }
    }
}

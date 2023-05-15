using Microsoft.EntityFrameworkCore.Migrations;

namespace Ebay.Data.Migrations
{
    public partial class navieigenschaft_und_fremdschlüssel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artikelsImage_artikels_Artikelid",
                table: "artikelsImage");

            migrationBuilder.DropForeignKey(
                name: "FK_kommentar_artikels_Artikelid",
                table: "kommentar");

            migrationBuilder.DropColumn(
                name: "OwnerUser",
                table: "kommentar");

            migrationBuilder.DropColumn(
                name: "OwnerUser",
                table: "artikelsImage");

            migrationBuilder.RenameColumn(
                name: "Artikelid",
                table: "kommentar",
                newName: "ArtikelId");

            migrationBuilder.RenameIndex(
                name: "IX_kommentar_Artikelid",
                table: "kommentar",
                newName: "IX_kommentar_ArtikelId");

            migrationBuilder.RenameColumn(
                name: "Artikelid",
                table: "artikelsImage",
                newName: "ArtikelId");

            migrationBuilder.RenameIndex(
                name: "IX_artikelsImage_Artikelid",
                table: "artikelsImage",
                newName: "IX_artikelsImage_ArtikelId");

            migrationBuilder.AlterColumn<int>(
                name: "ArtikelId",
                table: "kommentar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtikelId",
                table: "artikelsImage",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_artikelsImage_artikels_ArtikelId",
                table: "artikelsImage",
                column: "ArtikelId",
                principalTable: "artikels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kommentar_artikels_ArtikelId",
                table: "kommentar",
                column: "ArtikelId",
                principalTable: "artikels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artikelsImage_artikels_ArtikelId",
                table: "artikelsImage");

            migrationBuilder.DropForeignKey(
                name: "FK_kommentar_artikels_ArtikelId",
                table: "kommentar");

            migrationBuilder.RenameColumn(
                name: "ArtikelId",
                table: "kommentar",
                newName: "Artikelid");

            migrationBuilder.RenameIndex(
                name: "IX_kommentar_ArtikelId",
                table: "kommentar",
                newName: "IX_kommentar_Artikelid");

            migrationBuilder.RenameColumn(
                name: "ArtikelId",
                table: "artikelsImage",
                newName: "Artikelid");

            migrationBuilder.RenameIndex(
                name: "IX_artikelsImage_ArtikelId",
                table: "artikelsImage",
                newName: "IX_artikelsImage_Artikelid");

            migrationBuilder.AlterColumn<int>(
                name: "Artikelid",
                table: "kommentar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "OwnerUser",
                table: "kommentar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Artikelid",
                table: "artikelsImage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "OwnerUser",
                table: "artikelsImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_artikelsImage_artikels_Artikelid",
                table: "artikelsImage",
                column: "Artikelid",
                principalTable: "artikels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_kommentar_artikels_Artikelid",
                table: "kommentar",
                column: "Artikelid",
                principalTable: "artikels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

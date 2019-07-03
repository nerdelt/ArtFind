using Microsoft.EntityFrameworkCore.Migrations;

namespace artfind.Migrations
{
    public partial class NewStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryCreated",
                table: "ArtPiece",
                newName: "CurrentLocation");

            migrationBuilder.AlterColumn<int>(
                name: "Dimensions",
                table: "ArtPiece",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentLocation",
                table: "ArtPiece",
                newName: "CountryCreated");

            migrationBuilder.AlterColumn<string>(
                name: "Dimensions",
                table: "ArtPiece",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}

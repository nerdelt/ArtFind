using Microsoft.EntityFrameworkCore.Migrations;

namespace artfind.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "ArtPiece");

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "ArtPiece",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "ArtPiece",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "ArtPiece");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "ArtPiece");

            migrationBuilder.AddColumn<int>(
                name: "Dimensions",
                table: "ArtPiece",
                nullable: false,
                defaultValue: 0);
        }
    }
}

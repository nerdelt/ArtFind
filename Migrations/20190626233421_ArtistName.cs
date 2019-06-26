using Microsoft.EntityFrameworkCore.Migrations;

namespace artfind.Migrations
{
    public partial class ArtistName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dimensions",
                table: "ArtPiece",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Artist",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "ArtPiece");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Artist",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace artfind.Migrations
{
    public partial class ArtPiece : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Art");

            migrationBuilder.CreateTable(
                name: "ArtPiece",
                columns: table => new
                {
                    ArtPieceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ArtistID = table.Column<int>(nullable: false),
                    YearCreated = table.Column<int>(nullable: false),
                    Medium = table.Column<string>(nullable: true),
                    CountryCreated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtPiece", x => x.ArtPieceID);
                    table.ForeignKey(
                        name: "FK_ArtPiece_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtPiece_ArtistID",
                table: "ArtPiece",
                column: "ArtistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtPiece");

            migrationBuilder.CreateTable(
                name: "Art",
                columns: table => new
                {
                    ArtID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistID = table.Column<int>(nullable: false),
                    CountryCreated = table.Column<string>(nullable: true),
                    Medium = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    YearCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art", x => x.ArtID);
                    table.ForeignKey(
                        name: "FK_Art_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Art_ArtistID",
                table: "Art",
                column: "ArtistID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_ASP_DotNet_Project.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeRatingTable",
                columns: table => new
                {
                    AgeRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeRatingTable", x => x.AgeRatingId);
                });

            migrationBuilder.CreateTable(
                name: "DirectorsTable",
                columns: table => new
                {
                    DirectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TheDirectors = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorsTable", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Year Of Release",
                columns: table => new
                {
                    YearOfReleaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year Of Release", x => x.YearOfReleaseId);
                });

            migrationBuilder.CreateTable(
                name: "MovieTable",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieTitle = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: false),
                    YearOfReleaseId = table.Column<int>(nullable: false),
                    AgeRatingId = table.Column<int>(nullable: false),
                    DirectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTable", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_MovieTable_AgeRatingTable_AgeRatingId",
                        column: x => x.AgeRatingId,
                        principalTable: "AgeRatingTable",
                        principalColumn: "AgeRatingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTable_DirectorsTable_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "DirectorsTable",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTable_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTable_Year Of Release_YearOfReleaseId",
                        column: x => x.YearOfReleaseId,
                        principalTable: "Year Of Release",
                        principalColumn: "YearOfReleaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTable_AgeRatingId",
                table: "MovieTable",
                column: "AgeRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTable_DirectorId",
                table: "MovieTable",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTable_GenreId",
                table: "MovieTable",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTable_YearOfReleaseId",
                table: "MovieTable",
                column: "YearOfReleaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTable");

            migrationBuilder.DropTable(
                name: "AgeRatingTable");

            migrationBuilder.DropTable(
                name: "DirectorsTable");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Year Of Release");
        }
    }
}

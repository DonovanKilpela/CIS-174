using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataTransferKilpela.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OlympicGames",
                columns: table => new
                {
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OlympicGames", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_OlympicGames_GameId",
                        column: x => x.GameId,
                        principalTable: "OlympicGames",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OlympicGames",
                columns: new[] { "GameId", "Name" },
                values: new object[,]
                {
                    { "para", "Paralympics" },
                    { "summer", "Summer Olympics" },
                    { "winter", "Winter Olympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Category", "Name" },
                values: new object[,]
                {
                    { "archery", "Indoor", "Archery" },
                    { "bobsleigh", "Outdoor", "Bobsleigh" },
                    { "breakdance", "Indoor", "Breakdancing" },
                    { "canoe", "Outdoor", "Canoe Sprint" },
                    { "curling", "Indoor", "Curling" },
                    { "cycling", "Outdoor", "Road Cycling" },
                    { "diving", "Indoor", "Diving" },
                    { "skate", "Outdoor", "Skateboarding" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "FlagImage", "GameId", "Name", "SportId" },
                values: new object[,]
                {
                    { 1, "Canada.png", "winter", "Canada", "curling" },
                    { 2, "Sweden.png", "winter", "Sweden", "curling" },
                    { 3, "Great_Britain.png", "winter", "Great_Britain", "curling" },
                    { 4, "Jamaica.png", "winter", "Jamaica", "bobsleigh" },
                    { 5, "Italy.png", "winter", "Italy", "bobsleigh" },
                    { 6, "Japan.png", "winter", "Japan", "bobsleigh" },
                    { 7, "Germany.png", "summer", "Germany", "diving" },
                    { 8, "China.png", "summer", "China", "diving" },
                    { 9, "Mexico.png", "summer", "Mexico", "diving" },
                    { 10, "Brazil.png", "summer", "Brazil", "cycling" },
                    { 11, "Netherlands.png", "summer", "Netherlands", "cycling" },
                    { 12, "United_States.png", "summer", "United States", "cycling" },
                    { 13, "Thailand.png", "para", "Thailand", "archery" },
                    { 14, "Uruguay.png", "para", "Uruguay", "archery" },
                    { 15, "Ukraine.png", "para", "Ukraine", "archery" },
                    { 16, "Austria.png", "para", "Austria", "canoe" },
                    { 17, "Pakistan.png", "para", "Pakistan", "canoe" },
                    { 18, "Zimbabwe.png", "para", "Zimbabwe", "canoe" },
                    { 19, "France.png", "youth", "France", "breakdance" },
                    { 20, "Cyprus.png", "youth", "Cyprus", "breakdance" },
                    { 21, "Russia.png", "youth", "Russia", "breakdance" },
                    { 22, "Finland.png", "youth", "Finland", "skate" },
                    { 23, "Slovakia.png", "youth", "Slovakia", "skate" },
                    { 24, "Portugal.png", "youth", "Portugal", "skate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameId",
                table: "Countries",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportId",
                table: "Countries",
                column: "SportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "OlympicGames");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}

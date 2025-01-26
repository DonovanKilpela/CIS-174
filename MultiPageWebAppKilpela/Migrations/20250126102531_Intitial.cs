using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPageWebAppKilpela.Migrations
{
    /// <inheritdoc />
    public partial class Intitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                columns: new[] { "Address", "Name", "Note", "PhoneNumber" },
                values: new object[] { "Japan", "Joji", "Favorite Artist", "123456789" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                columns: new[] { "Address", "Name", "Note", "PhoneNumber" },
                values: new object[] { "2625 Camelot Drive", "Donovan", "Me", "8595769798" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace thub.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class TestUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "LastName", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "sergej.ajlec@gmail.com", "Ajlec", "Sergej", "test123" },
                    { 2, "dejan.ajlec@gmail.com", "Ajlec", "Dejan", "test123" },
                    { 3, "samo.ajlec@gmail.com", "Ajlec", "Samo", "test123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}

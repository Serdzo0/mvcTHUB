using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thub.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class TournamentOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tournaments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_UserId",
                table: "Tournaments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_AspNetUsers_UserId",
                table: "Tournaments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_AspNetUsers_UserId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_UserId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tournaments");
        }
    }
}

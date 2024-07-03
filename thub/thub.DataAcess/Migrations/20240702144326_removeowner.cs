using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thub.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class removeowner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_AspNetUsers_OwnerId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_OwnerId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tournaments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Tournaments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                column: "OwnerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                column: "OwnerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                column: "OwnerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_OwnerId",
                table: "Tournaments",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_AspNetUsers_OwnerId",
                table: "Tournaments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

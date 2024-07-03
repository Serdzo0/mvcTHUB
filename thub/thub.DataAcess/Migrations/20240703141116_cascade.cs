using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thub.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_AspNetUsers_UserId",
                table: "Tournaments");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_AspNetUsers_UserId",
                table: "Tournaments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_AspNetUsers_UserId",
                table: "Tournaments");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_AspNetUsers_UserId",
                table: "Tournaments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

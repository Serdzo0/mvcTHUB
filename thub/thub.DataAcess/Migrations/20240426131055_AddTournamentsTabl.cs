using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace thub.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class AddTournamentsTabl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sport = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumberOfTeams = table.Column<int>(type: "int", nullable: false),
                    NumberOfGroups = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "Name", "NumberOfGroups", "NumberOfTeams", "Sport", "StartDate" },
                values: new object[,]
                {
                    { 1, "Mešane dvojice", 2, 8, "Beach Volleyball", new DateOnly(2024, 5, 20) },
                    { 2, "Dvojice", 2, 8, "Beach Volleyball", new DateOnly(2024, 6, 22) },
                    { 3, "Mešane dvojice", 2, 8, "Beach Volleyball", new DateOnly(2024, 8, 5) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}

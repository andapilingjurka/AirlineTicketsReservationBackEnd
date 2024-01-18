using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketsReservation.Migrations
{
    /// <inheritdoc />
    public partial class MigrimModifikime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Rezervimet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmriPasagjerit",
                table: "Rezervimet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MbiemriPasagjerit",
                table: "Rezervimet",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Rezervimet");

            migrationBuilder.DropColumn(
                name: "EmriPasagjerit",
                table: "Rezervimet");

            migrationBuilder.DropColumn(
                name: "MbiemriPasagjerit",
                table: "Rezervimet");
        }
    }
}

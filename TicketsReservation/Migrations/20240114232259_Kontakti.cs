using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsReservation.Migrations
{
    public partial class Kontakti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumriTelefonit",
                table: "Kontakti");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumriTelefonit",
                table: "Kontakti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

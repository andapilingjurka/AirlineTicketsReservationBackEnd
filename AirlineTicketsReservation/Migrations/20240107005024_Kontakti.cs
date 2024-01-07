using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketsReservation.Migrations
{
    /// <inheritdoc />
    public partial class Kontakti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakti",
                columns: table => new
                {
                    KontaktID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emaili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumriTelefonit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesazhi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakti", x => x.KontaktID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakti");
        }
    }
}

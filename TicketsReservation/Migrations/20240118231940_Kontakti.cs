using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsReservation.Migrations
{
    public partial class Kontakti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakti",
                columns: table => new
                {
                    KontaktID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emaili = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesazhi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakti", x => x.KontaktID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakti");
        }
    }
}

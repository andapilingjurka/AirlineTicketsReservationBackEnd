using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketsReservation.Migrations
{
    /// <inheritdoc />
    public partial class RezervimetNdryshim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervimet_Perdoruesit_PerdoruesiId",
                table: "Rezervimet");

            migrationBuilder.DropIndex(
                name: "IX_Rezervimet_PerdoruesiId",
                table: "Rezervimet");

            migrationBuilder.DropColumn(
                name: "PerdoruesiId",
                table: "Rezervimet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerdoruesiId",
                table: "Rezervimet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervimet_PerdoruesiId",
                table: "Rezervimet",
                column: "PerdoruesiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervimet_Perdoruesit_PerdoruesiId",
                table: "Rezervimet",
                column: "PerdoruesiId",
                principalTable: "Perdoruesit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

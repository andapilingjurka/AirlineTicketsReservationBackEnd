using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketsReservation.Migrations
{
    /// <inheritdoc />
    public partial class RezervimetFshirja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakti");

            migrationBuilder.DropTable(
                name: "Rezervimet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakti",
                columns: table => new
                {
                    KontaktID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emaili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesazhi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumriTelefonit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakti", x => x.KontaktID);
                });

            migrationBuilder.CreateTable(
                name: "Rezervimet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FluturimiId = table.Column<int>(type: "int", nullable: false),
                    Cmimi = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_e_Kthimit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data_e_Rezervimit = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmriPasagjerit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Klasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kthyese = table.Column<bool>(type: "bit", nullable: false),
                    MbiemriPasagjerit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervimet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervimet_Fluturimet_FluturimiId",
                        column: x => x.FluturimiId,
                        principalTable: "Fluturimet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervimet_FluturimiId",
                table: "Rezervimet",
                column: "FluturimiId");
        }
    }
}

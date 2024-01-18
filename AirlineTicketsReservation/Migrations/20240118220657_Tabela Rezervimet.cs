using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketsReservation.Migrations
{
    /// <inheritdoc />
    public partial class TabelaRezervimet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezervimet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriPasagjerit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MbiemriPasagjerit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Klasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cmimi = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FluturimiId = table.Column<int>(type: "int", nullable: false),
                    Kthyese = table.Column<bool>(type: "bit", nullable: false),
                    PerdoruesiId = table.Column<int>(type: "int", nullable: false),
                    Data_e_Rezervimit = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Data_e_Kthimit = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Rezervimet_Perdoruesit_PerdoruesiId",
                        column: x => x.PerdoruesiId,
                        principalTable: "Perdoruesit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervimet_FluturimiId",
                table: "Rezervimet",
                column: "FluturimiId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervimet_PerdoruesiId",
                table: "Rezervimet",
                column: "PerdoruesiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervimet");
        }
    }
}

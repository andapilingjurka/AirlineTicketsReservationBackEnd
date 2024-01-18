using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketsReservation.Migrations
{
    /// <inheritdoc />
    public partial class Migrimett : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeroplani",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr_Uleseve_VIP = table.Column<int>(type: "int", nullable: false),
                    Nr_Uleseve_Biznes = table.Column<int>(type: "int", nullable: false),
                    Nr_Uleseve_Ekonomike = table.Column<int>(type: "int", nullable: false),
                    Kompania = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroplani", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perdoruesit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perdoruesit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shteti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shteti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qyteti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShtetiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qyteti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qyteti_Shteti_ShtetiId",
                        column: x => x.ShtetiId,
                        principalTable: "Shteti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fluturimet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrFluturimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeparuteAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KohaENisjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KohaEArritjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cmimi = table.Column<int>(type: "int", nullable: false),
                    QytetiId = table.Column<int>(type: "int", nullable: false),
                    AeroplaniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluturimet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fluturimet_Aeroplani_AeroplaniId",
                        column: x => x.AeroplaniId,
                        principalTable: "Aeroplani",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fluturimet_Qyteti_QytetiId",
                        column: x => x.QytetiId,
                        principalTable: "Qyteti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervimi",
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
                    Data_e_Rezervimit = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Data_e_Kthimit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervimi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervimi_Fluturimet_FluturimiId",
                        column: x => x.FluturimiId,
                        principalTable: "Fluturimet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluturimet_AeroplaniId",
                table: "Fluturimet",
                column: "AeroplaniId");

            migrationBuilder.CreateIndex(
                name: "IX_Fluturimet_QytetiId",
                table: "Fluturimet",
                column: "QytetiId");

            migrationBuilder.CreateIndex(
                name: "IX_Qyteti_ShtetiId",
                table: "Qyteti",
                column: "ShtetiId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervimi_FluturimiId",
                table: "Rezervimi",
                column: "FluturimiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perdoruesit");

            migrationBuilder.DropTable(
                name: "Rezervimi");

            migrationBuilder.DropTable(
                name: "Fluturimet");

            migrationBuilder.DropTable(
                name: "Aeroplani");

            migrationBuilder.DropTable(
                name: "Qyteti");

            migrationBuilder.DropTable(
                name: "Shteti");
        }
    }
}

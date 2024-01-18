using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketsReservation.Migrations
{
    /// <inheritdoc />
    public partial class Migrimet1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervimi_Fluturimet_FluturimiId",
                table: "Rezervimi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervimi",
                table: "Rezervimi");

            migrationBuilder.RenameTable(
                name: "Rezervimi",
                newName: "Rezervimet");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervimi_FluturimiId",
                table: "Rezervimet",
                newName: "IX_Rezervimet_FluturimiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervimet",
                table: "Rezervimet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervimet_Fluturimet_FluturimiId",
                table: "Rezervimet",
                column: "FluturimiId",
                principalTable: "Fluturimet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervimet_Fluturimet_FluturimiId",
                table: "Rezervimet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervimet",
                table: "Rezervimet");

            migrationBuilder.RenameTable(
                name: "Rezervimet",
                newName: "Rezervimi");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervimet_FluturimiId",
                table: "Rezervimi",
                newName: "IX_Rezervimi_FluturimiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervimi",
                table: "Rezervimi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervimi_Fluturimet_FluturimiId",
                table: "Rezervimi",
                column: "FluturimiId",
                principalTable: "Fluturimet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

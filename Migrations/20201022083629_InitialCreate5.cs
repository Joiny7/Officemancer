using Microsoft.EntityFrameworkCore.Migrations;

namespace Platypus.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Floors_Offices_OfficeID",
                table: "Floors");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Floors_FloorID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_FloorID",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeID",
                table: "Floors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Floors_Offices_OfficeID",
                table: "Floors",
                column: "OfficeID",
                principalTable: "Offices",
                principalColumn: "OfficeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Floors_Offices_OfficeID",
                table: "Floors");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeID",
                table: "Floors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FloorID",
                table: "Reservations",
                column: "FloorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Floors_Offices_OfficeID",
                table: "Floors",
                column: "OfficeID",
                principalTable: "Offices",
                principalColumn: "OfficeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Floors_FloorID",
                table: "Reservations",
                column: "FloorID",
                principalTable: "Floors",
                principalColumn: "FloorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

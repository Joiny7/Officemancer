using Microsoft.EntityFrameworkCore.Migrations;

namespace Officemancer.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Reservations_ReservationID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ReservationID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReservationID",
                table: "Users",
                column: "ReservationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Reservations_ReservationID",
                table: "Users",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

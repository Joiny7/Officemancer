using Microsoft.EntityFrameworkCore.Migrations;

namespace Officemancer.Migrations
{
    public partial class Remove_Mancers_from_Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mancers",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mancers",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);
        }
    }
}

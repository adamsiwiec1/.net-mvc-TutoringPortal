using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup12.Migrations
{
    public partial class AddedTicketCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TicketCost",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TicketPaid",
                table: "Ticket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCost",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TicketPaid",
                table: "Ticket");
        }
    }
}

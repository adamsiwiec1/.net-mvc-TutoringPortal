using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup12.Migrations
{
    public partial class CourseFKEYintoTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Ticket",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CourseID",
                table: "Ticket",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Course_CourseID",
                table: "Ticket",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Course_CourseID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CourseID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Ticket");
        }
    }
}

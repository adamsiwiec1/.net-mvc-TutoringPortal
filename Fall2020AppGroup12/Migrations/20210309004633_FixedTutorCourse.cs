using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup12.Migrations
{
    public partial class FixedTutorCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketDetail_TicketDetailID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorCourse_AspNetUsers_ApplicationUserID",
                table: "TutorCourse");

            migrationBuilder.DropTable(
                name: "TicketDetail");

            migrationBuilder.DropIndex(
                name: "IX_TutorCourse_ApplicationUserID",
                table: "TutorCourse");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TicketDetailID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "TutorCourse");

            migrationBuilder.DropColumn(
                name: "TicketDetailID",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "TutorID",
                table: "TutorCourse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SessionRating",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subdivision",
                table: "Ticket",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TutorCourse_TutorID",
                table: "TutorCourse",
                column: "TutorID");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorCourse_AspNetUsers_TutorID",
                table: "TutorCourse",
                column: "TutorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorCourse_AspNetUsers_TutorID",
                table: "TutorCourse");

            migrationBuilder.DropIndex(
                name: "IX_TutorCourse_TutorID",
                table: "TutorCourse");

            migrationBuilder.DropColumn(
                name: "TutorID",
                table: "TutorCourse");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SessionRating",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Subdivision",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "TutorCourse",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketDetailID",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketDetail",
                columns: table => new
                {
                    TicketDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionRating = table.Column<double>(type: "float", nullable: true),
                    Subdivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetail", x => x.TicketDetailID);
                    table.ForeignKey(
                        name: "FK_TicketDetail_Ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorCourse_ApplicationUserID",
                table: "TutorCourse",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketDetailID",
                table: "Ticket",
                column: "TicketDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetail_TicketID",
                table: "TicketDetail",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketDetail_TicketDetailID",
                table: "Ticket",
                column: "TicketDetailID",
                principalTable: "TicketDetail",
                principalColumn: "TicketDetailID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorCourse_AspNetUsers_ApplicationUserID",
                table: "TutorCourse",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup12.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TutorId",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_TutorId",
                table: "Course",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_TutorId",
                table: "Course",
                column: "TutorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_TutorId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_TutorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Course");
        }
    }
}

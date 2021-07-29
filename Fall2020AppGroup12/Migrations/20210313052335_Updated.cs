using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup12.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MajorID1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tutor_MajorID1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MajorID1",
                table: "AspNetUsers",
                column: "MajorID1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Tutor_MajorID1",
                table: "AspNetUsers",
                column: "Tutor_MajorID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Major_MajorID1",
                table: "AspNetUsers",
                column: "MajorID1",
                principalTable: "Major",
                principalColumn: "MajorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Major_Tutor_MajorID1",
                table: "AspNetUsers",
                column: "Tutor_MajorID1",
                principalTable: "Major",
                principalColumn: "MajorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Major_MajorID1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Major_Tutor_MajorID1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MajorID1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Tutor_MajorID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MajorID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tutor_MajorID1",
                table: "AspNetUsers");
        }
    }
}

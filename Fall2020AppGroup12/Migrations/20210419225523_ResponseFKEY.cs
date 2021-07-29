using Microsoft.EntityFrameworkCore.Migrations;

namespace Fall2020AppGroup12.Migrations
{
    public partial class ResponseFKEY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Response",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Response_UserId",
                table: "Response",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_AspNetUsers_UserId",
                table: "Response",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_AspNetUsers_UserId",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_UserId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Response");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

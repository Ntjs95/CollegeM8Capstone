using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeM8.Migrations
{
    public partial class SleepOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sleep_SleepUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SleepUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SleepUserId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Sleep_Users_UserId",
                table: "Sleep",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sleep_Users_UserId",
                table: "Sleep");

            migrationBuilder.AddColumn<string>(
                name: "SleepUserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SleepUserId",
                table: "Users",
                column: "SleepUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sleep_SleepUserId",
                table: "Users",
                column: "SleepUserId",
                principalTable: "Sleep",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

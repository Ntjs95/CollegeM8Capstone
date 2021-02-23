using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeM8.Migrations
{
    public partial class TableLinkLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SleepUserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Term",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Schedule",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Logins",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SleepUserId",
                table: "Users",
                column: "SleepUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Term_UserId",
                table: "Term",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_UserId",
                table: "Schedule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TermId",
                table: "Classes",
                column: "TermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Term_TermId",
                table: "Classes",
                column: "TermId",
                principalTable: "Term",
                principalColumn: "TermId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Users_UserId",
                table: "Logins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Users_UserId",
                table: "Schedule",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Term_Users_UserId",
                table: "Term",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sleep_SleepUserId",
                table: "Users",
                column: "SleepUserId",
                principalTable: "Sleep",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Term_TermId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Users_UserId",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Users_UserId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Term_Users_UserId",
                table: "Term");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sleep_SleepUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SleepUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Term_UserId",
                table: "Term");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_UserId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Logins_UserId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TermId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SleepUserId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Term",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermId",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

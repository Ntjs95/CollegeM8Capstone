using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeM8.Migrations
{
    public partial class ColumnNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Satday",
                table: "Classes",
                newName: "Saturday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Saturday",
                table: "Classes",
                newName: "Satday");
        }
    }
}

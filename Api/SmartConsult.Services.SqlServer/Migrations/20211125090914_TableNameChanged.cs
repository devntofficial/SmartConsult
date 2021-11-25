using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartConsult.Services.SqlServer.Migrations
{
    public partial class TableNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MemberProfiles",
                newName: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Members",
                newName: "MemberProfiles");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartConsult.Services.SqlServer.Migrations
{
    public partial class ColumnChangedToIdInMemberProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberProfiles",
                table: "MemberProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "Id",
                table: "MemberProfiles",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Id",
                table: "MemberProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberProfiles",
                table: "MemberProfiles",
                column: "ProfileId");
        }
    }
}

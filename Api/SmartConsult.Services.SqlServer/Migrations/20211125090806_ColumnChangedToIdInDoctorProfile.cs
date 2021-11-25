using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartConsult.Services.SqlServer.Migrations
{
    public partial class ColumnChangedToIdInDoctorProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "DoctorProfiles",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DoctorProfiles",
                newName: "ProfileId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class UserLocationCoordAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LatLong",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatLong",
                table: "Users");
        }
    }
}

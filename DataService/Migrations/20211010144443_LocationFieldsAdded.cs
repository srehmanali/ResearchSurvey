using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class LocationFieldsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Users",
                newName: "AssignedLocationLatLong");

            migrationBuilder.RenameColumn(
                name: "LatLong",
                table: "Users",
                newName: "AssignedLocation");

            migrationBuilder.AddColumn<string>(
                name: "AssingedLocationLatLong",
                table: "Responses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssingedLocationName",
                table: "Responses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssingedLocationLatLong",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "AssingedLocationName",
                table: "Responses");

            migrationBuilder.RenameColumn(
                name: "AssignedLocationLatLong",
                table: "Users",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "AssignedLocation",
                table: "Users",
                newName: "LatLong");
        }
    }
}

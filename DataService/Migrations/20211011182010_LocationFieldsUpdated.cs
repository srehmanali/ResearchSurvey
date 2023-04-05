using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class LocationFieldsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssingedLocationName",
                table: "Responses",
                newName: "AssignedLocationLatLong");

            migrationBuilder.RenameColumn(
                name: "AssingedLocationLatLong",
                table: "Responses",
                newName: "AssignedLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssignedLocationLatLong",
                table: "Responses",
                newName: "AssingedLocationName");

            migrationBuilder.RenameColumn(
                name: "AssignedLocation",
                table: "Responses",
                newName: "AssingedLocationLatLong");
        }
    }
}

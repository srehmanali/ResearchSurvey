using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class ResponseTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LatLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    O1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    O2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    O3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    O4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    O5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q10a = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q10b = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q10c = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q10d = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q10e = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q12a = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q12b = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q12c = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q12d = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_UserId",
                table: "Responses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}

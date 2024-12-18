using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDogApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAdoptApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sizeLbs",
                table: "Dog",
                newName: "SizeLbs");

            migrationBuilder.RenameColumn(
                name: "healthInfo",
                table: "Dog",
                newName: "HealthInfo");

            migrationBuilder.RenameColumn(
                name: "adoptionStatus",
                table: "Dog",
                newName: "AdoptionStatus");

            migrationBuilder.CreateTable(
                name: "AdoptApp",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationParagraph = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptApp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptApp");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.RenameColumn(
                name: "SizeLbs",
                table: "Dog",
                newName: "sizeLbs");

            migrationBuilder.RenameColumn(
                name: "HealthInfo",
                table: "Dog",
                newName: "healthInfo");

            migrationBuilder.RenameColumn(
                name: "AdoptionStatus",
                table: "Dog",
                newName: "adoptionStatus");
        }
    }
}

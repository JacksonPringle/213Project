using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDogApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedParamsToDogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adoptionStatus",
                table: "Dog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "healthInfo",
                table: "Dog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sizeLbs",
                table: "Dog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adoptionStatus",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "healthInfo",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "sizeLbs",
                table: "Dog");
        }
    }
}

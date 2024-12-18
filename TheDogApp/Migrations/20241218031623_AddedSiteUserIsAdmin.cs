﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheDogApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSiteUserIsAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "SiteUser",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "SiteUser");
        }
    }
}

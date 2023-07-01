﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace career_api_server.Migrations
{
    /// <inheritdoc />
    public partial class addeddescriptiontoopportunity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Opportunities",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Opportunities");
        }
    }
}

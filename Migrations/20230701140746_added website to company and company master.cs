using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace career_api_server.Migrations
{
    /// <inheritdoc />
    public partial class addedwebsitetocompanyandcompanymaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "CompanyMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Website",
                table: "CompanyMasters");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Companies");
        }
    }
}

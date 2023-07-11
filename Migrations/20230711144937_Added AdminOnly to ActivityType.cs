using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace career_api_server.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminOnlytoActivityType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminOnly",
                table: "ActivityTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminOnly",
                table: "ActivityTypes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace career_api_server.Migrations
{
    /// <inheritdoc />
    public partial class fixedspellingofcompanyconnectionconnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Connnection",
                table: "CompanyConnections",
                newName: "Connection");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Connection",
                table: "CompanyConnections",
                newName: "Connnection");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandScapeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "service",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "service",
                table: "Customers");
        }
    }
}

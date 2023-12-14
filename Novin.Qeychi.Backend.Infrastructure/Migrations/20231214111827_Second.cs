using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novin.Qeychi.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "ConfirmationEmployments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "ConfirmationEmployments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "ConfirmationEmployments");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "ConfirmationEmployments");
        }
    }
}

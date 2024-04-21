using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class testingd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChosenSize",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChosenSize",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

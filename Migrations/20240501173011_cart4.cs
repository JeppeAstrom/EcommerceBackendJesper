using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class cart4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "CartItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "CartItems",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CartItems",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CartItems",
                newName: "ProductDescription");
        }
    }
}

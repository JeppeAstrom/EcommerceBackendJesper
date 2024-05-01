using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class cart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "CartItems",
                newName: "ProductId");

            migrationBuilder.AddColumn<string>(
                name: "ChosenSize",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChosenSize",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntity_AspNetUsers_AppUserId",
                table: "ReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewEntity_Products_ProductId",
                table: "ReviewEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewEntity",
                table: "ReviewEntity");

            migrationBuilder.RenameTable(
                name: "ReviewEntity",
                newName: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntity_ProductId",
                table: "Reviews",
                newName: "IX_Reviews_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewEntity_AppUserId",
                table: "Reviews",
                newName: "IX_Reviews_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_AppUserId",
                table: "Reviews",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_AppUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "ReviewEntity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReviewEntity",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProductId",
                table: "ReviewEntity",
                newName: "IX_ReviewEntity_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_AppUserId",
                table: "ReviewEntity",
                newName: "IX_ReviewEntity_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewEntity",
                table: "ReviewEntity",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntity_AspNetUsers_AppUserId",
                table: "ReviewEntity",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewEntity_Products_ProductId",
                table: "ReviewEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

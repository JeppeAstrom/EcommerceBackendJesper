using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddressPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressEntity_AspNetUsers_AppUserId",
                table: "AddressEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_AddressEntity_AddressId",
                table: "OrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressEntity",
                table: "AddressEntity");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AddressEntity");

            migrationBuilder.RenameTable(
                name: "AddressEntity",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_AddressEntity_AppUserId",
                table: "Address",
                newName: "IX_Address_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_AppUserId",
                table: "Address",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_Address_AddressId",
                table: "OrderEntity",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_AppUserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_Address_AddressId",
                table: "OrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "AddressEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Address_AppUserId",
                table: "AddressEntity",
                newName: "IX_AddressEntity_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AddressEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressEntity",
                table: "AddressEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressEntity_AspNetUsers_AppUserId",
                table: "AddressEntity",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_AddressEntity_AddressId",
                table: "OrderEntity",
                column: "AddressId",
                principalTable: "AddressEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

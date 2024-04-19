using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_Address_AddressId",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_AspNetUsers_AppUserId",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_PaymentDetails_PaymentDetailId",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductEntity_OrderEntity_OrderId",
                table: "OrderProductEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEntity",
                table: "OrderEntity");

            migrationBuilder.RenameTable(
                name: "OrderEntity",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_PaymentDetailId",
                table: "Order",
                newName: "IX_Order_PaymentDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_AppUserId",
                table: "Order",
                newName: "IX_Order_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_AddressId",
                table: "Order",
                newName: "IX_Order_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_AppUserId",
                table: "Order",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentDetails_PaymentDetailId",
                table: "Order",
                column: "PaymentDetailId",
                principalTable: "PaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductEntity_Order_OrderId",
                table: "OrderProductEntity",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_AppUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentDetails_PaymentDetailId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductEntity_Order_OrderId",
                table: "OrderProductEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "OrderEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PaymentDetailId",
                table: "OrderEntity",
                newName: "IX_OrderEntity_PaymentDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AppUserId",
                table: "OrderEntity",
                newName: "IX_OrderEntity_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AddressId",
                table: "OrderEntity",
                newName: "IX_OrderEntity_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEntity",
                table: "OrderEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_Address_AddressId",
                table: "OrderEntity",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_AspNetUsers_AppUserId",
                table: "OrderEntity",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_PaymentDetails_PaymentDetailId",
                table: "OrderEntity",
                column: "PaymentDetailId",
                principalTable: "PaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductEntity_OrderEntity_OrderId",
                table: "OrderProductEntity",
                column: "OrderId",
                principalTable: "OrderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

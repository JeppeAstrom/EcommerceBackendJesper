using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_PaymentDetailEntity_PaymentDetailId",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetailEntity_AspNetUsers_AppUserId",
                table: "PaymentDetailEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentDetailEntity",
                table: "PaymentDetailEntity");

            migrationBuilder.RenameTable(
                name: "PaymentDetailEntity",
                newName: "PaymentDetails");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetailEntity_AppUserId",
                table: "PaymentDetails",
                newName: "IX_PaymentDetails_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentDetails",
                table: "PaymentDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_PaymentDetails_PaymentDetailId",
                table: "OrderEntity",
                column: "PaymentDetailId",
                principalTable: "PaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_AspNetUsers_AppUserId",
                table: "PaymentDetails",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_PaymentDetails_PaymentDetailId",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_AspNetUsers_AppUserId",
                table: "PaymentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentDetails",
                table: "PaymentDetails");

            migrationBuilder.RenameTable(
                name: "PaymentDetails",
                newName: "PaymentDetailEntity");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetails_AppUserId",
                table: "PaymentDetailEntity",
                newName: "IX_PaymentDetailEntity_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentDetailEntity",
                table: "PaymentDetailEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_PaymentDetailEntity_PaymentDetailId",
                table: "OrderEntity",
                column: "PaymentDetailId",
                principalTable: "PaymentDetailEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetailEntity_AspNetUsers_AppUserId",
                table: "PaymentDetailEntity",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

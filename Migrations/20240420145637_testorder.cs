using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class testorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductSchema_Orders_OrderEntityId",
                table: "OrderProductSchema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductSchema",
                table: "OrderProductSchema");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductSchema_OrderEntityId",
                table: "OrderProductSchema");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "OrderProductSchema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderEntityId",
                table: "OrderProductSchema",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductSchema",
                table: "OrderProductSchema",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductSchema_OrderEntityId",
                table: "OrderProductSchema",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductSchema_Orders_OrderEntityId",
                table: "OrderProductSchema",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}

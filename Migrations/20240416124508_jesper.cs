using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class jesper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_ProductEntityID",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ProductEntityID",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ProductEntityID",
                table: "Sizes");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Sizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductId",
                table: "Sizes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_ProductId",
                table: "Sizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_ProductId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ProductId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sizes");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductEntityID",
                table: "Sizes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductEntityID",
                table: "Sizes",
                column: "ProductEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_ProductEntityID",
                table: "Sizes",
                column: "ProductEntityID",
                principalTable: "Products",
                principalColumn: "ID");
        }
    }
}

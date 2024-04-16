using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class removesizeforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_ProductGroups_ProductGroupId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ProductGroupId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "Sizes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductGroupId",
                table: "Sizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductGroupId",
                table: "Sizes",
                column: "ProductGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_ProductGroups_ProductGroupId",
                table: "Sizes",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

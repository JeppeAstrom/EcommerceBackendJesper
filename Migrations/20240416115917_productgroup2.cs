using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class productgroup2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeEntity_ProductGroups_ProductGroupId",
                table: "SizeEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeEntity_Products_ProductEntityID",
                table: "SizeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeEntity",
                table: "SizeEntity");

            migrationBuilder.RenameTable(
                name: "SizeEntity",
                newName: "Sizes");

            migrationBuilder.RenameIndex(
                name: "IX_SizeEntity_ProductGroupId",
                table: "Sizes",
                newName: "IX_Sizes_ProductGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_SizeEntity_ProductEntityID",
                table: "Sizes",
                newName: "IX_Sizes_ProductEntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_ProductGroups_ProductGroupId",
                table: "Sizes",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_ProductEntityID",
                table: "Sizes",
                column: "ProductEntityID",
                principalTable: "Products",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_ProductGroups_ProductGroupId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_ProductEntityID",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "SizeEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_ProductGroupId",
                table: "SizeEntity",
                newName: "IX_SizeEntity_ProductGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Sizes_ProductEntityID",
                table: "SizeEntity",
                newName: "IX_SizeEntity_ProductEntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeEntity",
                table: "SizeEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeEntity_ProductGroups_ProductGroupId",
                table: "SizeEntity",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeEntity_Products_ProductEntityID",
                table: "SizeEntity",
                column: "ProductEntityID",
                principalTable: "Products",
                principalColumn: "ID");
        }
    }
}

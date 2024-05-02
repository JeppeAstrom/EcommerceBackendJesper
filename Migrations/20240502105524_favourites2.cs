using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class favourites2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Favourites_FavouriteEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FavouriteEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FavouriteEntityId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "FavouriteProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavouriteEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteProduct_Favourites_FavouriteEntityId",
                        column: x => x.FavouriteEntityId,
                        principalTable: "Favourites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavouriteProduct_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProduct_FavouriteEntityId",
                table: "FavouriteProduct",
                column: "FavouriteEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProduct_ProductID",
                table: "FavouriteProduct",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "FavouriteEntityId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavouriteEntityId",
                table: "Products",
                column: "FavouriteEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Favourites_FavouriteEntityId",
                table: "Products",
                column: "FavouriteEntityId",
                principalTable: "Favourites",
                principalColumn: "Id");
        }
    }
}

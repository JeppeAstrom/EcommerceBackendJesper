using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackend.Migrations
{
    /// <inheritdoc />
    public partial class favourites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FavouriteEntityId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favourites_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavouriteEntityId",
                table: "Products",
                column: "FavouriteEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_AppUserId",
                table: "Favourites",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Favourites_FavouriteEntityId",
                table: "Products",
                column: "FavouriteEntityId",
                principalTable: "Favourites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Favourites_FavouriteEntityId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Products_FavouriteEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FavouriteEntityId",
                table: "Products");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductVariantId",
                table: "Orders",
                column: "ProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductVariants_ProductVariantId",
                table: "Orders",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductVariants_ProductVariantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductVariantId",
                table: "Orders");
        }
    }
}

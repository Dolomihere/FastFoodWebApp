using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_NET104.Migrations
{
    /// <inheritdoc />
    public partial class MakeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "OrderDetails",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "DetailOrderId",
                table: "OrderDetails",
                newName: "OrderItemId");

            migrationBuilder.AddColumn<string>(
                name: "FoodItemName",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FoodItemImage",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodItemName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodItemName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "FoodItemImage",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "FoodItemName",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDetails",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "OrderDetails",
                newName: "DetailOrderId");
        }
    }
}

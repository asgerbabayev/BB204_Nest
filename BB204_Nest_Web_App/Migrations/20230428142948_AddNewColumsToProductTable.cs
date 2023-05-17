using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB204_Nest_Web_App.Migrations
{
    public partial class AddNewColumsToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "SellPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "Products",
                newName: "Price");
        }
    }
}

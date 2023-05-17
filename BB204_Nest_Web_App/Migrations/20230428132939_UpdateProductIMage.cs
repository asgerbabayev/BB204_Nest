using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB204_Nest_Web_App.Migrations
{
    public partial class UpdateProductIMage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMain",
                table: "ProductImages",
                newName: "IsFront");

            migrationBuilder.AddColumn<int>(
                name: "StockCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBack",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsBack",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "IsFront",
                table: "ProductImages",
                newName: "IsMain");
        }
    }
}

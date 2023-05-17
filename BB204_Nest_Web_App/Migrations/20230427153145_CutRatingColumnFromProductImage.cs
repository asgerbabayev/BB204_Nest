using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB204_Nest_Web_App.Migrations
{
    public partial class CutRatingColumnFromProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ProductImages");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "ProductImages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

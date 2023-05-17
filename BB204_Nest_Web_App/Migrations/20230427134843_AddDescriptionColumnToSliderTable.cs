using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB204_Nest_Web_App.Migrations
{
    public partial class AddDescriptionColumnToSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sliders");
        }
    }
}

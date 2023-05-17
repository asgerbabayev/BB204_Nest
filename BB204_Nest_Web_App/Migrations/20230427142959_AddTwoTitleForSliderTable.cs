using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB204_Nest_Web_App.Migrations
{
    public partial class AddTwoTitleForSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Sliders",
                newName: "Title2");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Sliders",
                newName: "Title1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "Sliders",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Title1",
                table: "Sliders",
                newName: "Description");
        }
    }
}

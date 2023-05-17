using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB204_Nest_Web_App.Migrations
{
    public partial class CreateCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
        name: "Comments",
        columns: table => new
        {
            Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Date = table.Column<DateTime>(type: "datetime2", nullable: true),
            ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
            ApplicationUserId = table.Column<int>(type: "int", nullable: false),
            ProductId = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Comments", x => x.Id);
            table.ForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId1",
                column: x => x.ApplicationUserId1,
                principalTable: "AspNetUsers",
                principalColumn: "Id");
            table.ForeignKey(
                name: "FK_Comments_Products_ProductId",
                column: x => x.ProductId,
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        });



            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId1",
                table: "Comments",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}

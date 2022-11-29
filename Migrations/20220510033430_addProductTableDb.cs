using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CG_VAK_BooksWeb.Migrations
{
    public partial class addProductTableDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    stock = table.Column<int>(type: "nvarchar(1000)", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

        }
    }
}

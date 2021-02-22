using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsApiCrudOperation.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    prodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prodType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    prodPrice = table.Column<int>(type: "int", maxLength: 7, nullable: false),
                    prodManufacturer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    prodRating = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    YearOfManuf = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.prodId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

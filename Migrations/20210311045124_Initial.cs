using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeAmazon.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    AuthorFirst = table.Column<string>(nullable: false),
                    AuthorMiddle = table.Column<string>(nullable: true),
                    AuthorLast = table.Column<string>(nullable: false),
                    Publisher = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Classification = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Pages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}

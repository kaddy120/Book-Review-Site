using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Isbn = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Authour = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Isbn);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Isbn = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Books_Isbn",
                        column: x => x.Isbn,
                        principalTable: "Books",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Isbn", "Authour", "ThumbnailUrl", "Title", "Year" },
                values: new object[,]
                {
                    { "0553803700", " Robot\"", "http://books.google.com/books/content?id=QEhWPgAACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api", "\"I", "Isaac Asimov" },
                    { "0375913750", " Stargirl\"", "http://books.google.com/books/content?id=G9taxgEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api", "\"Love", "Jerry Spinelli" },
                    { "0743454553", "Jodi Picoult", "http://books.google.com/books/content?id=33Q_BAAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api", "Vanishing Acts", "2005" },
                    { "0765317508", "Gary Jennings", "http://books.google.com/books/content?id=EGFHccTVhq8C&printsec=frontcover&img=1&zoom=1&source=gbs_api", "Aztec", "1980" },
                    { "0142501085", "Brian Jacques", null, "Marlfox", "1998" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_Isbn",
                table: "Review",
                column: "Isbn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}

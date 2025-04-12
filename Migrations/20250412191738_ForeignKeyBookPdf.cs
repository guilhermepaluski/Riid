using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Riid.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyBookPdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_Fk_author",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_Fk_category",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "BookModel");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Fk_category",
                table: "BookModel",
                newName: "IX_BookModel_Fk_category");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Fk_author",
                table: "BookModel",
                newName: "IX_BookModel_Fk_author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookPdfModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fk_book = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPdfModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPdfModel_BookModel_Fk_book",
                        column: x => x.Fk_book,
                        principalTable: "BookModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookPdfModel_Fk_book",
                table: "BookPdfModel",
                column: "Fk_book");

            migrationBuilder.AddForeignKey(
                name: "FK_BookModel_Author_Fk_author",
                table: "BookModel",
                column: "Fk_author",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookModel_Category_Fk_category",
                table: "BookModel",
                column: "Fk_category",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_Author_Fk_author",
                table: "BookModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_Category_Fk_category",
                table: "BookModel");

            migrationBuilder.DropTable(
                name: "BookPdfModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel");

            migrationBuilder.RenameTable(
                name: "BookModel",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_BookModel_Fk_category",
                table: "Book",
                newName: "IX_Book_Fk_category");

            migrationBuilder.RenameIndex(
                name: "IX_BookModel_Fk_author",
                table: "Book",
                newName: "IX_Book_Fk_author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_Fk_author",
                table: "Book",
                column: "Fk_author",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_Fk_category",
                table: "Book",
                column: "Fk_category",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

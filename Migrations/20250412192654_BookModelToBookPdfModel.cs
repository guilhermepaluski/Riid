using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Riid.Migrations
{
    /// <inheritdoc />
    public partial class BookModelToBookPdfModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_Author_Fk_author",
                table: "BookModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_Category_Fk_category",
                table: "BookModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BookPdfModel_BookModel_Fk_book",
                table: "BookPdfModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPdfModel",
                table: "BookPdfModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel");

            migrationBuilder.RenameTable(
                name: "BookPdfModel",
                newName: "BookPdf");

            migrationBuilder.RenameTable(
                name: "BookModel",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_BookPdfModel_Fk_book",
                table: "BookPdf",
                newName: "IX_BookPdf_Fk_book");

            migrationBuilder.RenameIndex(
                name: "IX_BookModel_Fk_category",
                table: "Book",
                newName: "IX_Book_Fk_category");

            migrationBuilder.RenameIndex(
                name: "IX_BookModel_Fk_author",
                table: "Book",
                newName: "IX_Book_Fk_author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookPdf",
                table: "BookPdf",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookPdf_Book_Fk_book",
                table: "BookPdf",
                column: "Fk_book",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_Fk_author",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_Fk_category",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookPdf_Book_Fk_book",
                table: "BookPdf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPdf",
                table: "BookPdf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "BookPdf",
                newName: "BookPdfModel");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "BookModel");

            migrationBuilder.RenameIndex(
                name: "IX_BookPdf_Fk_book",
                table: "BookPdfModel",
                newName: "IX_BookPdfModel_Fk_book");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Fk_category",
                table: "BookModel",
                newName: "IX_BookModel_Fk_category");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Fk_author",
                table: "BookModel",
                newName: "IX_BookModel_Fk_author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookPdfModel",
                table: "BookPdfModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookPdfModel_BookModel_Fk_book",
                table: "BookPdfModel",
                column: "Fk_book",
                principalTable: "BookModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

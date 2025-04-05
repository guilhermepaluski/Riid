using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Riid.Migrations
{
    /// <inheritdoc />
    public partial class changeUserTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RiidDb",
                table: "RiidDb");

            migrationBuilder.RenameTable(
                name: "RiidDb",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "RiidDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiidDb",
                table: "RiidDb",
                column: "Id");
        }
    }
}

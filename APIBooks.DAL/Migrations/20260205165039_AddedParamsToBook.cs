using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBooks.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedParamsToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishedYear",
                table: "Books",
                newName: "PublisherYear");

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PublisherYear",
                table: "Books",
                newName: "PublishedYear");
        }
    }
}

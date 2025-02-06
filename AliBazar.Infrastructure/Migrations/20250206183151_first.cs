using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliBazar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "ProductColors",
                newName: "ColorUz");

            migrationBuilder.AddColumn<string>(
                name: "ColorRu",
                table: "ProductColors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorRu",
                table: "ProductColors");

            migrationBuilder.RenameColumn(
                name: "ColorUz",
                table: "ProductColors",
                newName: "Color");
        }
    }
}

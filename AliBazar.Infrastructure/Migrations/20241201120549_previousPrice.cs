using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliBazar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class previousPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PreviousPrice",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousPrice",
                table: "Products");
        }
    }
}

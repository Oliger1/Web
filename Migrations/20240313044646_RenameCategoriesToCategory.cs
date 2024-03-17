using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOliger.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoriesToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categories",
                table: "Resumes",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Resumes",
                newName: "Categories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOliger.Migrations
{
    /// <inheritdoc />
    public partial class AddUploadedDocumentsPathsJsonColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploadedDocumentsPathsJson",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedDocumentsPathsJson",
                table: "Resumes");
        }
    }
}

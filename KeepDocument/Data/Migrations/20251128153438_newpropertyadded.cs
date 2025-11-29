using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepDocument.Migrations
{
    /// <inheritdoc />
    public partial class newpropertyadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RelativePath",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "Documents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "StoredFileName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelativePath",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "StoredFileName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Documents");
        }
    }
}

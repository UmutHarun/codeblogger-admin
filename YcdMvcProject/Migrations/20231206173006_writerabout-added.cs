using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YcdMvcProject.Migrations
{
    /// <inheritdoc />
    public partial class writeraboutadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WriterAbout",
                table: "Writers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriterAbout",
                table: "Writers");
        }
    }
}

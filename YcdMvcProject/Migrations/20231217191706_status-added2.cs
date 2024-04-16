using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YcdMvcProject.Migrations
{
    /// <inheritdoc />
    public partial class statusadded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Writers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Writers");
        }
    }
}

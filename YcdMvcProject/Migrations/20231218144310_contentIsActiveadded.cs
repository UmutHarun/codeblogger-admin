using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YcdMvcProject.Migrations
{
    /// <inheritdoc />
    public partial class contentIsActiveadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contents");
        }
    }
}

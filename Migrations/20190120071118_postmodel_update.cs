using Microsoft.EntityFrameworkCore.Migrations;

namespace LandingPage.Migrations
{
    public partial class postmodel_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNewPost",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNewPost",
                table: "Posts",
                nullable: false,
                defaultValue: false);
        }
    }
}

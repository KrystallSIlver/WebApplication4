using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class fourt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categoryViewModels",
                newName: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "categoryViewModels",
                newName: "Id");
        }
    }
}

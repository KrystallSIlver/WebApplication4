using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Selected",
                table: "Todo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Selected",
                table: "Todo",
                nullable: true);
        }
    }
}

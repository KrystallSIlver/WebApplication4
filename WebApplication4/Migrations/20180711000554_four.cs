using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Category_CategoryId",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Todo",
                newName: "todoViewModels");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "categoryViewModels");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_CategoryId",
                table: "todoViewModels",
                newName: "IX_todoViewModels_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todoViewModels",
                table: "todoViewModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoryViewModels",
                table: "categoryViewModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_todoViewModels_categoryViewModels_CategoryId",
                table: "todoViewModels",
                column: "CategoryId",
                principalTable: "categoryViewModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoViewModels_categoryViewModels_CategoryId",
                table: "todoViewModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_todoViewModels",
                table: "todoViewModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoryViewModels",
                table: "categoryViewModels");

            migrationBuilder.RenameTable(
                name: "todoViewModels",
                newName: "Todo");

            migrationBuilder.RenameTable(
                name: "categoryViewModels",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_todoViewModels_CategoryId",
                table: "Todo",
                newName: "IX_Todo_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Category_CategoryId",
                table: "Todo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

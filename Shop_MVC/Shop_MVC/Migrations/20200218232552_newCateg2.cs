using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_MVC.Migrations
{
    public partial class newCateg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Genders_TypeId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "CategoryTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTypes",
                table: "CategoryTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryTypes_TypeId",
                table: "Categories",
                column: "TypeId",
                principalTable: "CategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryTypes_TypeId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTypes",
                table: "CategoryTypes");

            migrationBuilder.RenameTable(
                name: "CategoryTypes",
                newName: "Genders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Genders_TypeId",
                table: "Categories",
                column: "TypeId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

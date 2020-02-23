using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_MVC.Migrations
{
    public partial class userProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCarts_UserProfile_UserId1",
                table: "ShopingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShopingCarts_UserId1",
                table: "ShopingCarts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShopingCarts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShopingCarts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCarts_UserId",
                table: "ShopingCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCarts_UserProfile_UserId",
                table: "ShopingCarts",
                column: "UserId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCarts_UserProfile_UserId",
                table: "ShopingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShopingCarts_UserId",
                table: "ShopingCarts");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserProfile",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserProfile",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "UserProfile",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShopingCarts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ShopingCarts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCarts_UserId1",
                table: "ShopingCarts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCarts_UserProfile_UserId1",
                table: "ShopingCarts",
                column: "UserId1",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

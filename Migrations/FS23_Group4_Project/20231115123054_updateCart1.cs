using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPartB.Migrations.FS23_Group4_Project
{
    public partial class updateCart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_AspNetUsers_AspNetUserId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_AspNetUserId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_AspNetUsers_AspNetUserId",
                table: "CartItems",
                column: "AspNetUserId",
                principalTable: "AspNetUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_AspNetUsers_AspNetUserId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_AspNetUserId",
                table: "CartItems",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_AspNetUsers_AspNetUserId",
                table: "CartItems",
                column: "AspNetUserId",
                principalTable: "AspNetUser",
                principalColumn: "Id");
        }
    }
}

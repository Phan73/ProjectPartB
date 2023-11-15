using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPartB.Migrations.FS23_Group4_Project
{
    public partial class updateCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarDescriptionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RentalDuration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_CarDescription_CarDescriptionId",
                        column: x => x.CarDescriptionId,
                        principalTable: "CarDescription",
                        principalColumn: "CarDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_AspNetUserId",
                table: "CartItems",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CarDescriptionId",
                table: "CartItems",
                column: "CarDescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

           

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarDescriptionId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK__Rental__CarDescr__3587F3E0",
                        column: x => x.CarDescriptionId,
                        principalTable: "CarDescription",
                        principalColumn: "CarDescriptionId");
                    table.ForeignKey(
                        name: "FK__Rental__UserId__367C1819",
                        column: x => x.UserId,
                        principalTable: "UserDescription",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CarDescriptionId",
                table: "Rental",
                column: "CarDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_UserId",
                table: "Rental",
                column: "UserId");
        }
    }
}

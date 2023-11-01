using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPartB.Migrations.FS23_Group4_Project
{
    public partial class CorrectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEnum",
                columns: table => new
                {
                    UserEnumId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEnum", x => x.UserEnumId);
                });

           

            migrationBuilder.CreateTable(
                name: "CarDescription",
                columns: table => new
                {
                    CarDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarTypeId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RatePerDay = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDescription", x => x.CarDescriptionId);
                    table.ForeignKey(
                        name: "FK__CarDescri__CarTy__2BFE89A6",
                        column: x => x.CarTypeId,
                        principalTable: "CarType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserDescription",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEnumId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserDesc__1788CC4C44B75D43", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__UserDescr__UserE__32AB8735",
                        column: x => x.UserEnumId,
                        principalTable: "UserEnum",
                        principalColumn: "UserEnumId");
                });

            migrationBuilder.CreateTable(
                name: "CarAvailability",
                columns: table => new
                {
                    CarAvailabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarDescriptionId = table.Column<int>(type: "int", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAvailability", x => x.CarAvailabilityId);
                    table.ForeignKey(
                        name: "FK__CarAvaila__CarDe__395884C4",
                        column: x => x.CarDescriptionId,
                        principalTable: "CarDescription",
                        principalColumn: "CarDescriptionId");
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarDescriptionId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
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
                name: "IX_CarAvailability_CarDescriptionId",
                table: "CarAvailability",
                column: "CarDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDescription_CarTypeId",
                table: "CarDescription",
                column: "CarTypeId");


            migrationBuilder.CreateIndex(
                name: "IX_Rental_CarDescriptionId",
                table: "Rental",
                column: "CarDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_UserId",
                table: "Rental",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDescription_UserEnumId",
                table: "UserDescription",
                column: "UserEnumId");

            migrationBuilder.CreateIndex(
                name: "UQ__UserDesc__A9D105347F65302D",
                table: "UserDescription",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
       
            migrationBuilder.DropTable(
                name: "CarAvailability");

            migrationBuilder.DropTable(
                name: "Rental");


            migrationBuilder.DropTable(
                name: "CarDescription");

            migrationBuilder.DropTable(
                name: "UserDescription");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "UserEnum");


         
        }
    }
}

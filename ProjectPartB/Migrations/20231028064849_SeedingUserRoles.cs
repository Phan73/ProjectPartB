using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPartB.Migrations
{
    public partial class SeedingUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5555b661-884c-4d64-8a2d-868082a6233a", "c27689ac-f37b-4f5b-9412-e4862879ad9c", "Administrator", "ADMINISTRATOR" },
                    { "604f7419-6b49-4505-8afa-b663267dba8b", "14380418-857f-4d71-8ccb-a04594ebbcf2", "Visitor", "VISITOR" },
                    { "e22f5b2e-e518-45c3-8c11-387bffe556b7", "be39c68b-a9b4-4b1b-bb2f-04a62c67b96e", "Manager", "MANAGER" },
                    { "f81b3e8e-92a0-4e3a-96c1-ee015d601f54", "ff7fa5fe-34cc-4cce-bd20-7f49ea36ed95", "Editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DrivingLicense", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[,]
                {
                    { "0e2fd500-ff58-4848-992b-62dcaae9c021", 0, "editor", "b4a6bfcc-5809-4768-b368-2c4699de4251", "fads213", "editor@example.com", true, "editor", false, null, "EDITOR@EXAMPLE.COM", "EDITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDg19IM5m88wJbeuNIhOFVs5UqYB7orOl6HFAem15WD0UxmSacx1ojsZ296GTho+tA==", "0210888888", null, false, "bf990da8-53fa-4593-93fa-a14381ad33df", false, "3", "editor@example.com" },
                    { "b082c99a-d37c-4e2b-8fc4-f792fbc5afdb", 0, "manager", "97328f73-767c-4fb0-9eac-3418ccb813d9", "fads213", "manager@example.com", true, "manager", false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEBrSfueNDvlOsH2/IkpEJ/byZLvE9+z8B/HzJ0T//eiPcCMwL4SZUYGB81G/wFOtMA==", "0210888888", null, false, "b4063eea-b3a4-40ff-acb9-28b6a983755a", false, "2", "manager@example.com" },
                    { "d1c63891-7137-491b-953e-b85ca823ab51", 0, "admin", "08460e86-28b3-4afa-a229-dfb0fb44d09c", "fads213", "administrator@example.com", true, "Admin", false, null, "ADMINISTRATOR@EXAMPLE.COM", "ADMINISTRATOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEBbOeXe6OBteru5r445J/qZ/D/w3jDmpHST8oaRvnB8zCydo2CMY5wuc4mVQZ7T9Gg==", "0210888888", null, false, "9644061b-d51a-4fa8-b3b9-6b449dcee3cd", false, "1", "administrator@example.com" },
                    { "d4274cf7-e7ff-4b53-b7c5-6850560a0a38", 0, "visitor", "c7488722-a0c5-4c84-8d8e-4402ca1ba6f6", "fads213", "visitor@example.com", true, "visitor", false, null, "VISITOR@EXAMPLE.COM", "VISITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEPMax3yrvHl3L4DL0sPT6mum1r127VvZ4pjMv4m6Kaj0ENXYQAXBikE6Z/tBqqKIRw==", "0210888888", null, false, "3aac373c-86d6-4a94-98d0-c27418c592e1", false, "4", "visitor@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f81b3e8e-92a0-4e3a-96c1-ee015d601f54", "0e2fd500-ff58-4848-992b-62dcaae9c021" },
                    { "e22f5b2e-e518-45c3-8c11-387bffe556b7", "b082c99a-d37c-4e2b-8fc4-f792fbc5afdb" },
                    { "5555b661-884c-4d64-8a2d-868082a6233a", "d1c63891-7137-491b-953e-b85ca823ab51" },
                    { "604f7419-6b49-4505-8afa-b663267dba8b", "d4274cf7-e7ff-4b53-b7c5-6850560a0a38" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f81b3e8e-92a0-4e3a-96c1-ee015d601f54", "0e2fd500-ff58-4848-992b-62dcaae9c021" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e22f5b2e-e518-45c3-8c11-387bffe556b7", "b082c99a-d37c-4e2b-8fc4-f792fbc5afdb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5555b661-884c-4d64-8a2d-868082a6233a", "d1c63891-7137-491b-953e-b85ca823ab51" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "604f7419-6b49-4505-8afa-b663267dba8b", "d4274cf7-e7ff-4b53-b7c5-6850560a0a38" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5555b661-884c-4d64-8a2d-868082a6233a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "604f7419-6b49-4505-8afa-b663267dba8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e22f5b2e-e518-45c3-8c11-387bffe556b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f81b3e8e-92a0-4e3a-96c1-ee015d601f54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e2fd500-ff58-4848-992b-62dcaae9c021");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b082c99a-d37c-4e2b-8fc4-f792fbc5afdb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1c63891-7137-491b-953e-b85ca823ab51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4274cf7-e7ff-4b53-b7c5-6850560a0a38");
        }
    }
}

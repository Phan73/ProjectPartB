using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPartB.Migrations
{
    public partial class AddMembershipToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70c17622-d13a-4bf2-9622-28d82537f522", "ad1d12a0-a638-4e40-904f-cac7ba239a31", "Editor", "EDITOR" },
                    { "74be8d99-9966-4bb1-9165-ed92b0aa7d89", "428336fe-c35f-4f19-b76d-d00ee7daddd0", "Visitor", "VISITOR" },
                    { "989a86f7-1fe4-4e2f-b94e-bdbf7d4f8fc8", "4166e685-c284-467f-86c3-22ce9698d38f", "Administrator", "ADMINISTRATOR" },
                    { "d90d7613-5937-4465-a91a-8ff48bb550e2", "e18fa8eb-0c05-4e3c-9520-16a8cbf4bbe2", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DrivingLicense", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[,]
                {
                    { "68ff6497-cbc7-4827-a578-a4fc3a1bfa83", 0, "admin", "113b672b-ce82-45a2-b853-40744af23969", "fads213", "administrator@example.com", true, "Admin", false, null, "ADMINISTRATOR@EXAMPLE.COM", "ADMINISTRATOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEAefTHdS87V+pVhvc0EO7rNPphOTQZmdPft41KYBXriTnLur/QoAd2g1MZ93/Cmh/Q==", "0210888888", null, false, "c143f0e5-4c2a-42d3-ba1e-b8da48a7540b", false, "1", "administrator@example.com" },
                    { "815beac9-ab07-4879-8387-65dd1b56ce46", 0, "visitor", "0c4936d4-6890-490e-9edf-4244e1ecdb34", "fads213", "visitor@example.com", true, "visitor", false, null, "VISITOR@EXAMPLE.COM", "VISITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEEd63MVE9UDdxgDVrH4TBA3E+TEODgqWKmrYquv6OMQEFtRCsFkglqQ+DelsdI0bQQ==", "0210888888", null, false, "ee63e1b5-9f84-4e27-81c6-3b7e4d4dacde", false, "4", "visitor@example.com" },
                    { "e941684a-6856-4f3b-af8d-0403489b6842", 0, "editor", "13ff88cd-f6be-4d74-801c-2113a3c088f4", "fads213", "editor@example.com", true, "editor", false, null, "EDITOR@EXAMPLE.COM", "EDITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAENMJLNWele+3jw8hLvC2OqRQZZkhMTWnvKiHLOJxD1xp3xPapdyD/ijWhTqW8deavQ==", "0210888888", null, false, "8b3f50d5-9783-4e4e-8441-a3955ea23f2d", false, "3", "editor@example.com" },
                    { "f1eab00f-2253-4ff4-9e7e-c5da6b6e7bf9", 0, "manager", "c8cb0fd3-9d88-4b26-814b-091504572c8d", "fads213", "manager@example.com", true, "manager", false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJYvoU5zrluY2/K5PkQ30xUvLHpqMnnbASh0guMR8p4IrNEUHaBjjIFxGZXSQqdYGQ==", "0210888888", null, false, "53217a39-cde8-4a6c-b7c3-aae4aa344a6d", false, "2", "manager@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "989a86f7-1fe4-4e2f-b94e-bdbf7d4f8fc8", "68ff6497-cbc7-4827-a578-a4fc3a1bfa83" },
                    { "74be8d99-9966-4bb1-9165-ed92b0aa7d89", "815beac9-ab07-4879-8387-65dd1b56ce46" },
                    { "70c17622-d13a-4bf2-9622-28d82537f522", "e941684a-6856-4f3b-af8d-0403489b6842" },
                    { "d90d7613-5937-4465-a91a-8ff48bb550e2", "f1eab00f-2253-4ff4-9e7e-c5da6b6e7bf9" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "989a86f7-1fe4-4e2f-b94e-bdbf7d4f8fc8", "68ff6497-cbc7-4827-a578-a4fc3a1bfa83" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "74be8d99-9966-4bb1-9165-ed92b0aa7d89", "815beac9-ab07-4879-8387-65dd1b56ce46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "70c17622-d13a-4bf2-9622-28d82537f522", "e941684a-6856-4f3b-af8d-0403489b6842" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d90d7613-5937-4465-a91a-8ff48bb550e2", "f1eab00f-2253-4ff4-9e7e-c5da6b6e7bf9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c17622-d13a-4bf2-9622-28d82537f522");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74be8d99-9966-4bb1-9165-ed92b0aa7d89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "989a86f7-1fe4-4e2f-b94e-bdbf7d4f8fc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90d7613-5937-4465-a91a-8ff48bb550e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68ff6497-cbc7-4827-a578-a4fc3a1bfa83");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "815beac9-ab07-4879-8387-65dd1b56ce46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e941684a-6856-4f3b-af8d-0403489b6842");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1eab00f-2253-4ff4-9e7e-c5da6b6e7bf9");

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
    }
}

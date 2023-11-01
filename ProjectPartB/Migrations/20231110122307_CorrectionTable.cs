using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPartB.Migrations
{
    public partial class CorrectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "132b25df-e29e-44a1-b94d-e725e22b7e99", "2eedd080-810a-4dd1-a317-ac96efc32d10" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aad24b95-035f-4de1-a81b-2916ceebe740", "e2b0611b-3ff1-4aaa-ac5d-1d1482a310c5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c360e66d-3f0b-4f2c-b26f-94fa9932c9e7", "e2b0e210-9cc4-45be-bea0-796186eef022" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6cf0002c-9fb3-4cf8-b7f3-ebc72ebb9144", "e8f8b533-0525-4f46-a4cc-54fad84a068d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "132b25df-e29e-44a1-b94d-e725e22b7e99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cf0002c-9fb3-4cf8-b7f3-ebc72ebb9144");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aad24b95-035f-4de1-a81b-2916ceebe740");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c360e66d-3f0b-4f2c-b26f-94fa9932c9e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eedd080-810a-4dd1-a317-ac96efc32d10");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b0611b-3ff1-4aaa-ac5d-1d1482a310c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b0e210-9cc4-45be-bea0-796186eef022");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e8f8b533-0525-4f46-a4cc-54fad84a068d");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "304274c5-9ef7-4fa1-9e1e-bef7dd8882ce", "c291da70-93c9-4150-a726-d00584705495", "Manager", "MANAGER" },
                    { "426b436a-1683-4720-8474-db29888a1739", "05e14f33-0547-4528-a8c6-1a25c65a9309", "Administrator", "ADMINISTRATOR" },
                    { "a5ce0f49-f3a3-40dd-acd7-494d2da6d5c5", "edd04175-39d2-473c-97dc-13979ce06024", "Editor", "EDITOR" },
                    { "cf45be01-35d3-46bd-9e23-d986dc9d323e", "e30e3743-a8b4-44c8-99d5-d689ae99a270", "Visitor", "VISITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AspNetUserId", "ConcurrencyStamp", "DrivingLicense", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "MembershipId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "561f3c01-458a-402b-90f5-23d857b74060", 0, "visitor", null, "6e9d007e-6f40-46ae-a2ee-e5e4e3d4419e", "fads213", "visitor@example.com", true, "visitor", false, null, null, "VISITOR@EXAMPLE.COM", "VISITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEOf+nut32rwM1qsxi9hwme82XAd8ie4AZmnQJgdBQZPi5lxPK6tPwC3NQAy2HMulsA==", "0210888888", null, false, "ec7881d8-e48f-4bf9-b775-9e3a70bd8efb", false, "visitor@example.com" },
                    { "97eb6619-6971-4d4e-a1b2-8aef1b7485b0", 0, "manager", null, "89745bb1-7a9a-4829-8a88-3eb8930af3d8", "fads213", "manager@example.com", true, "manager", false, null, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJJGYpGdkP7O8+a0yB5ETBdnZKE6bYMNJkfXukGcTgWokQN5UqAb7T339hP5Pz0Dxg==", "0210888888", null, false, "b5b3a213-aefd-4665-8da2-8db53bf27b78", false, "manager@example.com" },
                    { "a4cae09d-7b3f-47eb-826e-d99a809797c9", 0, "editor", null, "7338b100-4512-4f1c-bfb1-26829b62f480", "fads213", "editor@example.com", true, "editor", false, null, null, "EDITOR@EXAMPLE.COM", "EDITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDbO2n+zMzK6WqH1B6OAnls/N8kYAQkB9gvzUEScOirHI5zRCrbwv8GQKeXTmlgE+w==", "0210888888", null, false, "16867883-9c06-4ab9-9699-a7b0271e4022", false, "editor@example.com" },
                    { "d779d796-0cc3-4c88-ba4f-e0999c80786b", 0, "admin", null, "71a9d72a-3fdf-47c2-9202-d75238958bfd", "fads213", "administrator@example.com", true, "Admin", false, null, null, "ADMINISTRATOR@EXAMPLE.COM", "ADMINISTRATOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEPXJKfzgvE2pq+FPpFx9axDLX2CPB070Bi5wt9NxEpqz/7Ti08f4qMNxf6w/HtRFEA==", "0210888888", null, false, "b4ecf4b4-1c04-46d8-92ae-72b6f5d2749f", false, "administrator@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cf45be01-35d3-46bd-9e23-d986dc9d323e", "561f3c01-458a-402b-90f5-23d857b74060" },
                    { "304274c5-9ef7-4fa1-9e1e-bef7dd8882ce", "97eb6619-6971-4d4e-a1b2-8aef1b7485b0" },
                    { "a5ce0f49-f3a3-40dd-acd7-494d2da6d5c5", "a4cae09d-7b3f-47eb-826e-d99a809797c9" },
                    { "426b436a-1683-4720-8474-db29888a1739", "d779d796-0cc3-4c88-ba4f-e0999c80786b" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf45be01-35d3-46bd-9e23-d986dc9d323e", "561f3c01-458a-402b-90f5-23d857b74060" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "304274c5-9ef7-4fa1-9e1e-bef7dd8882ce", "97eb6619-6971-4d4e-a1b2-8aef1b7485b0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5ce0f49-f3a3-40dd-acd7-494d2da6d5c5", "a4cae09d-7b3f-47eb-826e-d99a809797c9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "426b436a-1683-4720-8474-db29888a1739", "d779d796-0cc3-4c88-ba4f-e0999c80786b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304274c5-9ef7-4fa1-9e1e-bef7dd8882ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "426b436a-1683-4720-8474-db29888a1739");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5ce0f49-f3a3-40dd-acd7-494d2da6d5c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf45be01-35d3-46bd-9e23-d986dc9d323e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "561f3c01-458a-402b-90f5-23d857b74060");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97eb6619-6971-4d4e-a1b2-8aef1b7485b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4cae09d-7b3f-47eb-826e-d99a809797c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d779d796-0cc3-4c88-ba4f-e0999c80786b");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "132b25df-e29e-44a1-b94d-e725e22b7e99", "867845be-7308-42bb-890a-2b3a39b00825", "Administrator", "ADMINISTRATOR" },
                    { "6cf0002c-9fb3-4cf8-b7f3-ebc72ebb9144", "8d61e0d7-1240-4dbc-8f15-5ae40d05e8f3", "Editor", "EDITOR" },
                    { "aad24b95-035f-4de1-a81b-2916ceebe740", "a80ded3f-d662-4fc5-84ba-268cb847af8b", "Visitor", "VISITOR" },
                    { "c360e66d-3f0b-4f2c-b26f-94fa9932c9e7", "6f80d7cb-8d91-4d3d-91db-66922e7096a5", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AspNetUserId", "ConcurrencyStamp", "DrivingLicense", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "MembershipId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2eedd080-810a-4dd1-a317-ac96efc32d10", 0, "admin", null, "c0ee721b-4452-4814-896e-73a253b3d7bf", "fads213", "administrator@example.com", true, "Admin", false, null, null, "ADMINISTRATOR@EXAMPLE.COM", "ADMINISTRATOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEK6PtGT0ol0/tBs6SZsXjd9aZ2mKQlrJ5v0rDi/R0toEuZdxt5zemXLmpX1s1h1rqA==", "0210888888", null, false, "6c5d671d-0101-4fad-bb7a-742eb23cb11d", false, "administrator@example.com" },
                    { "e2b0611b-3ff1-4aaa-ac5d-1d1482a310c5", 0, "visitor", null, "91b05729-95c8-4b1e-906d-8debc06a3854", "fads213", "visitor@example.com", true, "visitor", false, null, null, "VISITOR@EXAMPLE.COM", "VISITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAELJsDbB0t7p/bCSjJV3ZOqnb6gO0SndB6en7VXs3h0flKd1ta8fhPRCQ9+knS5+UCA==", "0210888888", null, false, "312c622c-b7bb-456d-b696-ddf9b495df20", false, "visitor@example.com" },
                    { "e2b0e210-9cc4-45be-bea0-796186eef022", 0, "manager", null, "c03ff445-9582-4a68-ae77-5e8a08d89f7f", "fads213", "manager@example.com", true, "manager", false, null, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAEAACcQAAAAELQFWLTUDfCO3331owTh4+IUqrGcuwIE7U9uA3tXldv8FS8ofadnTlpZeO1i5/701g==", "0210888888", null, false, "086f4299-8f94-4517-8e68-051180a35a60", false, "manager@example.com" },
                    { "e8f8b533-0525-4f46-a4cc-54fad84a068d", 0, "editor", null, "d95fd550-11e9-4a8b-9b11-ea2a9b6d09fa", "fads213", "editor@example.com", true, "editor", false, null, null, "EDITOR@EXAMPLE.COM", "EDITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKMyjW3t2K3g7adQKMhPYbDmUkiYKesUqfS4Qd2ovC5pmD840z7ntVCRyZhA4QoYSg==", "0210888888", null, false, "d1a94188-3565-40b4-b165-6cafd22b747c", false, "editor@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "132b25df-e29e-44a1-b94d-e725e22b7e99", "2eedd080-810a-4dd1-a317-ac96efc32d10" },
                    { "aad24b95-035f-4de1-a81b-2916ceebe740", "e2b0611b-3ff1-4aaa-ac5d-1d1482a310c5" },
                    { "c360e66d-3f0b-4f2c-b26f-94fa9932c9e7", "e2b0e210-9cc4-45be-bea0-796186eef022" },
                    { "6cf0002c-9fb3-4cf8-b7f3-ebc72ebb9144", "e8f8b533-0525-4f46-a4cc-54fad84a068d" }
                });
        }
    }
}

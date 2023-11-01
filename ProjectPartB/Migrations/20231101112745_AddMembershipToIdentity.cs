using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPartB.Migrations
{
    public partial class AddMembershipToIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MembershipId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaim_AspNetRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrivingLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUser_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleAspNetUser",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleAspNetUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AspNetRoleAspNetUser_AspNetRole_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetRoleAspNetUser_AspNetUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaim_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogin", x => x.LoginProvider);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogin_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserToken", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AspNetUserToken_AspNetUser_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10f1c6e4-b401-4101-9f9c-e0124c0ba90f", "3b801757-eca9-455f-9697-2a5eddb55bba", "Visitor", "VISITOR" },
                    { "11ae9a2a-54d1-41d4-8d81-797aef99972e", "139f3e3d-608a-40f3-b5c9-c79b303a0cc7", "Editor", "EDITOR" },
                    { "9f6ef78f-994a-416c-a608-746b0324000c", "ee9c6b07-70b2-4092-860a-07c6286e5a67", "Administrator", "ADMINISTRATOR" },
                    { "c8af0ed2-2ad2-4d78-b0b2-c036a94d1978", "d5b86897-a549-42ab-a258-8e11e1e5cbb9", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DrivingLicense", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "MembershipId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f0acec7-9b31-4c76-851e-cb5aa467685a", 0, "visitor", "269d6686-f447-4ec8-a8ef-beeb52b45132", "fads213", "visitor@example.com", true, "visitor", false, null, null, "VISITOR@EXAMPLE.COM", "VISITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAECnJLgT9WmgCUBz0gmbPB/7/MZ3sUTcAwv3KUfkI5cEdkNEzkD56JJb7/BYlUnZkXw==", "0210888888", null, false, "29edcb4a-408c-46b1-b832-6356c2715057", false, "visitor@example.com" },
                    { "5823cfbb-c438-414d-af7f-0f7083e40f2b", 0, "editor", "33a341af-a9ce-451c-99e8-f053fb774cb2", "fads213", "editor@example.com", true, "editor", false, null, null, "EDITOR@EXAMPLE.COM", "EDITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAELQYpNoCNt+G23Ym/YaJE++wHL9o9hinmJU49d9Qyuu34SlhVzGBPKCmgZsiD4mjlA==", "0210888888", null, false, "926483de-f5b7-4a9e-8056-320d852ef902", false, "editor@example.com" },
                    { "94e7d00c-2bf4-45b6-bdc8-5e595d7f8331", 0, "manager", "b8518ff4-a76d-4f25-8138-08f7c0eba9f5", "fads213", "manager@example.com", true, "manager", false, null, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEOI+htDP90ZrLmhNjYdOQuzGGAVknoJFGmEMc/2QqmimaZTikx/SMGtThR838bvRfw==", "0210888888", null, false, "71bce4a5-71dd-4311-a4f5-e8dcd402ed71", false, "manager@example.com" },
                    { "e1be6644-2bc1-4a4b-8afc-fe650ad2a93a", 0, "admin", "3c97b616-1d09-4bcf-b921-896974b37fea", "fads213", "administrator@example.com", true, "Admin", false, null, null, "ADMINISTRATOR@EXAMPLE.COM", "ADMINISTRATOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJDQ6INFaKUXNUPSvdzDvXwf3AWOD64qG9IrC0UQlKxBs73zaAZqxJhvViPopBLsdw==", "0210888888", null, false, "af7119b2-23b4-48bf-9fc2-830e201a43fd", false, "administrator@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "10f1c6e4-b401-4101-9f9c-e0124c0ba90f", "3f0acec7-9b31-4c76-851e-cb5aa467685a" },
                    { "11ae9a2a-54d1-41d4-8d81-797aef99972e", "5823cfbb-c438-414d-af7f-0f7083e40f2b" },
                    { "c8af0ed2-2ad2-4d78-b0b2-c036a94d1978", "94e7d00c-2bf4-45b6-bdc8-5e595d7f8331" },
                    { "9f6ef78f-994a-416c-a608-746b0324000c", "e1be6644-2bc1-4a4b-8afc-fe650ad2a93a" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MembershipId",
                table: "AspNetUsers",
                column: "MembershipId",
                unique: true,
                filter: "[MembershipId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleAspNetUser_UsersId",
                table: "AspNetRoleAspNetUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaim_RoleId",
                table: "AspNetRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUser_MembershipId",
                table: "AspNetUser",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaim_UserId",
                table: "AspNetUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogin_UserId",
                table: "AspNetUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserToken_UserId1",
                table: "AspNetUserToken",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Memberships_MembershipId",
                table: "AspNetUsers",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Memberships_MembershipId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoleAspNetUser");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaim");

            migrationBuilder.DropTable(
                name: "AspNetUserClaim");

            migrationBuilder.DropTable(
                name: "AspNetUserLogin");

            migrationBuilder.DropTable(
                name: "AspNetUserToken");

            migrationBuilder.DropTable(
                name: "AspNetRole");

            migrationBuilder.DropTable(
                name: "AspNetUser");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MembershipId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10f1c6e4-b401-4101-9f9c-e0124c0ba90f", "3f0acec7-9b31-4c76-851e-cb5aa467685a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11ae9a2a-54d1-41d4-8d81-797aef99972e", "5823cfbb-c438-414d-af7f-0f7083e40f2b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c8af0ed2-2ad2-4d78-b0b2-c036a94d1978", "94e7d00c-2bf4-45b6-bdc8-5e595d7f8331" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f6ef78f-994a-416c-a608-746b0324000c", "e1be6644-2bc1-4a4b-8afc-fe650ad2a93a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10f1c6e4-b401-4101-9f9c-e0124c0ba90f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11ae9a2a-54d1-41d4-8d81-797aef99972e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f6ef78f-994a-416c-a608-746b0324000c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8af0ed2-2ad2-4d78-b0b2-c036a94d1978");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f0acec7-9b31-4c76-851e-cb5aa467685a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5823cfbb-c438-414d-af7f-0f7083e40f2b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94e7d00c-2bf4-45b6-bdc8-5e595d7f8331");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1be6644-2bc1-4a4b-8afc-fe650ad2a93a");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "NEWID()");

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
    }
}

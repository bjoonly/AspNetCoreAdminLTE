using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.Migrations
{
    public partial class AddAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d0f9b64-d8a9-44b2-82a3-7b8172afe15e", "731a7739-e43a-48a2-8734-116cbf312955" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d0f9b64-d8a9-44b2-82a3-7b8172afe15e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "731a7739-e43a-48a2-8734-116cbf312955");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1aa14b7d-d31c-4907-8910-e7f566896db6", "45ce04b1-9df4-49bb-8a43-0178fdfd48bb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0a0568c6-7df4-4b05-881a-4668ef80d362", 0, "2a666f4c-0e27-4055-85e3-9c52a58fd2a7", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEN7DD2NJJON38Cnw2UI3EIpg/hGe7q5VK7ABsvsOKYJPqJx3j6AP4EcwV7LpzRWlvQ==", null, false, "4cc10110-df66-4ad6-9df2-fd84df32c86a", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1aa14b7d-d31c-4907-8910-e7f566896db6", "0a0568c6-7df4-4b05-881a-4668ef80d362" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1aa14b7d-d31c-4907-8910-e7f566896db6", "0a0568c6-7df4-4b05-881a-4668ef80d362" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aa14b7d-d31c-4907-8910-e7f566896db6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a0568c6-7df4-4b05-881a-4668ef80d362");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d0f9b64-d8a9-44b2-82a3-7b8172afe15e", "85a8ba37-1a5c-47da-bb04-7ff7d506f1fd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "731a7739-e43a-48a2-8734-116cbf312955", 0, "ad1f7ea5-5c06-4b12-80ba-2823c33c6d46", "admin@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEHAhUa/Qusc2Ku/JWbbARZ9A4DMI0NWHEBBYvoVy8fA8KXPQfaQXh8ttM53ZX3NKDg==", null, false, "564a5bd2-3d0f-4763-8b5a-afc5aca15166", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6d0f9b64-d8a9-44b2-82a3-7b8172afe15e", "731a7739-e43a-48a2-8734-116cbf312955" });
        }
    }
}

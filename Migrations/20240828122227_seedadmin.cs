using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAOnlineMart.Migrations
{
    /// <inheritdoc />
    public partial class seedadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22ffc532-008e-492d-92b1-e867501f2d54", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22ffc532-008e-492d-92b1-e867501f2d54", 0, "a13fd8dd-22d5-4d98-95ec-dabc1cf9e505", "admin@saonlinemart.com", true, "Admin", "User", false, null, "ADMIN@SAONLINEMART.COM", "ADMIN@SAONLINEMART.COM", "AQAAAAIAAYagAAAAEOSH06DUMAnwr9fGgwsj/pK2qwHPDubqw+CtxlPkrj595291GZRsS1eRkM8t11NPrg==", null, false, "", false, "admin@saonlinemart.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "22ffc532-008e-492d-92b1-e867501f2d54", "22ffc532-008e-492d-92b1-e867501f2d54" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "22ffc532-008e-492d-92b1-e867501f2d54", "22ffc532-008e-492d-92b1-e867501f2d54" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22ffc532-008e-492d-92b1-e867501f2d54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ffc532-008e-492d-92b1-e867501f2d54");
        }
    }
}

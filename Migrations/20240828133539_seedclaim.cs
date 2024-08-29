using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAOnlineMart.Migrations
{
    /// <inheritdoc />
    public partial class seedclaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Permission", "CanAccessAdminPage", "22ffc532-008e-492d-92b1-e867501f2d54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ffc532-008e-492d-92b1-e867501f2d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "481b66ea-a869-4bf1-a83d-f65b9eb461fc", "AQAAAAIAAYagAAAAEM3KCzppll3BYBBf2POnGn+uV00kn1PzelBXIlHS0HRhvRaNIYY4FtzB62AnEZo1kg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22ffc532-008e-492d-92b1-e867501f2d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a091a8f-4de0-400d-ac36-3ead79a6383f", "AQAAAAIAAYagAAAAEEysMi3TA9qVlHz334GvdK6mFZhORL7qamKTAm8oFaa4HEJgyF+f8Y6FLje9FKwj6A==" });
        }
    }
}

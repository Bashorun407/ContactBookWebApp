using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactBookWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402c4c8e-b17f-4fcf-bcec-1678caf6644b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5212000f-92db-4806-aafc-94d1c0651b4a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12c391e8-aefc-4790-9ff6-952cb597e5fe", null, "User", "USER" },
                    { "3291ce57-a3a8-432a-8961-ea681be136fc", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12c391e8-aefc-4790-9ff6-952cb597e5fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3291ce57-a3a8-432a-8961-ea681be136fc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "402c4c8e-b17f-4fcf-bcec-1678caf6644b", null, "Admin", "ADMIN" },
                    { "5212000f-92db-4806-aafc-94d1c0651b4a", null, "User", "USER" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactBookWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b710d5d-89dd-4355-a9a0-82f3fbef6109", null, "User", "USER" },
                    { "ca2a2587-a665-45c9-b725-187d148c786a", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b710d5d-89dd-4355-a9a0-82f3fbef6109");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca2a2587-a665-45c9-b725-187d148c786a");
        }
    }
}

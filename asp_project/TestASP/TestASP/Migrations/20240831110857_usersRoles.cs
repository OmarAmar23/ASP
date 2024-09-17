using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestASP.Migrations
{
    /// <inheritdoc />
    public partial class usersRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "439bda62-c2bb-4608-9fff-7ea0da14a52f", "494757bc-e006-44d6-a09f-b708d96b6949", "Admin", "admin" },
                    { "f06abb23-71d2-45a3-8626-ada9284fdb60", "3545e80c-323f-4c2f-b3ed-322d9d3268eb", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "439bda62-c2bb-4608-9fff-7ea0da14a52f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f06abb23-71d2-45a3-8626-ada9284fdb60");
        }
    }
}

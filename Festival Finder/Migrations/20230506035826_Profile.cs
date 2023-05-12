using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festival_Finder.Migrations
{
    /// <inheritdoc />
    public partial class Profile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a31dd470-b043-4b75-a778-9dc4d651eeba", "AQAAAAEAACcQAAAAEC+zB/8Gq6gnFNWEDICnZlpRANMYFbmTK/Z7WUwc2eqZCoGOmCDj36BukdqP94A72A==", "a494e305-53e8-4d5f-a738-f3dc61443de1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fe9b664-7727-475e-8657-39bb277f62c6", "AQAAAAEAACcQAAAAEHpVbHQwE3pOZC8364RIq8UAdrlGuePQbgVFFxQraPKWreP0Tt9PWwgjdetS78s+Ng==", "a7e89961-a550-4103-ad6f-13c3f1a8800f" });
        }
    }
}

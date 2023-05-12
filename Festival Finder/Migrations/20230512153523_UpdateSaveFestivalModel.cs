using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festival_Finder.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaveFestivalModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaveFestivals_AspNetUsers_AppUserId",
                table: "SaveFestivals");

            migrationBuilder.DropForeignKey(
                name: "FK_SaveFestivals_Festivals_FestivalId",
                table: "SaveFestivals");

            migrationBuilder.AlterColumn<int>(
                name: "FestivalId",
                table: "SaveFestivals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "SaveFestivals",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "939eb60a-f6fb-4472-a01d-10100b5c4031", "AQAAAAEAACcQAAAAEBFQuVsivhVwOUwn+44hkyYizTTLgQRHOecYbyCVxvEvu/SsVglkFp7Qd6QZH4WEUQ==", "91a3a04b-9ee9-4d99-ab86-581d734338bf" });

            migrationBuilder.AddForeignKey(
                name: "FK_SaveFestivals_AspNetUsers_AppUserId",
                table: "SaveFestivals",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaveFestivals_Festivals_FestivalId",
                table: "SaveFestivals",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaveFestivals_AspNetUsers_AppUserId",
                table: "SaveFestivals");

            migrationBuilder.DropForeignKey(
                name: "FK_SaveFestivals_Festivals_FestivalId",
                table: "SaveFestivals");

            migrationBuilder.AlterColumn<int>(
                name: "FestivalId",
                table: "SaveFestivals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SaveFestivals",
                keyColumn: "AppUserId",
                keyValue: null,
                column: "AppUserId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "SaveFestivals",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3c30130-462d-4967-b82b-229f1caebcf8", "AQAAAAEAACcQAAAAEFX+wy6DzNG0dQ6gPztye7aqKcKoAi0NybUO8fG2EjMftgnirdVgXVuq9FLqZ3TJGQ==", "5701fa6d-6d16-4bb7-8751-1331d73221ac" });

            migrationBuilder.AddForeignKey(
                name: "FK_SaveFestivals_AspNetUsers_AppUserId",
                table: "SaveFestivals",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaveFestivals_Festivals_FestivalId",
                table: "SaveFestivals",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

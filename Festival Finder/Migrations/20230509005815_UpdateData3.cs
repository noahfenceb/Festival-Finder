using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festival_Finder.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFestivals");

            migrationBuilder.CreateTable(
                name: "SaveFestivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppUserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FestivalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveFestivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaveFestivals_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaveFestivals_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3c30130-462d-4967-b82b-229f1caebcf8", "AQAAAAEAACcQAAAAEFX+wy6DzNG0dQ6gPztye7aqKcKoAi0NybUO8fG2EjMftgnirdVgXVuq9FLqZ3TJGQ==", "5701fa6d-6d16-4bb7-8751-1331d73221ac" });

            migrationBuilder.CreateIndex(
                name: "IX_SaveFestivals_AppUserId",
                table: "SaveFestivals",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveFestivals_FestivalId",
                table: "SaveFestivals",
                column: "FestivalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaveFestivals");

            migrationBuilder.CreateTable(
                name: "UserFestivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppUserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FestivalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFestivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFestivals_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFestivals_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d1f5200-7fee-4d6b-a08b-6807b158e74a", "AQAAAAEAACcQAAAAED/ZM/J81+4GmgYuYqxOsQoSQThWxmY3RX5h97FxW7dnLk0DuIXR7+wzH/111jnltA==", "bb01a4f7-28e7-40f2-937f-14def7f3c8dc" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFestivals_AppUserId",
                table: "UserFestivals",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFestivals_FestivalId",
                table: "UserFestivals",
                column: "FestivalId");
        }
    }
}

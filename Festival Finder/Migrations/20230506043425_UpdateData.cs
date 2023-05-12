using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festival_Finder.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFestivals");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a31dd470-b043-4b75-a778-9dc4d651eeba", "AQAAAAEAACcQAAAAEC+zB/8Gq6gnFNWEDICnZlpRANMYFbmTK/Z7WUwc2eqZCoGOmCDj36BukdqP94A72A==", "a494e305-53e8-4d5f-a738-f3dc61443de1" });
        }
    }
}

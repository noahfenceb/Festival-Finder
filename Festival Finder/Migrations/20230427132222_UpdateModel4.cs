using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festival_Finder.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Festivals_FestivalId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_FestivalId",
                table: "Artists");

            migrationBuilder.CreateTable(
                name: "FestivalList",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    FestivalsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalList", x => new { x.ArtistsId, x.FestivalsId });
                    table.ForeignKey(
                        name: "FK_FestivalList_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FestivalList_Festivals_FestivalsId",
                        column: x => x.FestivalsId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalList_FestivalsId",
                table: "FestivalList",
                column: "FestivalsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FestivalList");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_FestivalId",
                table: "Artists",
                column: "FestivalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Festivals_FestivalId",
                table: "Artists",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

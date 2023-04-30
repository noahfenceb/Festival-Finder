using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festival_Finder.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArtisteId",
                table: "Festivals",
                newName: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Festivals",
                newName: "ArtisteId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotifyAPITopTracks.Migrations
{
    public partial class AddSpotifyFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE TABLE IF NOT EXISTS Tracks (
            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            Rank INTEGER NOT NULL,
            Uri TEXT NOT NULL,
            ArtistNames TEXT NOT NULL,
            TrackName TEXT NOT NULL,
            Source TEXT NOT NULL,
            PeakRank INTEGER NOT NULL,
            PreviousRank INTEGER NOT NULL,
            WeeksOnChart INTEGER NOT NULL,
            Streams INTEGER NOT NULL
        );
    ");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Lösche die Tabelle nur, wenn du sicher bist, dass sie nicht mehr benötigt wird.
            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}

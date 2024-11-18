using System.Globalization;
using SpotifyAPITopTracks.Services;
using SpotifyAPITopTracks.Models;

namespace SpotifyAPITopTracks.Data
{
    public static class DataInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, SpotifyService spotifyService)
        {
            // Datenbank erstellen, falls sie nicht existiert
            context.Database.EnsureCreated();

            // Überprüfen, ob die Datenbank bereits Daten enthält
            if (context.Tracks.Any())
                return;

            // API-Zugriff einrichten
            var clientId = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
            var clientSecret = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_SECRET");

            // Access Token von der Spotify API abrufen
            var accessToken = await spotifyService.GetAccessTokenAsync(clientId, clientSecret);

            // Top-Tracks von Spotify abrufen
            var tracks = await spotifyService.GetTopTracksAsync(accessToken);

            // Tracks in die Datenbank laden
            context.Tracks.AddRange(tracks);
            context.SaveChanges();
        }
    }
}

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpotifyAPITopTracks.Services;
using SpotifyAPITopTracks.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPITopTracks.Services
{
    public class ChartUpdater : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ChartUpdater(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var spotifyService = scope.ServiceProvider.GetRequiredService<SpotifyService>();
                        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                        // Abrufen der Spotify-Daten
                        var clientId = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
                        var clientSecret = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_SECRET");
                        var accessToken = await spotifyService.GetAccessTokenAsync(clientId, clientSecret);
                        var tracks = await spotifyService.GetTopTracksAsync(accessToken);

                        // Datenbank aktualisieren
                        foreach (var track in tracks)
                        {
                            var existingTrack = dbContext.Tracks.FirstOrDefault(t => t.Uri == track.Uri);
                            if (existingTrack == null)
                            {
                                dbContext.Tracks.Add(track); // Neuer Track
                            }
                            else
                            {
                                existingTrack.Rank = track.Rank;
                                existingTrack.WeeksOnChart = track.WeeksOnChart;
                            }
                        }

                        await dbContext.SaveChangesAsync();
                    }

                    // Aktualisierung alle 30 Minuten
                    await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
                }
                catch (Exception ex)
                {
                    // Logge den Fehler (optional)
                    Console.WriteLine($"Fehler beim Aktualisieren der Charts: {ex.Message}");
                }
            }
        }
    }
}

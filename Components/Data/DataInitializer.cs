using CsvHelper;                  
using System.Globalization;
using SpotifyAPITopTracks.Services;
using SpotifyAPITopTracks.Models;

namespace SpotifyAPITopTracks.Data
{
    public class DataInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Überprüfen, ob bereits Daten in der Datenbank vorhanden sind
            if (context.Tracks.Any())
                return; // Falls Daten vorhanden sind, keine weiteren Daten laden

            // CSV-Daten laden
            var tracks = CsvService.LoadCsvData("wwwroot/regional-global-weekly-2024-10-24.csv");

            // Füge die geladenen Daten zur Datenbank hinzu
            context.Tracks.AddRange(tracks);
            context.SaveChanges();
        }
    }
}

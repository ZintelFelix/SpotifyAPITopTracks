using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using SpotifyAPITopTracks.Models;

namespace SpotifyAPITopTracks.Services
{
    public class CsvService
    {
        public static List<Track> LoadCsvData(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null, // Ignoriert fehlende Header-Validierung
                MissingFieldFound = null, // Ignoriert fehlende Felder
                PrepareHeaderForMatch = args => args.Header.ToLower() // Vergleicht Header unabhängig von der Groß-/Kleinschreibung
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);

            return csv.GetRecords<Track>().ToList();
        }
    }
}
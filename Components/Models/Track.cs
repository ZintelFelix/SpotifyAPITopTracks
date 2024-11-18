using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace SpotifyAPITopTracks.Models
{
    public class Track
    {
        [Key] // Markiert dieses Feld als Primärschlüssel
        public int Id { get; set; }

        [Name("rank")]
        public int Rank { get; set; }

        [Name("uri")]
        public string Uri { get; set; }

        [Name("artist_names")]
        public string ArtistNames { get; set; }

        [Name("track_name")]
        public string TrackName { get; set; }

        [Name("source")]
        public string Source { get; set; }

        [Name("peak_rank")]
        public int PeakRank { get; set; }

        [Name("previous_rank")]
        public int PreviousRank { get; set; }

        [Name("weeks_on_chart")]
        public int WeeksOnChart { get; set; }

        [Name("streams")]
        public int Streams { get; set; }
    }
}

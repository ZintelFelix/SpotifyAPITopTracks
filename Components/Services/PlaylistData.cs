using CsvHelper.Configuration.Attributes;

public class PlaylistData
{
    [Name("rank")]
    public int Rank { get; set; }

    [Name("track_name")]
    public string TrackName { get; set; }

    [Name("artist_names")]
    public string ArtistNames { get; set; }

    [Name("uri")]
    public string Uri { get; set; }

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

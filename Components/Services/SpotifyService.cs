using System.Net.Http.Headers;
using System.Text.Json;

namespace SpotifyAPITopTracks.Services
{
public class SpotifyService
{
    private const string AccessToken = "BQAgtdgE4G-h0-pWX2I2V0C6zYXauRHnx40Me6BUrZ-yXTww5nDfpViuBTuI5cVMW5BGRDHRPZbjgViYMpaWPekLXnwjD9JqBAtWbr6bmaT-wxR4nWc";
    
    public async Task<string> GetAlbumCoverUrl(string songTitle, string artistName)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

        var searchUrl = $"https://api.spotify.com/v1/search?q=track:{Uri.EscapeDataString(songTitle)}%20artist:{Uri.EscapeDataString(artistName)}&type=track&limit=1";
        var response = await client.GetAsync(searchUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var spotifyResponse = JsonSerializer.Deserialize<SpotifySearchResponse>(content);
            var albumCoverUrl = spotifyResponse?.Tracks.Items.FirstOrDefault()?.Album.Images.FirstOrDefault()?.Url;
            return albumCoverUrl;
        }

        return null;
    }
}


public class SpotifySearchResponse
{
    public TrackList Tracks { get; set; }

    public class TrackList
    {
        public List<Track> Items { get; set; }
    }

    public class Track
    {
        public Album Album { get; set; }
    }

    public class Album
    {
        public List<Image> Images { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
    }
}
}
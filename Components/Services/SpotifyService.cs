using System.Net.Http.Headers;
using System.Text.Json;
using SpotifyAPITopTracks.Models;

namespace SpotifyAPITopTracks.Services
{
    public class SpotifyService
    {
        private readonly HttpClient _httpClient;

        // Konstruktor mit Dependency Injection
        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Track>> GetTopTracksAsync(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Spotify-API-Endpunkt für eine spezifische Playlist
            string playlistUrl = "https://api.spotify.com/v1/playlists/37i9dQZEVXbMDoHDwVN2tF/tracks";

            var response = await _httpClient.GetAsync(playlistUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var spotifyResponse = JsonSerializer.Deserialize<SpotifyPlaylistResponse>(content);

            // Konvertiere die API-Daten in lokale Track-Objekte
            var tracks = spotifyResponse.Items.Select(item => new Track
            {
                TrackName = item.Track.Name,
                ArtistNames = string.Join(", ", item.Track.Artists.Select(a => a.Name)),
                Uri = item.Track.Uri,
                Source = "Spotify",
                Streams = 0 // Streams werden nicht von der API bereitgestellt
            }).ToList();

            return tracks;
        }

        public async Task<string> GetAccessTokenAsync(string clientId, string clientSecret)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            var encodedCredentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);
            request.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(jsonResponse);

            return jsonDoc.RootElement.GetProperty("access_token").GetString();
        }

        public class SpotifyPlaylistResponse
        {
            public List<PlaylistItem> Items { get; set; }

            public class PlaylistItem
            {
                public SpotifyTrack Track { get; set; }
            }

            public class SpotifyTrack
            {
                public string Name { get; set; }
                public List<SpotifyArtist> Artists { get; set; }
                public string Uri { get; set; }
            }

            public class SpotifyArtist
            {
                public string Name { get; set; }
            }
        }
    }
}

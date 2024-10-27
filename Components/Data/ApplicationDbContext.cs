using Microsoft.EntityFrameworkCore;
using SpotifyAPITopTracks.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Track> Tracks { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Optionale Konfiguration
    }
}

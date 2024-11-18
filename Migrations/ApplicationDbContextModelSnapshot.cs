﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SpotifyAPITopTracks.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("SpotifyAPITopTracks.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArtistNames")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PeakRank")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreviousRank")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rank")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Streams")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WeeksOnChart")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
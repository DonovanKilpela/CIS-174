using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataTransferKilpela.Models
{
    public class OlympicDbContext : DbContext
    {
        public OlympicDbContext(DbContextOptions<OlympicDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<OlympicGame> OlympicGames { get; set; } = null!;
        public DbSet<Sport> Sports { get; set; } = null!;

        // Creating Data for the program to use 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OlympicGame>().HasKey(g => g.GameId);
            modelBuilder.Entity<Sport>().HasKey(s => s.SportId);

            modelBuilder.Entity<OlympicGame>().HasData(
                new OlympicGame {  GameId = "winter", Name = "Winter Olympics" },
                new OlympicGame { GameId = "summer", Name = "Summer Olympics" },
                new OlympicGame { GameId = "para", Name = "Paralympics" },
                new OlympicGame { GameId = "youth", Name = "Youth Olympic Games" }
            );

            modelBuilder.Entity<Sport>().HasData(
                new Sport { SportId = "curling", Name = "Curling", Category = "Indoor" },
                new Sport { SportId = "bobsleigh", Name = "Bobsleigh", Category = "Outdoor" },
                new Sport { SportId = "diving", Name = "Diving", Category = "Indoor" },
                new Sport { SportId = "cycling", Name = "Road Cycling", Category = "Outdoor" },
                new Sport { SportId = "archery", Name = "Archery", Category = "Indoor" },
                new Sport { SportId = "canoe", Name = "Canoe Sprint", Category = "Outdoor" },
                new Sport { SportId = "breakdance", Name = "Breakdancing", Category = "Indoor" },
                new Sport { SportId = "skate", Name = "Skateboarding", Category = "Outdoor" }
            );

            modelBuilder.Entity<Country>().HasData(
                new { CountryId = 1, Name = "Canada", GameId = "winter", SportId = "curling", FlagImage = "Canada.png" },
                new { CountryId = 2, Name = "Sweden", GameId = "winter", SportId = "curling", FlagImage = "Sweden.png" },
                new { CountryId = 3, Name = "United Kingdom", GameId = "winter", SportId = "curling", FlagImage = "United_Kingdom.png" },
                new { CountryId = 4, Name = "Jamaica", GameId = "winter", SportId = "bobsleigh", FlagImage = "Jamaica.png" },
                new { CountryId = 5, Name = "Italy", GameId = "winter", SportId = "bobsleigh", FlagImage = "Italy.png" },
                new { CountryId = 6, Name = "Japan", GameId = "winter", SportId = "bobsleigh", FlagImage = "Japan.png" },
                new { CountryId = 7, Name = "Germany", GameId = "summer", SportId = "diving", FlagImage = "Germany.png" },
                new { CountryId = 8, Name = "China", GameId = "summer", SportId = "diving", FlagImage = "China.png" },
                new { CountryId = 9, Name = "Mexico", GameId = "summer", SportId = "diving", FlagImage = "Mexico.png" },
                new { CountryId = 10, Name = "Brazil", GameId = "summer", SportId = "cycling", FlagImage = "Brazil.png" },
                new { CountryId = 11, Name = "Netherlands", GameId = "summer", SportId = "cycling", FlagImage = "Netherlands.png" },
                new { CountryId = 12, Name = "United States", GameId = "summer", SportId = "cycling", FlagImage = "United_States.png" },
                new { CountryId = 13, Name = "Thailand", GameId = "para", SportId = "archery", FlagImage = "Thailand.png" },
                new { CountryId = 14, Name = "Uruguay", GameId = "para", SportId = "archery", FlagImage = "Uruguay.png" },
                new { CountryId = 15, Name = "Ukraine", GameId = "para", SportId = "archery", FlagImage = "Ukraine.png" },
                new { CountryId = 16, Name = "Austria", GameId = "para", SportId = "canoe", FlagImage = "Austria.png" },
                new { CountryId = 17, Name = "Pakistan", GameId = "para", SportId = "canoe", FlagImage = "Pakistan.png" },
                new { CountryId = 18, Name = "Zimbabwe", GameId = "para", SportId = "canoe", FlagImage = "Zimbabwe.png" },
                new { CountryId = 19, Name = "France", GameId = "youth", SportId = "breakdance", FlagImage = "France.png" },
                new { CountryId = 20, Name = "Cyprus", GameId = "youth", SportId = "breakdance", FlagImage = "Cyprus.png" },
                new { CountryId = 21, Name = "Russia", GameId = "youth", SportId = "breakdance", FlagImage = "Russia.png" },
                new { CountryId = 22, Name = "Finland", GameId = "youth", SportId = "skate", FlagImage = "Finland.png" },
                new { CountryId = 23, Name = "Slovakia", GameId = "youth", SportId = "skate", FlagImage = "Slovakia.png" },
                new { CountryId = 24, Name = "Portugal", GameId = "youth", SportId = "skate", FlagImage = "Portugal.png" }
            );

        }
    }
}

﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarWarsUniverseClone.Data.Repositories.Api;
using StarWarsUniverseClone.Domain;

namespace StarWarsUniverseClone.Data
{
    public class StarWarsContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public StarWarsContext() { }
        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            const string connectionString = "Server = (localdb)\\MSSQLLocalDB; " +
                                            "Database = StarWarsDB; " +
                                            "Trusted_Connection = True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(m => m.Uri);
            modelBuilder.Entity<Planet>().HasKey(p => p.Uri);
            modelBuilder.Entity<MoviePlanet>().HasKey(mp =>
                new
                {
                    mp.MovieUri,
                    mp.PlanetUri
                });

            var remoteMovies = new MovieApiRepository().GetAllMovies();
            modelBuilder.Entity<Movie>().HasData(remoteMovies.ToArray());
            foreach (var remoteMovie in remoteMovies)
            {
                remoteMovie.PlanetUris.ForEach(planet =>
                {
                    modelBuilder.Entity<MoviePlanet>().HasData(new MoviePlanet()
                    {
                        MovieUri = remoteMovie.Uri,
                        PlanetUri = planet
                    });
                });
            }
            var remotePlanets = new PlanetApiRepository().GetAllPlanets();
            modelBuilder.Entity<Planet>().HasData(remotePlanets.ToArray());

            modelBuilder.Entity<Movie>().Ignore(movie => movie.PlanetUris);
            modelBuilder.Entity<Planet>().Ignore(planet => planet.MovieUris);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

// Used in Program.cs to seed the database with movie data when the application starts.
public static class SeedData
{
    // IServicesProvider - object that gives access to the service container,
    // which is used to get the database context.
    public static void Initialize(IServiceProvider serviceProvider)
    {
        // using - Opens context, uses it, and then disposes of it when done.
        // Retrieves database configuration from the dependency injection container.
        // new MvcMovieContext - creates a new instance of the database context using the retrieved configuration.
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            // Adds a range of Movie objects to EF Core's change tracker, which will be inserted into the database when SaveChanges is called.
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Mission: Impossible - The Final Reckoning",
                    ReleaseDate = DateTime.Parse("2025-5-5"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 10.99M
                },
                new Movie
                {
                    Title = "Interstellar",
                    ReleaseDate = DateTime.Parse("2014-10-26"),
                    Genre = "Science Fiction",
                    Rating = "PG-13",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "The Hunt for Red October",
                    ReleaseDate = DateTime.Parse("1990-3-2"),
                    Genre = "Spy Thriller",
                    Rating = "PG",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "No Time to Die",
                    ReleaseDate = DateTime.Parse("2021-10-8"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Price = 10.99M
                }
            );
            // Actual databse write.
            context.SaveChanges();
        }
    }
}
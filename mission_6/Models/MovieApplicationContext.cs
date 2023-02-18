using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace mission_6.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options) 
        {
            
        }

        //Seed Data
        public DbSet<ApplicationResponse> Responses { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category {CategoryId= 1, CategoryName= "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            mb.Entity<ApplicationResponse>().HasData(
                    new ApplicationResponse
                    { 
                        MovieId= 1,
                        CategoryId = 1,
                        Title = "Jurassic Park",
                        Year = 1993,
                        Director = "Steven Spielberg",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = null,
                        Notes= null
                    },
                    new ApplicationResponse
                    {
                        MovieId = 2,
                        CategoryId = 1,
                        Title = "Back to the Future",
                        Year = 1985,
                        Director = "Robert Zemeckis",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = null,
                        Notes = null
                    },
                    new ApplicationResponse
                    {
                        MovieId = 3,
                        CategoryId = 1,
                        Title = "Avengers: Endgame",
                        Year = 2019,
                        Director = "Anthony Russo, Joe Russo",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = null,
                        Notes = null
                    }

                );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.IO;

namespace mission_6.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options) 
        {
            
        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                    new ApplicationResponse
                    { 
                        MovieId= 1,
                        Category = "Action/Adventure",
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
                        Category = "Action/Adventure",
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
                        Category = "Action/Adventure",
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

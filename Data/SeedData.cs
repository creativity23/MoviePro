using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviePro.Models;
using System;
using System.Linq;

namespace MoviePro.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (!context.Movies.Any())

                {
                    context.Studios.AddRange(
                      new Studio
                      {
                          Name = "Miramax",
                          FoundedDate = DateTime.Parse("1989-2-12"),
                          Location = "Hollywood,CA",
                          BoxOfficeRevenue = 100000000
                      },

                  new Studio
                  {
                      Name = "Universal",
                      FoundedDate = DateTime.Parse("1915-2-12"),
                      Location = "Wilmington,NC",
                      BoxOfficeRevenue = 100000000

                  });
                    context.SaveChanges();

                    var studioId = context.Studios.FirstOrDefault(s => s.Name == "Universal").Id;

                    context.Movies.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Price = 7.99M,
                            Studioid = studioId
                        },

                        new Movie
                        {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Price = 8.99M,
                            Studioid = studioId
                        },

                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Price = 9.99M,
                            Studioid = studioId
                        },

                        new Movie
                        {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Price = 3.99M,
                            Studioid = studioId
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
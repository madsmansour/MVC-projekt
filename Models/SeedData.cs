using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_projekt.Data;

namespace MVC_projekt.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCMovieContext(serviceProvider.GetRequiredService<DbContextOptions<MVCMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(new Movie { Title = "Johhny Bravo", ReleaseDate = DateTime.Parse("1995-05-05"), Genre = "Cartoon", Price = 7.99M }, 
                    new Movie { Title = "Johhny Alpha", ReleaseDate = DateTime.Parse("1991-05-05"), Genre = "Cartoon", Price = 9.99M },
                    new Movie { Title = "Johhny Charlie", ReleaseDate = DateTime.Parse("1992-05-05"), Genre = "Cartoon", Price = 10.99M });
                context.SaveChanges();

            }
        }
    }
}

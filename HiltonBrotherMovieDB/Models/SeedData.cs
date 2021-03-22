using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HiltonBrotherMovieDB.Models
{
    public class SeedData
    {
        // method to generate default recourds
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            // makes context variable from create scope guy which is also in start up
            MoviesDBContext context = application.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<MoviesDBContext>();

            // checks to see if any migrations are needed and makes them
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            // if there arent any books itll add the ones listed below.
            if (!context.Movies.Any())
            {
                
            }
            // saves stuff added to context like all the new books
            context.SaveChanges();
        }
    }
}

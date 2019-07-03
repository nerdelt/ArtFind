using artfind.Data;
using artfind.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace artfind.Models
{
    public static class DbInitializer
    {
        public static UserManager<AppUser> UserManager { get; set; }

        public static void Initialize(ApplicationDbContext context)
        {
             //context.Database.EnsureCreated();

            // Look for any artists.
            if (UserManager.FindByEmailAsync("nerdelt@artfind.local").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Natalie",
                    LastName = "Erdelt",
                    UserName = "nerdelt@artfind.local",
                    Email = "nerdelt@artfind.local",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "P@ssword1").GetAwaiter().GetResult();
            }

            if (context.Artist.Any())
            {
                return;   // DB has been seeded
            }

            var artists = new Artist[]
            {
            new Artist{FirstName="Artemisia",LastName="Gentileschi",Gender=(Gender)0, Nationality="Italian", Birthdate=DateTime.Parse("1593-07-08") }, 
            new Artist{FirstName="Anders", LastName="Zorn",Gender=(Gender)1, Nationality="Swedish", Birthdate=DateTime.Parse("1860-02-18")},
            new Artist{FirstName="John Singer", LastName="Sargent",Gender=(Gender)1, Nationality="American", Birthdate=DateTime.Parse("1865-01-12")}

            };
            foreach (Artist s in artists)
            {
                context.Artist.Add(s);
            }
            context.SaveChanges();

            var artworks = new ArtPiece[]
            {
            new ArtPiece{/*ArtPieceID=1*/Title="Danaë", ArtistID= 1, YearCreated = 1612, Medium = "Oil on Canvas", CurrentLocation = "St. Louis Art Museum", Height= 41.5 , Width = 52.5},
            new ArtPiece{/*ArtPieceID=2,*/ Title="Lucy Turner Joy", ArtistID=2, YearCreated = 1897, Medium = "Oil on Canvas", CurrentLocation = "St. Louis Art Museum", Height=61.6 , Width = 76.8}

            };
            foreach (ArtPiece a in artworks)
            {
                context.ArtPiece.Add(a);
            }
            context.SaveChanges();

           


        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Seed data for database, collected from LS. No BookId, as it's automatically set as the primary key of the database.
namespace FakeAmazon.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            FakeAmazonDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<FakeAmazonDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Projects.Any())
            {
                context.Projects.AddRange(

                    new Project
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },

                    new Project
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Pages = 944

                    },

                    new Project
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Pages = 832
                    },

                    new Project
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Pages = 864
                    },

                    new Project
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        Pages = 528
                    },

                    new Project
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        Pages = 288
                    },

                    new Project
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        Pages = 304
                    },

                    new Project
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        Pages = 240
                    },

                    new Project
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        Pages = 400
                    },

                    new Project
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        Pages = 642
                    },

                    new Project
                    {
                        Title = "Harry Potter",
                        AuthorFirst = "J.K.",
                        AuthorLast = "Rowling",
                        Publisher = "Bloomsbury",
                        ISBN = "978-0747532743",
                        Classification = "Fiction",
                        Category = "Adventure",
                        Price = 6.98,
                        Pages = 223
                    },

                    new Project
                    {
                        Title = "Eragon",
                        AuthorFirst = "Christopher",
                        AuthorLast = "Paolini",
                        Publisher = "Paolini LLC",
                        ISBN = "978-0440240730",
                        Classification = "Fiction",
                        Category = "Adventure",
                        Price = 6.77,
                        Pages = 544
                    },

                    new Project
                    {
                        Title = "How to Win Friends & Influence People",
                        AuthorFirst = "Dale",
                        AuthorLast = "Carnegie",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0091906351",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 6.77,
                        Pages = 544
                    }

                    ); //writing to the database here

                context.SaveChanges();
            }
        }
        
    }
}

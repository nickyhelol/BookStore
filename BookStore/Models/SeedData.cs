using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider service)
        {
            ApplicationDbContext context = service.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Sharp Objects",
                    Author = "Gillian Flynn",
                    Category = "Fiction",
                    Price = 21.76M
                },
                new Product
                {
                    Name = "A Place for Us",
                    Author = "Fatima Farheen Mirza",
                    Category = "Fiction",
                    Price = 37.96M
                },
                new Product
                {
                    Name = "Something in the Water",
                    Author = "Catherine Steadman",
                    Category = "Fiction",
                    Price = 36.77M
                },
                new Product
                {
                    Name = "This is Going to Hurt",
                    Author = "Adam Kay",
                    Category = "Biography",
                    Price = 20.68M
                },
                new Product
                {
                    Name = "When Breath Becomes Air",
                    Author = "Paul Kalanithi",
                    Category = "Biography",
                    Price = 21.76M
                },
                new Product
                {
                    Name = "Elon Musk",
                    Author = "Ashlee Vance",
                    Category = "Biography",
                    Price = 11.53M
                },
                new Product
                {
                    Name = "Call Me By Your Name",
                    Author = "Andre Aciman",
                    Category = "Romance",
                    Price = 21.76M
                },
                new Product
                {
                    Name = "Before We Were Yours",
                    Author = "Lisa Wingate",
                    Category = "Romance",
                    Price = 15.37M
                },
                new Product
                {
                    Name = "War Light",
                    Author = "Micheal Ondaatje",
                    Category = "Romance",
                    Price = 32.65M
                }
                );
                context.SaveChanges();
            }
        }
    }
}

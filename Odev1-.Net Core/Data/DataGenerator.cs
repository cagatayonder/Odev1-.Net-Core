using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Odev1_.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                    new Author { Name = "Çağatay", Surname = "ÖNDER", Birthday = new DateTime(20 / 06 / 1994) },
                        new Author { Name = "Mahmut", Surname = "ŞAHİN", Birthday = new DateTime(07 / 06 / 1996) },
                            new Author { Name = "Recep Can", Surname = "KEÇECİ", Birthday = new DateTime(13 / 01 / 1994)});
                context.Genres.AddRange(
                    new Genre { Name = "Personal-Growth" },
                    new Genre { Name = "Science-Fiction" },
                    new Genre { Name = "Romance" });
                context.Books.AddRange(
            new Book { /*Id = 1,*/ Title = "Lean Startup", GenreId = 1, PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
            new Book { /*Id = 2,*/ Title = "Herland", GenreId = 2, PageCount = 250, PublishDate = new DateTime(2001, 05, 23) },
            new Book { /*Id = 3,*/ Title = "Dune", GenreId = 3, PageCount = 540, PublishDate = new DateTime(2001, 12, 21) });
                context.SaveChanges();
            }
        }
    }
}

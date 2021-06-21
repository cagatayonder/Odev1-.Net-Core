using Odev1_.Net_Core.Data;
using Odev1_.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.Applications.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
{
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext context;
        public CreateGenreCommand(BookStoreDbContext context)
        {
            this.context = context;
        }

        public void Handle()
        {
            var genre = context.Genres.FirstOrDefault(x=>x.Name == Model.Name );

            if (genre is not null)
                throw new InvalidOperationException("Kitap türü zaten mevcut.");

            genre = new Genre();
            genre.Name = Model.Name;
            context.Genres.Add(genre);
            context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}


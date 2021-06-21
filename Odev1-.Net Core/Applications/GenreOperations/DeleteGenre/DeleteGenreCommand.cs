using Odev1_.Net_Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.Applications.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }

        private readonly BookStoreDbContext context;
        public DeleteGenreCommand(BookStoreDbContext context)
        {
            this.context = context;
        }

        public void Handle()
        {
            var genre = context.Genres.FirstOrDefault(x => x.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("Kitap Türü Bulunamadı");

            context.Genres.Remove(genre);
            context.SaveChanges();
        }
    }
}

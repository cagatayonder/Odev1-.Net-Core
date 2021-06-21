using AutoMapper;
using Odev1_.Net_Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.Applications.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public int GenreId { get; set; }

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public GenreDetailViewModel Handle()
        {
            var genre = context.Genres.FirstOrDefault(x =>x.IsActive && x.Id == GenreId);
            if(genre == null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            GenreDetailViewModel genreDetail = mapper.Map<GenreDetailViewModel>(genre);
            return genreDetail;
        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}



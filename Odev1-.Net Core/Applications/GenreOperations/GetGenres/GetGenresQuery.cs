using AutoMapper;
using Odev1_.Net_Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.Applications.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GetGenresQuery(BookStoreDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<GenreViewModel> Handle()
        {
            var genres = context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenreViewModel> dtoList = mapper.Map<List<GenreViewModel>>(genres);
            return dtoList;
        }
    }
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

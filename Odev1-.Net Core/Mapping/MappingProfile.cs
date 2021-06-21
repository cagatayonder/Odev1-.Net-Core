using AutoMapper;
using Odev1_.Net_Core.Applications.AuthorOperations;
using Odev1_.Net_Core.Applications.AuthorOperations.GetAuthorDetail;
using Odev1_.Net_Core.Applications.GenreOperations.GetGenreDetail;
using Odev1_.Net_Core.Applications.GenreOperations.GetGenres;
using Odev1_.Net_Core.BookOperation.GetBooks;
using Odev1_.Net_Core.BookOperation.GetBooksById;
using Odev1_.Net_Core.Common;
using Odev1_.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Odev1_.Net_Core.BookOperation.CreateBook.CreateBookCommand;

namespace Odev1_.Net_Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<Author, AuthorViewModel>();
        }
    }
}

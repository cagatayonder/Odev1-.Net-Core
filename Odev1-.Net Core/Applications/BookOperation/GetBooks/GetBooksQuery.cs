using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Odev1_.Net_Core.Common;
using Odev1_.Net_Core.Data;
using Odev1_.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.BookOperation.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public GetBooksQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public List<BookViewModel> Handle()
        {
            var bookList = dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BookViewModel> vm = mapper.Map<List<BookViewModel>>(bookList);
            return vm;
        }
    }
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}

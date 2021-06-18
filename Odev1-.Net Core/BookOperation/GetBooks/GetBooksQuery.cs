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

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<BookViewModel> Handle()
        {
            var bookList = dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BookViewModel> vm = new List<BookViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BookViewModel()
                {
                    Title = book.Title,
                    GenreId = ((GenreEnum)book.GenreId).ToString(),
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy")
                });
            }
            return vm;
        }
    }
    public class BookViewModel
    {
        public string Title { get; set; }
        public string GenreId { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}

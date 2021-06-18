using Odev1_.Net_Core.Common;
using Odev1_.Net_Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.BookOperation.GetBooksById
{
    public class GetBookDetail
    {
        private readonly BookStoreDbContext dbContext;
        public int BookId { get; set; }

        public GetBookDetail(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public BookDetailViewModel Handle()
        {
            var book = dbContext.Books.FirstOrDefault(x => x.Id == BookId);
            if (book == null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = book.Title;
            vm.PublishDate = book.PublishDate.ToString("dd/MM/yyyy");
            vm.PageCount = book.PageCount;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}

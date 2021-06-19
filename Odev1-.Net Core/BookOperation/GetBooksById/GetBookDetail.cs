using AutoMapper;
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
        private readonly IMapper mapper;
        public int BookId { get; set; }

        public GetBookDetail(BookStoreDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = dbContext.Books.FirstOrDefault(x => x.Id == BookId);
            if (book == null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            BookDetailViewModel vm = mapper.Map<BookDetailViewModel>(book);
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

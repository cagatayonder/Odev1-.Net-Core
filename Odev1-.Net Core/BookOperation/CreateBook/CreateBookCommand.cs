using AutoMapper;
using Odev1_.Net_Core.Data;
using Odev1_.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.BookOperation.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void Handle()
        {
            var book = dbContext.Books.FirstOrDefault(x => x.Title == Model.Title);
            if (book != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }
            book = mapper.Map<Book>(Model);
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
            
        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}

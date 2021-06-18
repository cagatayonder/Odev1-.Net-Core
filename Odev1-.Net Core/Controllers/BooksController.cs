using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev1_.Net_Core.BookOperation.CreateBook;
using Odev1_.Net_Core.BookOperation.DeleteBook;
using Odev1_.Net_Core.BookOperation.GetBooks;
using Odev1_.Net_Core.BookOperation.GetBooksById;
using Odev1_.Net_Core.BookOperation.UpdateBook;
using Odev1_.Net_Core.Data;
using Odev1_.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Odev1_.Net_Core.BookOperation.CreateBook.CreateBookCommand;
using static Odev1_.Net_Core.BookOperation.UpdateBook.UpdateBookCommand;

namespace Odev1_.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext bookStoreDbContext;

        public BooksController(BookStoreDbContext bookStoreDbContext)
        {
            this.bookStoreDbContext = bookStoreDbContext;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(bookStoreDbContext);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetail detail = new GetBookDetail(bookStoreDbContext);
                detail.BookId = id;
                result = detail.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(bookStoreDbContext);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
        {

            try
            {
                UpdateBookCommand command = new UpdateBookCommand(bookStoreDbContext);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
            
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(bookStoreDbContext);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
    
}

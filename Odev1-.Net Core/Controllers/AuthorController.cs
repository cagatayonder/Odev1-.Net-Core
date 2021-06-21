using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev1_.Net_Core.Applications.AuthorOperations;
using Odev1_.Net_Core.Applications.AuthorOperations.CreateAuthor;
using Odev1_.Net_Core.Applications.AuthorOperations.DeleteAuthor;
using Odev1_.Net_Core.Applications.AuthorOperations.GetAuthorDetail;
using Odev1_.Net_Core.Applications.AuthorOperations.UpdateAuthor;
using Odev1_.Net_Core.BookOperation.CreateBook;
using Odev1_.Net_Core.BookOperation.DeleteBook;
using Odev1_.Net_Core.BookOperation.GetBooks;
using Odev1_.Net_Core.BookOperation.GetBooksById;
using Odev1_.Net_Core.BookOperation.UpdateBook;
using Odev1_.Net_Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Odev1_.Net_Core.Applications.AuthorOperations.CreateAuthor.CreateAuthorCommand;
using static Odev1_.Net_Core.Applications.AuthorOperations.UpdateAuthor.UpdateAuthorCommand;

namespace Odev1_.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext bookStoreDbContext;
        private readonly IMapper mapper;

        public AuthorController(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            this.bookStoreDbContext = bookStoreDbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query = new GetAuthorQuery(bookStoreDbContext, mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AuthorDetailViewModel result;
            try
            {
                GetAuthorDetailQuery detail = new GetAuthorDetailQuery(bookStoreDbContext, mapper);
                detail.AuthorId = id;
                GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
                validator.ValidateAndThrow(detail);
                result = detail.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(bookStoreDbContext, mapper);
            try
            {
                command.Model = newAuthor;
                CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {

            try
            {
                UpdateAuthorCommand command = new UpdateAuthorCommand(bookStoreDbContext);
                command.AuthorId = id;
                command.Model = updatedAuthor;
                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                DeleteAuthorCommand command = new DeleteAuthorCommand(bookStoreDbContext);
                command.AuthorId = id;
                DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
                validator.ValidateAndThrow(command);
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


using AutoMapper;
using Odev1_.Net_Core.Data;
using Odev1_.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.Applications.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void Handle()
        {
            var author = dbContext.Authors.FirstOrDefault(x => x.Name == Model.Name);
            if (author != null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut");
            }
            author = mapper.Map<Author>(Model);
            dbContext.Authors.Add(author);
            dbContext.SaveChanges();

        }
        public class CreateAuthorModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}

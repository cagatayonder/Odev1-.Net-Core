using AutoMapper;
using Odev1_.Net_Core.Data;
using Odev1_.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.Applications.AuthorOperations
{
    public class GetAuthorQuery
    {
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public GetAuthorQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var authorList = dbContext.Authors.OrderBy(x => x.Id).ToList<Author>();
            List<AuthorViewModel> vm = mapper.Map<List<AuthorViewModel>>(authorList);
            return vm;
        }
    }
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}


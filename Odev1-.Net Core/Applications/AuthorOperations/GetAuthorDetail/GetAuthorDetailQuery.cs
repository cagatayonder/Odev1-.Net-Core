using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Odev1_.Net_Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.Applications.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery

    { 
    private readonly BookStoreDbContext dbContext;
    private readonly IMapper mapper;
    public int AuthorId { get; set; }

    public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    public AuthorDetailViewModel Handle()
    {
        var author = dbContext.Authors.FirstOrDefault(x => x.Id == AuthorId);
        if (author == null)
        {
            throw new InvalidOperationException("Kitap bulunamadı");
        }
            AuthorDetailViewModel vm = mapper.Map<AuthorDetailViewModel>(author);
        return vm;
    }
}
    public class AuthorDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}

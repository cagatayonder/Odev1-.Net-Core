using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.BookOperation.GetBooksById
{
    public class GetBookDetailValidator :AbstractValidator<GetBookDetail>
    {
        public GetBookDetailValidator()
        {
            RuleFor(detail => detail.BookId).GreaterThan(0);
        }
    }
}

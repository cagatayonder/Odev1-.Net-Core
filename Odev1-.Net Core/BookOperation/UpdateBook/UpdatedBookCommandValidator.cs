using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_.Net_Core.BookOperation.UpdateBook
{
    public class UpdatedBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdatedBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}

using FluentValidation;
using Library.Domain.Entities;

namespace Library.Application.Books.Validations
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(c => c.Title).NotEmpty().WithMessage("نام کتاب الزامی است");
        }
    }
}

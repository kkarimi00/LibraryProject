using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Commands
{
    public record UpdateBookCommand(Book book) : IRequest<Book>;

}

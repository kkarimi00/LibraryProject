using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Commands
{
    public record CreateBookCommand(string Title, string Author, string Isbn, int BookTypeId): IRequest<Book>;
    
}

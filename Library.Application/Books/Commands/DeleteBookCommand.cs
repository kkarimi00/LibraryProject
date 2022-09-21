using MediatR;

namespace Library.Application.Books.Commands
{
    public record DeleteBookCommand(int Id) : IRequest;
}

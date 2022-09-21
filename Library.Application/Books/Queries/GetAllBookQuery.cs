using Library.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Library.Application.Books.Queries
{
    public record GetAllBookQuery : IRequest<List<Book>>;
}

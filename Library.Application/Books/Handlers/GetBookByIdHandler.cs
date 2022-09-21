using Library.Application.Books.Queries;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Books.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        public IBookRepository bookRepository;
        public GetBookByIdHandler(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await bookRepository.GetBookById(request.Id);
        }
    }
}

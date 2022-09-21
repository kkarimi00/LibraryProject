using Library.Application.Books.Queries;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Books.Handlers
{
    public class GetAllBookHandler : IRequestHandler<GetAllBookQuery, List<Book>>
    {
        public IBookRepository bookRepository;
        public GetAllBookHandler(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        public async Task<List<Book>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            return await bookRepository.Get();
        }
    }
}

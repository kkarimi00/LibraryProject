using Library.Application.Books.Commands;
using Library.Domain.RepositoryContracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Books.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        public IBookRepository bookRepository { get; }
        public DeleteBookHandler(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetBookById(request.Id);
            if (book == null)
            {
                throw new NullReferenceException("Could not find the book");
            }
            bookRepository.Delete(book);
            return Unit.Value;
        }
    }
}

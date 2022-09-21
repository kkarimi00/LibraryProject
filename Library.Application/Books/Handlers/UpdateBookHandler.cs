using Library.Application.Books.Commands;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Books.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        public IBookRepository bookRepository;
        public UpdateBookHandler(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetBookById(request.book.Id);
            if (book == null || book.Id != request.book.Id)
            {
                throw new NullReferenceException("Could not find the book");
            }
            return bookRepository.Update(request.book);
        }
    }
}

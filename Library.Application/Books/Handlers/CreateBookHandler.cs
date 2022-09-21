using Library.Application.Books.Commands;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Books.Handlers
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Book>
    {
        public IBookRepository bookRepository { get; }
        public CreateBookHandler(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Title))
            {
                var book = new Book
                {
                    Title = request.Title,
                    Author = request.Author,
                    Isbn = request.Isbn,
                    BookTypeId = request.BookTypeId
                };
                return await bookRepository.Add(book);
            }
            else
                throw new ArgumentNullException("Book name is Empty");
        }
    }
}

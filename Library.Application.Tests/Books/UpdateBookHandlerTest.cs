using Library.Application.Books.Commands;
using Library.Application.Books.Handlers;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using NSubstitute;

namespace Library.Application.Tests.Books
{
    public class UpdateBookHandlerTest
    {
        private IBookRepository bookRepository;
        private Book book;
        private UpdateBookCommand _validCommand;
        public UpdateBookHandlerTest()
        {
            bookRepository = Substitute.For<IBookRepository>();
            CreateValidCommand();
            SetUpDependencies();
        }
        private void CreateValidCommand()
        {
            book = new Book
            {
                Id = 1,
                Title = "Inside Reading",
                Author = "Lawrence",
                Isbn = string.Empty
            };
            _validCommand = new UpdateBookCommand(book);
        }
        private void SetUpDependencies()
        {
            bookRepository.Update(Arg.Is<Book>(book)).Returns(book);
            bookRepository.GetBookById(Arg.Is<Int32>(book.Id)).Returns(book);
        }

        [Fact]
        public async Task Update_ShouldReturnBook_DoItSuccessfully()
        {
            //arrange
            var updateBookHandler = new UpdateBookHandler(bookRepository);
            book.Title = "Inside Reading2";
            //act
            Book _book = await updateBookHandler.Handle(_validCommand, CancellationToken.None);
            //assert
            Assert.Equal(book.Id, _book.Id);
            Assert.Equal(book.Title, _book.Title);
        }

        [Fact]
        public async void Update_ShouldReturnError_NotDoItSuccessfully()
        {
            //arrange
            var updateBookHandler = new UpdateBookHandler(bookRepository);
            book.Id = 0;
            //act
            Func<Task> result = async () => await updateBookHandler.Handle(_validCommand, CancellationToken.None);
            //assert
            await Assert.ThrowsAsync<NullReferenceException>(result);
        }
    }
}

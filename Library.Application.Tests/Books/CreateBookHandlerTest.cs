using AutoFixture;
using Library.Application.Books.Commands;
using Library.Application.Books.Handlers;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using NSubstitute;

namespace Library.Application.Tests.Books
{
    public class CreateBookHandlerTest
    {
        IBookRepository bookRepository;
        Book book;
        BookType bookType;
        private CreateBookCommand validCommand;
        private CreateBookCommand invalidCommand;
        public CreateBookHandlerTest()
        {
            bookRepository = Substitute.For<IBookRepository>();
            SetUpDependencies();
            CreateValidCommand();
            CreateInvalidCommand();
        }
        private void SetUpDependencies()
        {
            Fixture fixture = new();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            bookType = fixture.Build<BookType>()
                         .With(c => c.Id, 1)
                         .Create();
            book = fixture.Build<Book>()
                      .With(c => c.BookTypeId, bookType.Id)
                      .Create();
            bookRepository.Add(Arg.Is<Book>(book)).Returns(book);
        }
        private void CreateValidCommand()
        {
            validCommand = new CreateBookCommand("Inside Reading", "Lawrence", string.Empty, bookType.Id);
        }
        private void CreateInvalidCommand()
        {
            invalidCommand = new CreateBookCommand(String.Empty, "Lawrence", string.Empty, bookType.Id);
        }

        [Fact]
        public void Add_ShouldReturnBook_DoItSuccessfully()
        {
            //arrange
            var creatBookHandler = new CreateBookHandler(bookRepository);
            //act
            var book = creatBookHandler.Handle(validCommand, CancellationToken.None);
            //assert
            Assert.True(book.Id > 0);
        }

        [Fact]
        public async void Add_ShouldReturnError_NotDoItSuccessfully()
        {
            //arrange
            var creatBookHandler = new CreateBookHandler(bookRepository);
            //act
            Func<Task> result = async () => await creatBookHandler.Handle(invalidCommand, CancellationToken.None);
            //assert
            await Assert.ThrowsAsync<ArgumentNullException>(result);
        }
    }
}

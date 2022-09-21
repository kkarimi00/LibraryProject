using AutoFixture;
using Library.Application.Books.Commands;
using Library.Application.Books.Handlers;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using NSubstitute;

namespace Library.Application.Tests.Books
{
    public class DeleteBookHandlerTest
    {
        private IBookRepository bookRepository;
        private DeleteBookCommand _validCommand;       
        private Book book=new();
        public DeleteBookHandlerTest()
        {
            bookRepository = Substitute.For<IBookRepository>();
            SetUpDependencies();
            CreateValidCommand();
        }
        private void SetUpDependencies()
        {
            Fixture fixture = new();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            book = fixture.Build<Book>()
                .With(c => c.Id, 10)
                .Create();
            bookRepository.Delete(Arg.Is<int>(book.Id));
            bookRepository.GetBookById(Arg.Is<int>(book.Id)).Returns(book);
        }
        private void CreateValidCommand()
        {
            _validCommand = new DeleteBookCommand(book.Id);
        }

        [Fact]
        public async void Delete_ShouldDeleteBook_DoItSuccessfully()
        {
            //arrange
            var deleteBookHandler = new DeleteBookHandler(bookRepository);
            //act
            var result = await deleteBookHandler.Handle(_validCommand, CancellationToken.None);
            //assert
            Assert.IsType<MediatR.Unit>(result);
        }
    }
}

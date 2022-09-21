using AutoFixture;
using FluentValidation.TestHelper;
using Library.Application.Books.Validations;
using Library.Domain.Entities;

namespace Library.Application.Tests.Books
{
    public class BookValidationTest
    {
        private BookValidation _validator;
        private Book book;
        public BookValidationTest()
        {
            Setup();
        }

        public void Setup()
        {
            _validator = new BookValidation();
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            book = fixture.Build<Book>()
                      .With(c => c.Title, string.Empty)
                      .Create();
        }

        [Fact]
        public void ValidateTitle()
        {

            var result = _validator.TestValidate(book);
            result.ShouldHaveValidationErrorFor(c => c.Title);
        }
    }
}

using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.RepositoryContracts
{
    public interface IBookRepository
    {
        Task<Book> Add(Book book);
        Book Update(Book book);
        void Delete(object id);
        void Delete(Book book);
        Task<List<Book>> Get();
        Task<Book> GetBookById(int id);
    }
}

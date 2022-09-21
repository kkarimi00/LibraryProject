using Library.Data.Context;
using Library.Domain.Entities;
using Library.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ILibraryDbContext _ctx { get; set; }
        public BookRepository(ILibraryDbContext context)
        {
            _ctx = context;
        }
        public async Task<Book> Add(Book book)
        {
            _ctx.Books.Add(book);
            await _ctx.SaveChange();
            return book;
        }

        public void Delete(object id)
        {
            Book entityToDelete = _ctx.Books.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(Book book)
        {
            _ctx.Books.Remove(book);
            _ctx.SaveChange();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _ctx.Books.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> Get()
        {
            return await _ctx.Books.ToListAsync();
        }

        public Book Update(Book book)
        {
            _ctx.Books.Update(book);
            _ctx.SaveChange();
            return book;
        }
    }
}

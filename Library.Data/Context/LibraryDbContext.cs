using Library.Data.Configurations;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Context
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }

        public LibraryDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new BookTypeConfiguration());
        }

        public async Task<int> SaveChange()
        {
            return await base.SaveChangesAsync();
        }
    }
}

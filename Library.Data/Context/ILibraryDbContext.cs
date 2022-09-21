using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Context
{
    public interface ILibraryDbContext
    {
        DbSet<Book> Books { get; set; }      
        Task<int> SaveChange();
    }
}

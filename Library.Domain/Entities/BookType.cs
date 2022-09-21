using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class BookType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Book> Books  { get; set; }

    }
}

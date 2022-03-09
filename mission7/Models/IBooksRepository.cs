using System;
using System.Linq;

namespace mission7.Models
{
    public interface IBooksRepository
    {
        IQueryable<Book> Books { get; }

        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);
    }
}

﻿using System;
using System.Linq;

namespace mission7.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private BookstoreContext context { get; set; }

        public EFBooksRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}


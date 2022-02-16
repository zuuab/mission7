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

        public IQueryable<Books> Books => context.Books;
    }
}


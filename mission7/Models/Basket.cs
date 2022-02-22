using System;
using System.Collections.Generic;
using System.Linq;

namespace mission7.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Books b, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Books.BookId == b.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = b,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public class BasketLineItem
        {
            public int LineID { get; set; }
            public Books Books { get; set; }
            public int Quantity { get; set; }
        }
    }
}

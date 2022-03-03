using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace mission7.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Books b, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Books.BookId == b.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = b,
                    Quantity = qty,
                    Price = b.Price
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Books book)
        {
            Items.RemoveAll(x => x.Books.BookId == book.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Price);

            return sum;
        }

        public class BasketLineItem
        {
            [Key]
            public int LineID { get; set; }
            public Books Books { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }
    }
}

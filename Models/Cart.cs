using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeAmazon.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();        
            public virtual void AddItem(Project book, int price)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Price = price   
                });
            }
            else
            {
                line.Price += price;
            }
        }

        public virtual void RemoveLine(Project book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public virtual void Clear() => Lines.Clear();

        public double ComputeTotalSum()
        {
            return Lines.Sum(e => e.Book.Price * e.Price);
        }
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Project Book { get; set; }

            public int Quantity { get; set; }

            public int Price { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var author = new Author
            {
                FullName = "Pushkin"
            };

            //var book = new Book
            //{
            //    Name = "skazki",
            //    Price = 1000,
            //    Author = author
            //};

            List<Book> books = new List<Book>
            {
                new Book
                {
                    Name = "skazki",
                    Price = 1000,
                    Author = author
                },
                new Book
                {
                    Name = "poemy",
                    Price = 1200,
                    Author = author
                },
                new Book
                {
                    Name = "proza",
                    Price = 1400,
                    Author = author
                }
            };

            Book bookForVisitor = new Book();
            foreach(var bfv in books)
            {
                if (bfv.Name == "poemy")
                    bookForVisitor = bfv;
            }

            List<Visitor> visitors = new List<Visitor>
            {
                new Visitor
                {
                    FullName = "Alex", BookForHand = new Dictionary<Book, DateTime> { { bookForVisitor, DateTime.Now} }
                },
                new Visitor
                {
                    FullName = "Tima", BookForHand = new Dictionary<Book, DateTime> { { bookForVisitor, DateTime.Now} }
                }
            };
            
            using (var context = new AppContext())
            {
                context.Authors.Add(author);
                context.Books.AddRange(books);
                context.Visitors.AddRange(visitors);
                context.SaveChanges();
            }
        }
    }
}

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
            
            List<Author> authors = new List<Author> { new Author { FullName = "Puskin" }, new Author { FullName = "Krylov" }};

            List<Book> books = new List<Book>
            {
                new Book { Name = "skazki",  Price = 1000, Authors = new List<Author> {authors[0], authors[1]} },
                new Book { Name = "poemy", Price = 1200, Authors = new List<Author> {authors[0]} },
                new Book { Name = "proza", Price = 1400, Authors = new List<Author> {authors[0]} },
                new Book { Name = "basni", Price = 1400, Authors = new List<Author> {authors[1], authors[0] }}
            };

            List<Visitor> visitors = new List<Visitor>();
            
            visitors.Add(new Visitor
            {
                FullName = "Tima",
                Books = new List<Book> { books[0] },
                Debtor = false,
                Date = DateTime.Now
            });

            visitors.Add(new Visitor
            {
                FullName = "Alex",
                Books = new List<Book> { books[2], books[3] },
                Debtor = true,
                Date = DateTime.Now
            });

            //using (var context = new AppContext())
            //{
            //    context.Authors.AddRange(authors);
            //    context.Books.AddRange(books);
            //    context.Visitors.AddRange(visitors);
            //    context.SaveChanges();
            //}

            using (var context = new AppContext())
            {
                foreach (var debtor in context.Database.SqlQuery<Visitor>("select * from Visitors where Debtor = 1 "))
                {
                    Console.WriteLine(debtor.FullName);
                }

                foreach (var author in context.Database.SqlQuery<Author>
                    ($"select a.Id, a.FullName from Books b, Authors a, BookAuthors ba where b.Id = ba.Book_Id and a.Id = ba.Author_Id and b.Id = '{context.Books.ToList()[2].Id}'"))
                {
                    Console.WriteLine(author.FullName);
                }

                foreach(var book in context.Database.SqlQuery<Book>
                    ("select * from Books where Visitor_Id is NULL"))
                {
                    Console.WriteLine(book.Name);
                }

                foreach (var book in context.Database.SqlQuery<Book>
                    ($"select * from Books where Visitor_Id = '{context.Visitors.ToList()[1].Id}'"))
                {
                    Console.WriteLine(book.Name);
                }

                for (int i = 0; i < context.Visitors.Count(); i++)
                {
                    if (context.Visitors.ToList()[i].Debtor)
                    {
                        context.Visitors.ToList()[i].Debtor = false;
                        context.SaveChanges();
                    }
                }
                
            }
            Console.ReadLine();
        }
    }
}

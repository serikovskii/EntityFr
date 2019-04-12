using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EfIntroduction
{
    public class AppContext : DbContext
    {
        public AppContext() : base("appContext")
        {}

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
    }
}

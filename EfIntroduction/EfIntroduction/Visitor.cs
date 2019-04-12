using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfIntroduction
{
    public class Visitor : Entity
    {
        public string FullName { get; set; }
        public ICollection<Book> Books { get; set; }
        public bool Debtor { get; set; }
        public DateTime Date { get; set; }       
    }
}

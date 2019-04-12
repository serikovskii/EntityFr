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
        public Dictionary <Book, DateTime> BookForHand { get; set; }
        public bool Deptor { get; set; }

        
    }
}

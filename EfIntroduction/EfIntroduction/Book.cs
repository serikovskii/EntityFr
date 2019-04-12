using System;
using System.Collections.Generic;

namespace EfIntroduction
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherDomain
{
    public class Author
    {
        public Author()
        {
            Books = new Book();
        }

        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Book> Books { get; set; }

    }
}

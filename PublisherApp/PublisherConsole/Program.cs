using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

internal class Program
{
    private static void Main(string[] args)
    {
        using (PubContext context = new PubContext())
        {
            context.Database.EnsureCreated();
        }

      //  AddAuthor();
     //  GetAuthors();
        AddAuthorWithBooks();
        GetAuthorWithBooks();
    }


    static void GetAuthors()
    {
        using var context = new PubContext();
        var authors = context.Authors.ToList();
        foreach (var author in authors)
        {
            Console.WriteLine(author.FirstName + " " + author.LastName);
        }
    }

    static void AddAuthor()
    {
        var author = new Author { FirstName = "John", LastName = "Tolkien"};
        using var context = new PubContext();
        context.Authors.Add(author);
        context.SaveChanges();
    }

      static void AddAuthorWithBooks()
       {
           var author = new Author { FirstName = "Bobby", LastName = "Tompson" };
           author.Books.Add(new Book { Title = "Book 1", PublishDate = new DateTime(2001, 1, 28)});
           author.Books.Add(new Book { Title = "Book 2", PublishDate = new DateTime(1980, 3, 23)});

           using var context = new PubContext();
           context.Authors.Add(author);
           context.SaveChanges();
       }


    static void GetAuthorWithBooks()
    {
        using var context = new PubContext();
        var authors = context.Authors.Include(b => b.Books).ToList();
        foreach (var author in authors)
        {
            Console.WriteLine(author.FirstName + " " +author.LastName);
            Console.WriteLine( "  Has books : " + Environment.NewLine);
            foreach (var book in author.Books)
            {
                Console.WriteLine( book.Title +" "+ book.PublishDate.ToString());
            }
        }
    }

}
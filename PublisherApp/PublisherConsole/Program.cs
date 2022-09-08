using PublisherData;
internal class Program
{
    private static void Main(string[] args)
    {
        using (PubContext context = new PubContext())
        {
            context.Database.EnsureCreated();
        }

        GetAuthors();
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
}
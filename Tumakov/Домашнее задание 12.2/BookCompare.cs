public class BookCompare
{
    public static int Naming(Book a, Book b)
    {
        return string.Compare(a.Name, b.Name);
    }

    public static int Authorship(Book a, Book b)
    {
        return string.Compare(a.Author, b.Author);
    }

    public static int Publication(Book a, Book b)
    {
        return string.Compare(a.Publish, b.Publish);
    }
}
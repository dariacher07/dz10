public class Book
{
    public string Name;
    public string Author;
    public string Publish;

    public Book(string Name, string Author, string Publish)
    {
        this.Name = Name;
        this.Author = Author;
        this.Publish = Publish;
    }
    public override string ToString()
    {
        return  Name + " Автор: " + Author + " Издательство: " + Publish ;
    }
}

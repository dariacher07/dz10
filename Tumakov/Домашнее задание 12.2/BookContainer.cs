public class BookContainer
{
    private Book[] books;
    public BookContainer(params Book[] books) //принимает любое число аргументов
    {
        this.books = books;
    }
    public void Sorting(SortingBooks compare)
    {
        for (int i = 0; i < books.Length - 1; i++)//проходит по всем элементам кроме последнего
        {
            for (int j = i + 1; j < books.Length; j++)//проходит по элементам после i
            {
                if (compare(books[i], books[j]) > 0)
                {
                    Book temp = books[i];
                    books[i] = books[j];
                    books[j] = temp;
                }
            }
        }
    }
    public void PrintInfo()
    {
        for (int i = 0; i < books.Length; i++)
        {
            Console.WriteLine(books[i].ToString());
        }
    }
}

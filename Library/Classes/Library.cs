namespace Library.Classes;

public static class Library
{
    public static List<Book> Books = new List<Book>();

    public static void AddBook(string bookTitle, string bookAuthor, int bookPages)
    {
        var result = Books.FirstOrDefault(book => book.Title == bookTitle && book.Author == bookAuthor);
        if (result != null)
        {
            Console.WriteLine("Book already exists!");
        }
        else
        {
            Book newBook = new Book(bookTitle, bookAuthor, bookPages);
            Books.Add(newBook);
            Console.WriteLine("New book created!");
        }
    }

    public static void ShowBookInformation(string bookName, string bookAuthor)
    {
        var result = Books.FirstOrDefault(book => book.Title == bookName && book.Author == bookAuthor);
        if (result != null)
        {
            Console.WriteLine("Book details:");
            Console.WriteLine($"Book title: {result.Title}, \n Book author: {result.Author}, \n Total Pages: {result.Pages}");
            if (result.Pages > 300)
            {
                Console.WriteLine("Total Pages exceeds 300!");
            }
            else
            {
                Console.WriteLine("Total Pages is below 300!");
            }
        }
        else
        {
            Console.WriteLine("Book not found!");
        }
    }
}
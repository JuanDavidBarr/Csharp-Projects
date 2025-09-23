namespace Library.Classes;

public static class Menu
{
    public static void ShowMenu()
    {
        bool leaveMenu = false;
        while (!leaveMenu)
        {
            Console.WriteLine("==== Welcome to Library Menu ====");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add book");
            Console.WriteLine("2) Show book information");
            Console.WriteLine("3) Leave this menu");
            string userOption =  Console.ReadLine();
            switch (userOption)
            {
                case "1":
                    string newTitle = EmptyInputValidation("Enter new title: ");
                    string newAuthor = EmptyInputValidation("Enter new author: ");
                    int totalPages = IntegerValidation("Enter the total pages: ");
                    Library.AddBook(newTitle, newAuthor, totalPages);
                    break;
                case "2":
                    string bookTitle = EmptyInputValidation("Enter book title: ");
                    string bookAuthor = EmptyInputValidation("Enter book author: ");
                    Library.ShowBookInformation(bookTitle, bookAuthor);
                    break;
                case "3":
                    leaveMenu = true;
                    Console.WriteLine("Leaving this menu");
                    break;
                default:
                    Console.WriteLine("Invalid option, try again");
                    break;
            }
        }
    }

    public static string EmptyInputValidation(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Value required, try again");
            }
        }
    }

    public static int IntegerValidation(string prompt)
    {
        while (true)
        {
            var input = EmptyInputValidation(prompt);
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Value is not a number, try again");
            }
        }
    }
}
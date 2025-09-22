namespace Store.Classes;

public class Menu
{
    Store storeManagement = new Store();
    public void ShowMenu()
    {
        bool leaveMenu = false;
        while (!leaveMenu)
        {
            Console.WriteLine("=====Welcome to the Menu=====");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. Show product details");
            Console.WriteLine("3. Sell product");
            Console.WriteLine("4. Leave this menu");
            string userOption = Console.ReadLine();
            switch (userOption)
            {
                case "1":
                    Console.WriteLine("==== Adding a product =====");
                    string newProductName = EmptyInputValidation("Enter new product name: ");
                    double newProductPrice = DoubleInputValidation("Enter new product price: ");
                    int newProductStock = IntegerInputValidation(("Enter new product stock: "));
                    storeManagement.AddProduct(newProductName, newProductPrice, newProductStock);
                    break;
                case "2":
                    Console.WriteLine("==== Showing product details =====");
                    string productNameToShow = EmptyInputValidation("Enter product name: ");
                    storeManagement.ShowProducts(productNameToShow);
                    break;
                case "3":
                    Console.WriteLine("==== Selling product =====");
                    string productNameToSell = EmptyInputValidation("Enter product name: ");
                    int productStockToSell = IntegerInputValidation("How many units do you want to sell?: ");
                    storeManagement.SellProducts(productNameToSell, productStockToSell);
                    break;
                case "4":
                    Console.WriteLine("==== Leaving this menu =====");
                    leaveMenu = true;
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    break;
            }
            
        }
    }

    public static string EmptyInputValidation(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine()?.Trim();
            if (!String.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Value required, try again.");
            }
        }
    }

    public static double DoubleInputValidation(string prompt)
    {
        while (true)
        {
            var input = EmptyInputValidation(prompt);
            if (double.TryParse(input, out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Value is not a number, try again.");
            }
        }
    }
    
    public static int IntegerInputValidation(string prompt)
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
                Console.WriteLine("Value is not a number, try again.");
            }
        }
    }
}
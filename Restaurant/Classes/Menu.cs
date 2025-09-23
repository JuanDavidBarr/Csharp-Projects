namespace Restaurant.Classes;

public class Menu()
{
    public static void ShowMenu()
    {
        bool leaveMenu = false;
        while (!leaveMenu)
        {
            Console.WriteLine("==== Welcome to Restaurant Menu ====");
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1) New order: ");
            Console.WriteLine("2) Order total: ");
            Console.WriteLine("3) Show order details:");
            Console.WriteLine("4) Leave this menu");
            string userOption = Console.ReadLine();

            switch (userOption)
            {
                case "1":
                    bool additionalDish = true;
                    List<Dish> newDishList = new List<Dish>();
                    Console.WriteLine("==== Adding new order ====");
                    int newOrderTable = IntegerInputValidation("Table number:");
                    while (additionalDish)
                    {
                        string newDishName = EmptyInputValidation("Dish name: ");
                        double newDishPrice = DoubleInputValidation("Dish price: ");
                        Dish newDish = new Dish(newDishName, newDishPrice);
                        newDishList.Add(newDish);
                        userOption = YesNoInputValidation("Do you want to add a new dish? (y/n)");
                        if (userOption == "y")
                        {
                            Console.WriteLine("==== Adding new dish ====");
                        }
                        else if (userOption == "n")
                        {
                            additionalDish = false;
                        }
                    }
                    Restaurant.AddOrder(newOrderTable, newDishList);
                    break;
                case "2":
                    Console.WriteLine("==== Total ====");
                    int tableNumber = IntegerInputValidation("Table number: ");
                    Restaurant.ShowTotal(tableNumber);
                    break;
                case "3":
                    Console.WriteLine("==== Order details ====");
                    tableNumber = IntegerInputValidation("Table number: ");
                    Restaurant.ShowOrderDetails(tableNumber);
                    break;
                case "4":
                    leaveMenu = true;
                    Console.WriteLine("Leaving this menu!");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    public static string EmptyInputValidation(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Value required, please try again");
            }
        }
    }

    public static double DoubleInputValidation(string prompt)
    {
        while (true)
        {
            string input = EmptyInputValidation(prompt);
            if (double.TryParse(input, out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Value is not a number, please try again");
            }
        }
    }
    
    public static int IntegerInputValidation(string prompt)
    {
        while (true)
        {
            string input = EmptyInputValidation(prompt);
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Value is not a number, please try again");
            }
        }
    }

    public static string YesNoInputValidation(string prompt)
    {
        while (true)
        {
            string input = EmptyInputValidation(prompt);
            if (input == "y")
            {
                return input;
            }
            else if (input == "n")
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid option, please try again");
            }
        }
    }
}
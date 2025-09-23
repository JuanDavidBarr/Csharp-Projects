namespace Restaurant.Classes;

public class Restaurant
{
    public static List<Order> orders = new List<Order>();
    public static void AddOrder(int table, List<Dish> dishes)
    {
        double total = 0;
        foreach (Dish dish in dishes)
        {
            total += dish.Price;
        }
        Order newOrder = new Order(table, dishes, total);
        orders.Add(newOrder);
        Console.WriteLine("Order succesfully added");
    }

    public static void ShowTotal(int table)
    {
        double total;
        var result = orders.FirstOrDefault(order => order.Table == table);
        if (result != null)
        {
            total = result.Total;
            Console.WriteLine($"Table {table} total: {total}");
        }
        else
        {
            Console.WriteLine("Table not found");
        }
        
    }

    public static void ShowOrderDetails(int table)
    {
        var result = orders.FirstOrDefault(order => order.Table == table);
        if (result != null)
        {
            Console.WriteLine($"Table {table} details:");
            Console.WriteLine("Dishes: ");
            foreach (Dish dish in result.Dishes)
            {
                Console.WriteLine($"{dish.Name}");
            }

            Console.WriteLine($"Total: {result.Total}");
        }
        else
        {
            Console.WriteLine("Table not found");
        }
    }
}
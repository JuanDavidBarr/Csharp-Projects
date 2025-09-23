namespace Restaurant.Classes;

public class Order
{
    public int Table;
    public List<Dish> Dishes;
    public double Total;

    public Order(int table, List<Dish> dishes, double total)
    {
        Table = table;
        Dishes = dishes;
        Total = total;
    }
}
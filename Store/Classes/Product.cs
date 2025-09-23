namespace Store.Classes;

public class Product
{
    public string Name;
    public double Price;
    public int Stock;

    public Product(string name, double price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
}
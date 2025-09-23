namespace Store.Classes;

public class Store
{
    private List<Product> products = new List<Product>();
    
    public void AddProduct(string name, double price, int stock)
    {
        Product newProduct = new Product(name, price, stock);
        products.Add(newProduct);
        Console.WriteLine("Product successfully added!");
    }

    public void ShowProducts(string productName)
    {
        var result = products.FirstOrDefault(product => product.Name == productName);
        if (result != null)
        {
            Console.WriteLine("Product details: ");
            Console.WriteLine($"Product name: {result.Name}, \nProduct price: {result.Price}, \nIn stock: {result.Stock}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void SellProducts(string productName, int units)
    {
        var result = products.FirstOrDefault(product => product.Name == productName);
        if (result != null)
        {
            if (result.Stock >= units)
            {
                result.Stock -= units;
                Console.WriteLine($"Product successfully sold!");
                Console.WriteLine($"Unites sold: {units}");
                Console.WriteLine($"Remaining stock: {result.Stock}");
            }
            else
            {
                Console.WriteLine("Purchase failed.");
                Console.WriteLine("There is not enough stock.");
            }
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}
using Veterinary.Controllers;

namespace Veterinary.Models;

public class Client : Person
{
    //Primary Key
    public int ClientId { get; set; }
    //Required
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    //One-to-Many relationship with employee
    public ICollection<Pet> Pets { get; set; }

    public Client(string name, string address, string phoneNumber, string email)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
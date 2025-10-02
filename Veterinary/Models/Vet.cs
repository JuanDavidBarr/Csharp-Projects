namespace Veterinary.Models;

public class Vet : Person
{
    //Required
    public int VetId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
   //Relation one to many with visits 
    public ICollection<Visit> Visits { get; set; }
    
    //Constructor
    public Vet(string name, string address, string phoneNumber, string email)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
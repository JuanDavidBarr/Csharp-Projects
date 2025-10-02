namespace Veterinary.Models;

public class Pet
{
    public int PetId { get; set; }
    public string Name { get; set; }
    
    public string Breed { get; set; }
    
    public MedicalRecord Record { get; set; }
    
    public int ClientId { get; set; }
    public Client Client { get; set; }

    public ICollection<Visit> Visits { get; set; }

    public Pet(string name, int clientId, string breed)
    {
        Name = name;
        ClientId = clientId;
        Breed = breed;
    }
}
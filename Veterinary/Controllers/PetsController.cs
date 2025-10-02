using Microsoft.EntityFrameworkCore;
using Veterinary.Models;
using Veterinary.Data;
namespace Veterinary.Controllers;

public class PetsController
{
    public void Register()
    {
        using (var db = new PgDbContext())
        {
            string newPetName = Menu.EmptyInputValidation("Pet name: ");
            string newPetBreed = Menu.EmptyInputValidation("Breed: ");
            int clientId = Menu.IntegerValidation("Client Id: ");
            var client = db.Clients.FirstOrDefault(client => client.ClientId == clientId);
            if (client != null)
            {
                Pet newPet = new Pet(newPetName, clientId, newPetBreed);
                db.Add(newPet);
                db.SaveChanges();
                Console.WriteLine("New pet registered");
            }
            else
            {
                Console.WriteLine("Client not found");
            }
        }
    }

    public void Show()
    {
        using (var db = new PgDbContext())
        {
            var pets = db.Pets.Include(pet => pet.Client).ToList();
            foreach (var pet in pets)
            {
                Console.WriteLine($"Name: {pet.Name}, Breed: {pet.Breed}, Owner: {pet.Client.Name}");
            }
        }
    }

    public void Update()
    {
        using (var db = new PgDbContext())
        {
            int petId = Menu.IntegerValidation("Pet Id: ");
            var petToUpdate = db.Pets.FirstOrDefault(pet => pet.PetId == petId);
            if (petToUpdate != null)
            {
                Console.WriteLine(
                    "Modify only the fields you need to change. Press enter if you want to skip specific field");
                Console.WriteLine("New pet name:");
                string newPetName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPetName))
                {
                    petToUpdate.Name = newPetName;
                }

                Console.WriteLine("New pet breed:");
                string newPetBreed = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPetBreed))
                {
                    petToUpdate.Breed = newPetBreed;
                }
                
                string input = Menu.YnValidation("Do you want to update pet's owner? (y/n): ");
                if (input == "y")
                {
                    int clientId = Menu.IntegerValidation("Client Id: ");
                    petToUpdate.ClientId = clientId;
                }
                db.SaveChanges();
                Console.WriteLine("Pet updated");
                var petToUpdateShow = db.Pets.Include(pet => pet.Client).FirstOrDefault(pet => pet.PetId == petId);
                Console.WriteLine($"Name: {petToUpdate.Name}, Breed: {petToUpdate.Breed}, Owner: {petToUpdate.Client.Name}");
            }
            else
            {
                Console.WriteLine("Pet not found");
            }
        }
    }

    public void Delete()
    {
        using (var db = new PgDbContext())
        {
            int petId = Menu.IntegerValidation("Pet Id: ");
            var petToDelete = db.Pets.FirstOrDefault(pet => pet.PetId == petId);
            if (petToDelete != null)
            {
                db.Pets.Remove(petToDelete);
                db.SaveChanges();
                Console.WriteLine("Pet deleted");
            }
            else
            {
                Console.WriteLine("Pet not found");
            }
        }
    }   
}
using Veterinary.Data;
using Veterinary.Models;
using Microsoft.EntityFrameworkCore;

namespace Veterinary.Controllers;

public class QueriesController
{
    public void clientPets()
    {
        using (var db = new PgDbContext())
        {
            int input = Menu.IntegerValidation("Client id:");
            var client = db.Clients.Include(client => client.Pets).FirstOrDefault(client => client.ClientId == input);
            if (client != null)
            {
                Console.WriteLine($"Client name: {client.Name}");
                foreach (var pet in client.Pets)
                {
                    Console.WriteLine(pet.Name);
                }
            }
        }
    }

    public void VetMostVisits()
    {
        using (var db = new PgDbContext())
        {
            var vetMostVisits = db.Visits.AsEnumerable().GroupBy(visit => visit.VetId).OrderByDescending(visit => visit.Count()).FirstOrDefault();
            if (vetMostVisits != null)
            {
                int id = vetMostVisits.Key;
                var client = db.Vets.FirstOrDefault(vet => vet.VetId == id);
                if (client != null)
                {
                    Console.WriteLine($"Vet most visits: {client.Name}");
                    Console.WriteLine($"Visits count: {vetMostVisits.Count()}");
                }
                else
                {
                    Console.WriteLine("Client not found");
                }
            }
        }
    }
}
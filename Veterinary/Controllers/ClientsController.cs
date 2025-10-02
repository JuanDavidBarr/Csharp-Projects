using Veterinary.Data;
using Veterinary.Models;

namespace Veterinary.Controllers;

public class ClientsController
{
    public void Register()
    {
        using (var db = new PgDbContext())
        {
            string newClientName = Menu.EmptyInputValidation("Client fullname: ");
            string newClientAddress = Menu.EmptyInputValidation("Client address: ");
            string newClientPhoneNumber = Menu.EmptyInputValidation("Client phone number: ");
            string newClientEmail = Menu.EmptyInputValidation("Client email: ");
            Client newClient = new Client(newClientName, newClientAddress, newClientPhoneNumber, newClientEmail);
            db.Add(newClient);
            db.SaveChanges();
            Console.WriteLine("New client registered");
        }
    }

    public void Show()
    {
        using (var db = new PgDbContext())
        {
            var clients = db.Clients.ToList();
            foreach (var client in clients)
            {
                Console.WriteLine($"Name: {client.Name}, Address: {client.Address}, Phone: {client.PhoneNumber},  Email: {client.Email}");
            }
        }
    }

    public void Update()
    {
        using (var db = new PgDbContext())
        {
            string clientEmail = Menu.EmptyInputValidation("Client Email: ");
            var clientToUpdate = db.Clients.FirstOrDefault(client => client.Email == clientEmail);
            if (clientToUpdate != null)
            {
                Console.WriteLine("Modify only the fields you need to change. Press enter if you want to skip specific field");
                Console.WriteLine("New client name:");
                string newClientName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newClientName))
                {
                    clientToUpdate.Name = newClientName;
                }
                Console.WriteLine("New client address:");
                string newClientAddress = Console.ReadLine();
                if (!string.IsNullOrEmpty(newClientAddress))
                {
                    clientToUpdate.Address = newClientAddress;
                }
                Console.WriteLine("New client phone:");
                string newClientPhone = Console.ReadLine();
                if (!string.IsNullOrEmpty(newClientPhone))
                {
                    clientToUpdate.PhoneNumber = newClientPhone;
                }
                Console.WriteLine("New client email:");
                string newClientEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(newClientEmail))
                {
                    clientToUpdate.Email = newClientEmail;
                }
                db.SaveChanges();
                Console.WriteLine("Client updated");
                Console.WriteLine($"Name: {clientToUpdate.Name}, Address: {clientToUpdate.Address}, Phone: {clientToUpdate.PhoneNumber},  Email: {clientToUpdate.Email}");
            }
            else
            {
                Console.WriteLine("Client not found");
            }
        }
    }

    public void Delete()
    {
        using (var db = new PgDbContext())
        {
            string clientEmail = Menu.EmptyInputValidation("Client Email: ");
            var clientToDelete = db.Clients.FirstOrDefault(client => client.Email == clientEmail);
            if (clientToDelete != null)
            {
                db.Clients.Remove(clientToDelete);
                db.SaveChanges();
                Console.WriteLine("Client deleted");
            }
            else
            {
                Console.WriteLine("Client not found");
            }
        }
    }
}
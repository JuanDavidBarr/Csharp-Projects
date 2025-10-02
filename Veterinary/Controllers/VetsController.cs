namespace Veterinary.Controllers;
using Veterinary.Data;
using Veterinary.Models;

public class VetsController
{
    public void Register()
    {
        using (var db = new PgDbContext())
        {
            string newVetName = Menu.EmptyInputValidation("Vet fullname: ");
            string newVetAddress = Menu.EmptyInputValidation("Vet address: ");
            string newVetPhoneNumber = Menu.EmptyInputValidation("Vet phone number: ");
            string newVetEmail = Menu.EmptyInputValidation("Vet email: ");
            Vet newVet = new Vet(newVetName, newVetAddress, newVetPhoneNumber, newVetEmail);
            db.Add(newVet);
            db.SaveChanges();
            Console.WriteLine("New vet registered");
        }
    }

    public void Show()
    {
        using (var db = new PgDbContext())
        {
            var vets = db.Vets.ToList();
            foreach (var vet in vets)
            {
                Console.WriteLine($"Name: {vet.Name}, Address: {vet.Address}, Phone: {vet.PhoneNumber},  Email: {vet.Email}");
            }
        }
    }

    public void Update()
    {
        using (var db = new PgDbContext())
        {
            string vetEmail = Menu.EmptyInputValidation("Vet Email: ");
            var vetToUpdate = db.Vets.FirstOrDefault(vet => vet.Email == vetEmail);
            if (vetToUpdate != null)
            {
                Console.WriteLine("Modify only the fields you need to change. Press enter if you want to skip specific field");
                Console.WriteLine("New vet name:");
                string newVetName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newVetName))
                {
                    vetToUpdate.Name = newVetName;
                }
                Console.WriteLine("New Vet address:");
                string newVetAddress = Console.ReadLine();
                if (!string.IsNullOrEmpty(newVetAddress))
                {
                    vetToUpdate.Address = newVetAddress;
                }
                Console.WriteLine("New Vet phone:");
                string newVetPhone = Console.ReadLine();
                if (!string.IsNullOrEmpty(newVetPhone))
                {
                    vetToUpdate.PhoneNumber = newVetPhone;
                }
                Console.WriteLine("New Vet email:");
                string newVetEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(newVetEmail))
                {
                    vetToUpdate.Email = newVetEmail;
                }
                db.SaveChanges();
                Console.WriteLine("Vet updated");
                Console.WriteLine($"Name: {vetToUpdate.Name}, Address: {vetToUpdate.Address}, Phone: {vetToUpdate.PhoneNumber},  Email: {vetToUpdate.Email}");
            }
            else
            {
                Console.WriteLine("Vet not found");
            }
        }
    }

    public void Delete()
    {
        using (var db = new PgDbContext())
        {
            string vetEmail = Menu.EmptyInputValidation("Client Email: ");
            var vetToDelete = db.Vets.FirstOrDefault(vet => vet.Email == vetEmail);
            if (vetToDelete != null)
            {
                db.Vets.Remove(vetToDelete);
                db.SaveChanges();
                Console.WriteLine("Vet deleted");
            }
            else
            {
                Console.WriteLine("Vet not found");
            }
        }
    }
}
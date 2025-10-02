namespace Veterinary.Controllers;
using Microsoft.EntityFrameworkCore;
using Veterinary.Data;
using Veterinary.Models;

public class VisitsController
{
    public void Register()
    {
        using (var db = new PgDbContext())
        {
            DateTime newVisitDate = Menu.ValidDateInput("Date: ");
            string newVisitReason= Menu.EmptyInputValidation("Visit reason: ");
            int newVisitVet = Menu.IntegerValidation("Vet Id: ");
            int newVisitPet = Menu.IntegerValidation("Pet Id: ");
            Visit newVisit = new Visit(newVisitDate, newVisitReason, newVisitVet, newVisitPet);
            db.Add(newVisit);
            db.SaveChanges();
            Console.WriteLine("New visit registered");
        }
    }

    public void Show()
    {
        using (var db = new PgDbContext())
        {
            var visits = db.Visits.Include( visit => visit.Pet).Include(visit => visit.Vet).ToList() ;
            foreach (var visit in visits)
            {
                Console.WriteLine($"Date: {visit.Date}, Reason: {visit.Reason}, Vet: {visit.Vet.Name},  Email: {visit.Pet.Name} {visit.VisitId}");
            }
        }
    }

    public void Update()
    {
        using (var db = new PgDbContext())
        {
            int vistId = Menu.IntegerValidation("Visit Id: ");
            var visitToUpdate = db.Visits.FirstOrDefault(visit => visit.VisitId == vistId);
            if (visitToUpdate != null)
            {
                Console.WriteLine("Modify only the fields you need to change. Press enter if you want to skip specific field");
                Console.WriteLine("New visit date:");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    if (DateTime.TryParse(input, out DateTime newDate))
                    {
                        visitToUpdate.Date = newDate;
                    }
                }
                Console.WriteLine("New visit reason:");
                string newReason = Console.ReadLine();
                if (!string.IsNullOrEmpty(newReason))
                {
                    visitToUpdate.Reason = newReason;
                }
                Console.WriteLine("New visit vet:");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    if (int.TryParse(input, out int newVet))
                    {
                        visitToUpdate.VetId = newVet;
                    }
                }
                Console.WriteLine("New visit pet:");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    if (int.TryParse(input, out int newPet))
                    {
                        visitToUpdate.PetId = newPet;
                    }
                }
                db.SaveChanges();
                Console.WriteLine("Visit updated");
                Console.WriteLine($"Date: {visitToUpdate.Date}, Reason: {visitToUpdate.Reason}, Vet: {visitToUpdate.Vet.Name},  Email: {visitToUpdate.Pet.Name}");
            }
            else
            {
                Console.WriteLine("Visit not found");
            }
        }
    }

    public void Delete()
    {
        using (var db = new PgDbContext())
        {
            int visitId = Menu.IntegerValidation("Visit Id: ");
            var visitToDelete = db.Visits.FirstOrDefault(visit => visit.VisitId == visitId);
            if (visitToDelete != null)
            {
                db.Visits.Remove(visitToDelete);
                db.SaveChanges();
                Console.WriteLine("Visit deleted");
            }
            else
            {
                Console.WriteLine("Visit not found");
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace Veterinary.Controllers;
using Veterinary.Data;
using Veterinary.Models;

public class MedicalRecordsControllers
{
    
    public void CreateMedicalRecord()
    {
        using (var db = new PgDbContext())
        {
            int petId = Menu.IntegerValidation("Pet Id: ");
            string description = Menu.EmptyInputValidation("Description:");
            MedicalRecord newMedicalRecord = new MedicalRecord(description, petId);
            db.MedicalRecords.Add(newMedicalRecord);
            Console.WriteLine("Medical record created");
            db.SaveChanges();
        }
    }
    public void EditMedicalRecord()
    {
        using (var db = new PgDbContext())
        {
            int petId = Menu.IntegerValidation("Pet Id: ");
            var pet = db.Pets.FirstOrDefault(pet => pet.PetId == petId);
            if (pet != null)
            {
                string newDescription = Menu.EmptyInputValidation("Medical record description: ");
                MedicalRecord medicalRecord = new MedicalRecord(newDescription, petId);
                Console.WriteLine("Description updated");
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Pet not found");
            }
        }
    }
    
    public void ShowMedicalRecord()
    {
        using (var db = new PgDbContext())
        {
            int petId = Menu.IntegerValidation("Pet Id: ");
            var record = db.MedicalRecords.Include(record => record.Pet).FirstOrDefault(record => record.PetId == petId);
            if (record != null)
            {
                if (!string.IsNullOrEmpty(record.Description))
                {
                    Console.WriteLine($"{record.Pet.Name}");
                    Console.WriteLine($"{record.Description}");
                }
                else
                {
                    Console.WriteLine("Record description is empty");
                }
            }
            else
            {
                Console.WriteLine("Record does not exist");
            }
        }
    }
}
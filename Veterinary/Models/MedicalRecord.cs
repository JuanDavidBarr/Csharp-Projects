namespace Veterinary.Models;

public class MedicalRecord
{
    public int RecordId { get; set; }
    public string Description { get; set; }

    public int PetId { get; set; }
    public Pet Pet { get; set; }

    public MedicalRecord(string description, int petId)
    {
        Description = description;
        PetId = petId;
    }
}
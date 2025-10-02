namespace Veterinary.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Visit
{
    public int VisitId { get; set; }
    
    [Column(TypeName = "timestamp without time zone")]
    public DateTime Date { get; set; }
    public string Reason { get; set; }

    public int VetId { get; set; }
    public Vet Vet { get; set; }
    
    public int PetId { get; set; }
    public Pet Pet { get; set; }

    public Visit(DateTime date, string reason, int vetId, int petId)
    {
        Date = date;
        Reason = reason;
        VetId = vetId;
        PetId = petId;
    }
}
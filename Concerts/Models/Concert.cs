using System;

namespace riwiMusic.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public int TotalCapacity { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id} | Concierto: {Name} | Ciudad: {City} | Fecha: {Date.ToShortDateString()}");
        }
    }
}
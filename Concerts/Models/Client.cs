
using System;


namespace riwiMusic.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // --- AÑADE ESTE CONSTRUCTOR ---
        public Client(int id, string cedula, string name, string email)
        {
            Id = id;
            Cedula = cedula;
            Name = name;
            Email = email;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id} | Cédula: {Cedula} | Nombre: {Name} | Email: {Email}");
        }
    }
}
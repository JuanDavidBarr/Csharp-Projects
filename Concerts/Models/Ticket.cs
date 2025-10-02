using System;

namespace riwiMusic.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public int ClientId { get; set; }
        public DateTime PurchaseDate { get; set; }

        
        public Ticket(int id, int concertId, int clientId)
        {
            Id = id;
            ConcertId = concertId;
            ClientId = clientId;
            // Ponemos la fecha de compra cuando se creo el tiquete
            PurchaseDate = DateTime.Now; 
        }
    }
}
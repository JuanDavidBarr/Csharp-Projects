using riwiMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace riwiMusic.Services
{
    public class RiwiMusicSystem
    {
        // Vamos a usar listas en memoria para almacenar los datos
        private List<Concert> concerts = new List<Concert>();
        private List<Client> clients = new List<Client>();
        private List<Ticket> tickets = new List<Ticket>();
        
        // Creamos contadores para los IDs
        private int nextConcertId = 1;
        private int nextClientId = 1;
        private int nextTicketId = 1;

        // cremos los metodos para cada módulo

        public void ManageConcerts()
        {
            bool exitApp = false;
            while (!exitApp)
            {
                //Console.Clear();
                Console.WriteLine("\n===== Gestión de Conciertos =====");
                Console.WriteLine("1. Listar conciertos");
                Console.WriteLine("2. Agregar concierto");
                Console.WriteLine("3. Editar concierto");
                Console.WriteLine("4. Eliminar concierto");
                Console.WriteLine("5. Ver detalles de concierto");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        ListConcerts();
                        break;
                    case "2":
                        AddConcert();
                        break;
                    case "3":
                        UpdateConcert();
                        break;
                    case "4":
                        DeleteConcert();
                        break;
                    case "5":
                        ViewConcertDetails();
                        break;
                    case "6":
                        exitApp = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                
                if (!exitApp)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }
        //List concerts
        public void ListConcerts()
        {
            if (concerts.Any())
            {
                Console.WriteLine("\n--- Lista de conciertos ---");
                foreach (var concert in concerts)
                {
                    concert.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("No hay conciertos registrados.");
            }
        }
        //Add concerts
        public void AddConcert()
        {
            //Console.Clear();
            Console.WriteLine("\n===== Agregar Concierto =====");
            string name = EmptyInput("Nombre: ");
            string city = EmptyInput("Ciudad: ");
            DateTime date = ValidDateInput("Fecha (YYYY-MM-DD): ");
            int totalCapacity = TotalCapacityInput("Capacidad: ");
            
            Concert newConcert = new Concert();
            newConcert.Id = nextConcertId;
            newConcert.Name = name;
            newConcert.Date = date;
            newConcert.City = city;
            newConcert.TotalCapacity = totalCapacity;
            
            concerts.Add(newConcert);
            nextConcertId++;
            Console.WriteLine("Concierto agregado exitosamente.");
        }
        //Update concert
        public void UpdateConcert()
        {
            ListConcerts();
            if (!concerts.Any()) return;

            Console.Write("Ingrese el ID del concierto a editar: ");
            if (int.TryParse(Console.ReadLine(), out int idToUpdate))
            {
                var concertToUpdate = concerts.FirstOrDefault(concert => concert.Id == idToUpdate);
                if (concertToUpdate != null)
                {
                    Console.WriteLine("Ingrese la nueva información (deje vacío para mantener el valor actual)");
                    
                    Console.Write($"Nuevo nombre ({concertToUpdate.Name}): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        concertToUpdate.Name = newName;
                    }
                    
                    Console.Write($"Nueva ciudad ({concertToUpdate.City}): ");
                    string newCity =  Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCity))
                    {
                        concertToUpdate.City = newCity;
                    }
                    
                    Console.WriteLine($"Nueva fecha ({concertToUpdate.Date:yyyy-MM-dd}): ");
                    concertToUpdate.Date = ValidDateInput("Ingrese nueva fecha o deje vacío:", true, concertToUpdate.Date);
                    
                    Console.WriteLine($"Nueva capacidad total ({concertToUpdate.TotalCapacity}): ");
                    concertToUpdate.TotalCapacity = TotalCapacityInput("Ingrese nueva capacidad o deje vacío:", true, concertToUpdate.TotalCapacity);

                    Console.WriteLine("Concierto editado exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró un concierto con ese ID.");
                }
            }
            else
            {
                Console.WriteLine("Formato de ID inválido.");
            }
        }
        //Delete concert
        public void DeleteConcert()
        {
            ListConcerts();
            if (!concerts.Any()) return;

            Console.Write("Ingrese el ID del concierto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idToDelete))
            {
                var concertToDelete = concerts.FirstOrDefault(concert => concert.Id == idToDelete);
                if (concertToDelete != null)
                {
                    concerts.Remove(concertToDelete);
                    Console.WriteLine("Concierto eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró un concierto con ese ID.");
                }
            }
            else
            {
                Console.WriteLine("Formato de ID inválido.");
            }
        }
        //View concert details
        public void ViewConcertDetails()
        {
            ListConcerts();
            if (!concerts.Any()) return;
            
            Console.Write("Ingrese el ID del concierto para ver detalles: ");
            if (int.TryParse(Console.ReadLine(), out int idToShow))
            {
                var concertToShow = concerts.FirstOrDefault(concert => concert.Id == idToShow);
                if (concertToShow != null)
                {
                    concertToShow.ShowInfo();
                }
                else
                {
                    Console.WriteLine("No se encontró un concierto con ese ID.");
                }
            }
            else
            {
                Console.WriteLine("Formato de ID inválido.");
            }
        }
        
        //Input methods
        public string EmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Value required. Try again.");
                }
            } while (string.IsNullOrEmpty(input));
            return input;
        }
        public DateTime ValidDateInput(string prompt, bool allowEmpty = false, DateTime defaultValue = default)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                if (allowEmpty && string.IsNullOrEmpty(input))
                {
                    return defaultValue;
                }
                if (DateTime.TryParse(input, out DateTime date))
                {
                    return date;
                }
                Console.WriteLine("Invalid date format. Try again.");
            }
        }

        public int TotalCapacityInput(string prompt, bool allowEmpty = false, int defaultValue = default)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine()?.Trim();
                if (allowEmpty && string.IsNullOrEmpty(input))
                {
                    return defaultValue;
                }
                if (int.TryParse(input, out int capacity))
                {
                    return capacity;
                }
                Console.WriteLine("Invalid number. Try again.");
            }
        }

        public void ManageClients()
        {
            bool exitModule = false;
            while (!exitModule)
            {
                Console.Clear();
                Console.WriteLine("\n===== Gestión de Clientes =====");
                Console.WriteLine("1. Registrar nuevo cliente");
                Console.WriteLine("2. Listar todos los clientes");
                Console.WriteLine("3. Editar un cliente");
                Console.WriteLine("4. Eliminar un cliente");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        Console.WriteLine("\n--- Registrar Nuevo Cliente ---");
                        string clientName = EmptyInput("Nombre del cliente: ");
                        
                        string clientCedula;
                        while (true)
                        {
                            Console.Write("Cédula del cliente: ");
                            clientCedula = Console.ReadLine();
                            if (string.IsNullOrEmpty(clientCedula))
                            {
                                Console.WriteLine("Error: La cédula no puede estar vacía.");
                                continue;
                            }
                            if (clients.Any(c => c.Cedula == clientCedula))
                            {
                                Console.WriteLine("Error: Ya existe un cliente con esa cédula.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        string clientEmail;
                        while (true)
                        {
                            Console.Write("Email del cliente: ");
                            clientEmail = Console.ReadLine();
                            if (!string.IsNullOrEmpty(clientEmail) && clientEmail.Contains("@"))
                            {
                                break; 
                            }
                            Console.WriteLine("Error: El email no es válido o está vacío.");
                        }
                        
                        Client newClient = new Client(nextClientId, clientCedula, clientName, clientEmail);
                        clients.Add(newClient);
                        nextClientId++;

                        Console.WriteLine("¡Cliente registrado con éxito!");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Lista de Clientes Registrados ---");
                        if (!clients.Any())
                        {
                            Console.WriteLine("No hay clientes registrados.");
                        }
                        else
                        {
                            foreach (Client client in clients)
                            {
                                client.ShowInfo();
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- Editar Información del Cliente ---");
                        if (!clients.Any())
                        {
                            Console.WriteLine("No hay clientes para editar.");
                            break;
                        }
                        
                        Console.Write("Ingrese la Cédula del cliente que desea editar: ");
                        string cedulaToEdit = Console.ReadLine();

                        Client clientToEdit = clients.FirstOrDefault(c => c.Cedula == cedulaToEdit);

                        if (clientToEdit == null)
                        {
                            Console.WriteLine("Error: No se encontró un cliente con esa cédula.");
                        }
                        else
                        {
                            Console.WriteLine($"Editando cliente: {clientToEdit.Name}");
                            Console.WriteLine("Deje el campo vacío y presione Enter para no cambiar el valor.");

                            Console.Write($"Nuevo nombre ({clientToEdit.Name}): ");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newName))
                            {
                                clientToEdit.Name = newName;
                            }

                            Console.Write($"Nuevo email ({clientToEdit.Email}): ");
                            string newEmail = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newEmail))
                            {
                                if (newEmail.Contains("@"))
                                {
                                    clientToEdit.Email = newEmail;
                                }
                                else
                                {
                                   Console.WriteLine("Formato de email no válido. No se actualizó.");
                                }
                            }
                            
                            Console.WriteLine("¡Cliente actualizado con éxito!");
                        }
                        break;
                        
                    case "4":
                        Console.WriteLine("\n--- Eliminar Cliente ---");
                        if (!clients.Any())
                        {
                            Console.WriteLine("No hay clientes para eliminar.");
                            break;
                        }

                        Console.Write("Ingrese la Cédula del cliente que desea eliminar: ");
                        string cedulaToDelete = Console.ReadLine();

                        Client clientToDelete = clients.FirstOrDefault(c => c.Cedula == cedulaToDelete);

                        if (clientToDelete == null)
                        {
                            Console.WriteLine("Error: No se encontró un cliente con esa cédula.");
                        }
                        else
                        {
                            Console.WriteLine($"Cliente a eliminar: ID: {clientToDelete.Id}, Nombre: {clientToDelete.Name}");
                            Console.Write("¿Está seguro de que desea eliminarlo? (S/N): ");
                            string confirmation = Console.ReadLine();

                            if (confirmation.ToUpper() == "S")
                            {
                                clients.Remove(clientToDelete);
                                Console.WriteLine("Cliente eliminado con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Operación cancelada.");
                            }
                        }
                        break;

                    case "5":
                        exitModule = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
                
                if (!exitModule)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }

        public void ManageTickets()
        {
            bool exitModule = false;
            while (!exitModule)
            {
                Console.Clear();
                Console.WriteLine("\n===== Gestión de Tiquetes =====");
                Console.WriteLine("1. Registrar compra de tiquete");
                Console.WriteLine("2. Listar tiquetes vendidos");
                Console.WriteLine("3. Editar compra (cambiar cliente)");
                Console.WriteLine("4. Eliminar compra");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        Console.WriteLine("\n--- Registrar Nueva Compra de Tiquete ---");
                        if (!concerts.Any() || !clients.Any())
                        {
                            Console.WriteLine("Error: Debe registrar al menos un concierto y un cliente antes de vender un tiquete.");
                            break;
                        }
                        ListConcerts();
                        Console.Write("Ingrese el ID del concierto: ");
                        int concertId;
                        if (!int.TryParse(Console.ReadLine(), out concertId))
                        {
                            Console.WriteLine("ID de concierto inválido.");
                            break;
                        }
                        Concert selectedConcert = concerts.FirstOrDefault(c => c.Id == concertId);
                        if (selectedConcert == null)
                        {
                            Console.WriteLine("Error: No se encontró un concierto con ese ID.");
                            break;
                        }
                        int ticketsSold = tickets.Count(t => t.ConcertId == concertId);
                        if (ticketsSold >= selectedConcert.TotalCapacity)
                        {
                            Console.WriteLine("Error: No hay más cupos disponibles para este concierto.");
                            break;
                        }
                        Console.WriteLine("\nLista de clientes:");
                        foreach (var client in clients)
                        {
                            Console.WriteLine($"ID: {client.Id} | Nombre: {client.Name} | Cédula: {client.Cedula}");
                        }
                        Console.Write("Ingrese el ID del cliente que realiza la compra: ");
                        int clientId;
                        if (!int.TryParse(Console.ReadLine(), out clientId))
                        {
                            Console.WriteLine("ID de cliente inválido.");
                            break;
                        }
                        Client selectedClient = clients.FirstOrDefault(c => c.Id == clientId);
                        if (selectedClient == null)
                        {
                            Console.WriteLine("Error: No se encontró un cliente con ese ID.");
                            break;
                        }
                        Ticket newTicket = new Ticket(nextTicketId, concertId, clientId);
                        tickets.Add(newTicket);
                        nextTicketId++;
                        Console.WriteLine("\n¡Compra registrada con éxito!");
                        Console.WriteLine($"Tiquete ID: {newTicket.Id} para el concierto '{selectedConcert.Name}' a nombre de '{selectedClient.Name}'.");
                        break;
                    case "2":
                        Console.WriteLine("\n--- Lista de Tiquetes Vendidos ---");
                        if (!tickets.Any())
                        {
                            Console.WriteLine("No se han vendido tiquetes.");
                        }
                        else
                        {
                            foreach (var ticket in tickets)
                            {
                                string concertName = concerts.FirstOrDefault(c => c.Id == ticket.ConcertId)?.Name ?? "Desconocido";
                                string clientName = clients.FirstOrDefault(c => c.Id == ticket.ClientId)?.Name ?? "Desconocido";
                                Console.WriteLine($"ID Tiquete: {ticket.Id} | Concierto: {concertName} | Cliente: {clientName} | Fecha Compra: {ticket.PurchaseDate:yyyy-MM-dd}");
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("\n--- Editar Cliente de un Tiquete ---");
                        if (!tickets.Any())
                        {
                            Console.WriteLine("No hay tiquetes para editar.");
                            break;
                        }
                        Console.Write("Ingrese el ID del tiquete que desea modificar: ");
                        int ticketIdToEdit;
                        if (!int.TryParse(Console.ReadLine(), out ticketIdToEdit))
                        {
                            Console.WriteLine("ID de tiquete inválido.");
                            break;
                        }
                        Ticket ticketToEdit = tickets.FirstOrDefault(t => t.Id == ticketIdToEdit);
                        if (ticketToEdit == null)
                        {
                            Console.WriteLine("Error: No se encontró un tiquete con ese ID.");
                        }
                        else
                        {
                            Console.WriteLine($"Tiquete actual: ID {ticketToEdit.Id} | Cliente actual: {clients.FirstOrDefault(c => c.Id == ticketToEdit.ClientId)?.Name ?? "Desconocido"}");
                            Console.WriteLine("Lista de clientes disponibles:");
                            foreach (var client in clients)
                            {
                                Console.WriteLine($"ID: {client.Id} | Nombre: {client.Name} | Cédula: {client.Cedula}");
                            }
                            Console.Write("Ingrese el nuevo ID del cliente para este tiquete: ");
                            int newClientId;
                            if (!int.TryParse(Console.ReadLine(), out newClientId))
                            {
                                Console.WriteLine("ID de cliente inválido.");
                                break;
                            }
                            Client newClient = clients.FirstOrDefault(c => c.Id == newClientId);
                            if (newClient == null)
                            {
                                Console.WriteLine("Error: El nuevo ID de cliente no existe.");
                            }
                            else
                            {
                                ticketToEdit.ClientId = newClientId;
                                Console.WriteLine("¡Cliente del tiquete actualizado con éxito! El ID del tiquete permanece igual.");
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("\n--- Eliminar Compra de Tiquete ---");
                        if (!tickets.Any())
                        {
                            Console.WriteLine("No hay tiquetes para eliminar.");
                            break;
                        }
                        Console.Write("Ingrese el ID del tiquete que desea eliminar: ");
                        int ticketIdToDelete;
                        if (!int.TryParse(Console.ReadLine(), out ticketIdToDelete))
                        {
                            Console.WriteLine("ID de tiquete inválido.");
                            break;
                        }
                        Ticket ticketToDelete = tickets.FirstOrDefault(t => t.Id == ticketIdToDelete);
                        if (ticketToDelete == null)
                        {
                            Console.WriteLine("Error: No se encontró un tiquete con ese ID.");
                        }
                        else
                        {
                            Console.WriteLine($"Tiquete a eliminar: ID {ticketToDelete.Id}");
                            Console.Write("¿Está seguro? (S/N): ");
                            string confirmation = Console.ReadLine();
                            if (confirmation.ToUpper() == "S")
                            {
                                tickets.Remove(ticketToDelete);
                                Console.WriteLine("Compra eliminada con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Operación cancelada.");
                            }
                        }
                        break;
                    case "5":
                        exitModule = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (!exitModule)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }
        
        public void ShowPurchaseHistory()
        {
            Console.Clear();
            Console.WriteLine("\n===== Historial de Compras por Cliente =====");

            if (!clients.Any())
            {
                Console.WriteLine("No hay clientes registrados para mostrar su historial.");
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese la Cédula del cliente para ver su historial: ");
            string cedulaToSearch = Console.ReadLine();

            Client selectedClient = clients.FirstOrDefault(c => c.Cedula == cedulaToSearch);

            if (selectedClient == null)
            {
                Console.WriteLine("Error: No se encontró un cliente con esa cédula.");
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            List<Ticket> clientTickets = tickets.Where(t => t.ClientId == selectedClient.Id).ToList();

            Console.WriteLine($"\n--- Historial de Compras de: {selectedClient.Name} ---");

            if (!clientTickets.Any())
            {
                Console.WriteLine("Este cliente no ha realizado ninguna compra.");
            }
            else
            {
                foreach (var ticket in clientTickets)
                {
                    string concertName = concerts.FirstOrDefault(c => c.Id == ticket.ConcertId)?.Name ?? "Concierto no encontrado";
                    Console.WriteLine($"- Tiquete ID: {ticket.Id} | Concierto: {concertName} | Fecha de Compra: {ticket.PurchaseDate.ToShortDateString()}");
                }
            }
            
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
        public void RunAdvancedQueries()
        {
            bool exitModule = false;
            while (!exitModule)
            {
                Console.Clear();
                Console.WriteLine("\n===== Consultas Avanzadas (LINQ) =====");
                Console.WriteLine("1. Consultar conciertos por ciudad");
                Console.WriteLine("2. Consultar conciertos por rango de fechas");
                Console.WriteLine("3. Consultar cliente con más compras");
                Console.WriteLine("4. Consultar concierto con más tiquetes vendidos");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        Console.Write("Ingrese la ciudad a buscar: ");
                        string cityToSearch = Console.ReadLine();
                        var concertsInCity = concerts.Where(c => c.City.Equals(cityToSearch, StringComparison.OrdinalIgnoreCase)).ToList();

                        Console.WriteLine($"\n--- Conciertos en: {cityToSearch} ---");
                        if (!concertsInCity.Any())
                        {
                            Console.WriteLine("No se encontraron conciertos en esa ciudad.");
                        }
                        else
                        {
                            foreach (var concert in concertsInCity)
                            {
                                concert.ShowInfo();
                            }
                        }
                        break;

                    case "2":
                        try
                        {
                            DateTime startDate = ValidDateInput("Ingrese la fecha de inicio (formato AÑO-MES-DÍA): ");
                            DateTime endDate = ValidDateInput("Ingrese la fecha de fin (formato AÑO-MES-DÍA): ");

                            var concertsInDateRange = concerts.Where(c => c.Date.Date >= startDate.Date && c.Date.Date <= endDate.Date).ToList();

                            Console.WriteLine($"\n--- Conciertos entre {startDate.ToShortDateString()} y {endDate.ToShortDateString()} ---");
                            if (!concertsInDateRange.Any())
                            {
                                Console.WriteLine("No se encontraron conciertos en ese rango de fechas.");
                            }
                            else
                            {
                                foreach (var concert in concertsInDateRange)
                                {
                                    concert.ShowInfo();
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: Formato de fecha no válido.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- Cliente con Más Compras ---");
                        if (!tickets.Any())
                        {
                            Console.WriteLine("Aún no se han realizado compras.");
                            break;
                        }

                        var clientGroup = tickets
                            .GroupBy(ticket => ticket.ClientId)
                            .OrderByDescending(group => group.Count())
                            .FirstOrDefault();
                        
                        if (clientGroup != null)
                        {
                             Client topClient = clients.Find(c => c.Id == clientGroup.Key);
                             if(topClient != null)
                             {
                                Console.WriteLine($"El cliente con más compras es: {topClient.Name} con {clientGroup.Count()} tiquetes comprados.");
                             }
                        }
                        break;
                        
                    case "4":
                        Console.WriteLine("\n--- Concierto Más Popular ---");
                        if (!tickets.Any())
                        {
                            Console.WriteLine("Aún no se han vendido tiquetes.");
                            break;
                        }
                        
                        var concertGroup = tickets
                            .GroupBy(ticket => ticket.ConcertId)
                            .OrderByDescending(group => group.Count())
                            .FirstOrDefault();

                        if (concertGroup != null)
                        {
                            Concert topConcert = concerts.Find(c => c.Id == concertGroup.Key);
                            if (topConcert != null)
                            {
                                Console.WriteLine($"El concierto con más tiquetes vendidos es: '{topConcert.Name}' con {concertGroup.Count()} tiquetes.");
                            }
                        }
                        break;

                    case "5":
                        exitModule = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (!exitModule)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}
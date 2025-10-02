using riwiMusic.Services;
using System;

RiwiMusicSystem system = new RiwiMusicSystem();
bool exitApp = false;

Console.WriteLine("¡Bienvenido a RiwiMusic!");

while (!exitApp)
{
    Console.Clear();
    Console.WriteLine("===== MENÚ PRINCIPAL =====");
    Console.WriteLine("1. Gestión de Conciertos");
    Console.WriteLine("2. Gestión de Clientes");
    Console.WriteLine("3. Gestión de Tiquetes");
    Console.WriteLine("4. Historial de Compras");
    Console.WriteLine("5. Consultas Avanzadas (LINQ)");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");
    
    string userOption = Console.ReadLine();
    switch (userOption)
    {
        case "1":
            system.ManageConcerts();
            break;
        case "2":
            system.ManageClients();
            break;
        case "3":
            system.ManageTickets();
            break;
        case "4":
            system.ShowPurchaseHistory();
            break;
        case "5":
            system.RunAdvancedQueries();
            break;
        case "6":
            exitApp = true;
            Console.WriteLine("Gracias por usar RiwiMusic. ¡Hasta pronto!");
            break;
        default:
            Console.WriteLine("Opción no válida. Presione Enter para continuar.");
            Console.ReadLine();
            break;
    }
}
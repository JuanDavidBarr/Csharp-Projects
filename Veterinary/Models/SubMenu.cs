using Veterinary.Controllers;

namespace Veterinary.Models;

abstract class SubMenu
{
    public static void EntityMenu(string entity)
    {
        ClientsController clientsController = new ClientsController();
        PetsController petsController = new PetsController();
        VetsController vetsController = new VetsController();
        VisitsController visitsController = new VisitsController();
        MedicalRecordsControllers medicalRecordController = new MedicalRecordsControllers();
        bool  leaveMenu = false;
        bool checkRecords = false;
        while (!leaveMenu)
        {
            Console.WriteLine($"{entity.ToUpper()}S Menu. These are the {entity}s menu options: ");
            Console.WriteLine($"1. Register {entity}");
            Console.WriteLine($"2. Show {entity}s");
            Console.WriteLine($"3. Update {entity} information");
            Console.WriteLine($"4. Delete {entity}");
            Console.WriteLine("5. Leave this menu");
            string userOption = Menu.EmptyInputValidation("Enter option: ");
            switch (userOption)
            {
                case "1":
                    switch (entity)
                    {
                        case "client":
                            clientsController.Register();
                            break;
                        case "pet":
                            petsController.Register();
                            break;
                        case "vet":
                            vetsController.Register();
                            break;
                        case "visit":
                            visitsController.Register();
                            break;
                    }
                    break;
                case "2":
                    switch (entity)
                    {
                        case "client":
                            clientsController.Show();
                            break;
                        case "pet":
                            petsController.Show();
                            break;
                        case "vet":
                           vetsController.Show();
                            break;
                        case "visit":
                            visitsController.Show();
                            break;
                    }
                    break;
                case "3":
                    switch (entity)
                    {
                        case "client":
                            clientsController.Update();
                            break;
                        case "pet":
                            petsController.Update();
                            break;
                        case "vet":
                            vetsController.Update();
                            break;
                        case "visit":
                            visitsController.Update();
                            break;
                    }
                    break;
                case "4":
                    switch (entity)
                    {
                        case "client":
                            clientsController.Delete();
                            break;
                        case "pet":
                            petsController.Delete();
                            break;
                        case "vet":
                            vetsController.Delete();
                            break;
                        case "visit":
                            visitsController.Delete();
                            break;
                    }
                    break;
                case "5":
                    Console.WriteLine("Leaving this menu...");
                    leaveMenu = true;
                    break;
                default:
                    Console.WriteLine("Please, enter valid option: ");
                    break;
            }
        }
    }
}
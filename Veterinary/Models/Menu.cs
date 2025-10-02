using Veterinary.Controllers;

namespace Veterinary.Models;

public class Menu
{
    public static void ShowMenu()
    {
        bool leaveMenu = false;
        string subMenu = "";
        MedicalRecordsControllers medicalRecordsController = new MedicalRecordsControllers();
        QueriesController queriesController = new QueriesController();
        while (!leaveMenu)
        {
            Console.WriteLine("Welcome to Awesome Veterinary system manager! This are the menu options: ");
            Console.WriteLine("1. Manage clients");
            Console.WriteLine("2. Manage pets");
            Console.WriteLine("3. Manage vets");
            Console.WriteLine("4. Manage visits");
            Console.WriteLine("5. Medical records");
            Console.WriteLine("6. Queries");
            Console.WriteLine("7. Leave this menu");
            string userOption = EmptyInputValidation("Enter option: ");
            switch (userOption)
            {
                case "1":
                    subMenu = "client";
                    SubMenu.EntityMenu(subMenu);
                    break;
                case "2":
                    subMenu = "pet";
                    SubMenu.EntityMenu(subMenu);
                    break;
                case "3":
                    subMenu = "vet";
                    SubMenu.EntityMenu(subMenu);
                    break;
                case "4":
                    subMenu = "visit";
                    SubMenu.EntityMenu(subMenu);
                    break;
                case "5":
                    bool leaveRecordMenu = false;
                    while (!leaveRecordMenu)
                    {
                        Console.WriteLine("MEDICAL RECORDS Menu. These are the options: ");
                        Console.WriteLine("1. Create ");
                        Console.WriteLine("2. Edit ");
                        Console.WriteLine("3. Show ");
                        Console.WriteLine("4. Leave ");
                        string option = Menu.EmptyInputValidation("Enter option: ");
                        switch (option)
                        {
                            case "1":
                                medicalRecordsController.CreateMedicalRecord();
                                break;
                            case "2":
                                medicalRecordsController.EditMedicalRecord();
                                break;
                            case "3":
                                medicalRecordsController.ShowMedicalRecord();
                                break;
                            case "4":
                                Console.WriteLine("Leaving this menu");
                                leaveRecordMenu = true;
                                break;
                            default:
                                Console.WriteLine("Please, enter valid option: ");
                                break;
                        }
                    }
                    break;
                case "6":
                    Console.WriteLine("Advanced Queries: ");
                    Console.WriteLine("1. Client with their pets ");
                    Console.WriteLine("2. Vet with most visits handled ");
                    Console.WriteLine("3. Breed with most visits ");
                    Console.WriteLine("4. Client with most pets ");
                    string optionQueries = Menu.EmptyInputValidation("Enter option: ");
                    switch (optionQueries)
                    {
                        case "1":
                            queriesController.clientPets();
                            break;
                        case "2":
                            queriesController.VetMostVisits();
                            break;
                        case "3":
                            medicalRecordsController.ShowMedicalRecord();
                            break;
                        case "4":
                            Console.WriteLine("Leaving this menu");
                            leaveRecordMenu = true;
                            break;
                        default:
                            Console.WriteLine("Please, enter valid option: ");
                            break;
                    }
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("Leaving this menu...");
                    leaveMenu = true;
                    break;
                default:
                    Console.WriteLine("Please, enter valid option: ");
                    break;
            }
        }
    }
    
    public static string EmptyInputValidation(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Value required. Try Again!");
            } 
        }
    }

    public static int IntegerValidation(string prompt)
    {
        while (true)
        {
            string input = EmptyInputValidation(prompt);
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Value must be a number!");
            }
        }
    }

    public static string YnValidation(string prompt)
    {
        while (true)
        {
            string input = EmptyInputValidation(prompt).ToLower();
            if (input == "y" || input == "n")
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input! Try Again!");
            }
        }
    }
    public static DateTime ValidDateInput(string prompt)
    {
        while (true)
        {
            string input = EmptyInputValidation(prompt);
            if (DateTime.TryParse(input, out DateTime date))
            {
                return date;
            }
            else
            {
                Console.WriteLine("Invalid date. Try again.");
            }
        }
    }
}
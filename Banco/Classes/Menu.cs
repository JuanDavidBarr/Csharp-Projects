namespace Banco.Classes;

public class Menu
{
    Bank bank = new Bank();
    public void ShowMenu()
    {
        bool leaveMenu = false;
        while (!leaveMenu)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create account");
            Console.WriteLine("2. Show balance");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Leave this menu");
            string userOption = Console.ReadLine();
            switch (userOption)
            {
                case "1":
                    Console.WriteLine("=====Creating account=====");
                    string accountNumberForNewAcc = EmptyInputValidation("Account number: ");
                    string accountUser =  EmptyInputValidation("Account user: ");
                    bank.CreateAccount(accountNumberForNewAcc, accountUser);
                    break;
                case "2": 
                    Console.WriteLine("=====Showing account balance=====");
                    string accountNumber = EmptyInputValidation("Account number: ");
                    bank.ShowBalance(accountNumber);
                    break;
                case "3":
                    Console.WriteLine("=====Deposting money to account=====");
                    string accountNumberForDeposit = EmptyInputValidation("Account number: ");
                    int deposit = IntegerInputValidation("How much do you want to deposit: ");
                    bank.Deposit(accountNumberForDeposit, deposit);
                    break;
                case "4":
                    leaveMenu = true;
                    Console.WriteLine("Leaving this menu...");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
    public string EmptyInputValidation(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Value required, try again");
            }
        }
    }

    public int IntegerInputValidation(string prompt)
    {
        while (true)
        {
            var input = EmptyInputValidation(prompt);
            if (int.TryParse(input, out var age))
            {
                return age;
            }
            else
            {
                Console.WriteLine("Value is not a number, try again");
            }
        }
    }
}
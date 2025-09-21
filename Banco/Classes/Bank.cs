namespace Banco.Classes;
using Banco.Classes;

public class Bank
{
    public List<Account> Accounts = new List<Account>();
    public void CreateAccount(string accountNumber, string accountUser)
    {
        Account newAccount = new Account
        {
            Number = accountNumber,
            User = accountUser,
            Balance = 0
        };
        Accounts.Add(newAccount);
        Console.WriteLine("Account created successfully!");
        Console.WriteLine($"Account number: {newAccount.Number}. \n Account user: {newAccount.User}. \nBalance: {newAccount.Balance}");
    }

    public void ShowBalance(string accountNumber)
    {
        var result = Accounts.FirstOrDefault(account => account.Number == accountNumber);
        if (result != null)
        {
            Console.WriteLine("Account balance:");
            Console.WriteLine($"Balance: {result.Balance}");
        }
        else
        {
            Console.WriteLine("Account not found!");
        }
    }

    public void Deposit(string accountNumber, int deposit)
    {
        var result = Accounts.FirstOrDefault(account => account.Number == accountNumber);
        if (result != null)
        {
            int newBalance = result.Balance + deposit;
            result.Balance = newBalance;
            Console.WriteLine("Deposit successfully!:");
            Console.WriteLine($"Balance: {result.Balance}");
        }
        else
        {
            Console.WriteLine("Account not found!");
        }
    }
}
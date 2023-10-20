using System;
using System.Collections.Generic;

// Code Smell 1: Lack of meaningful comments
// Comments help in understanding the code.
class Bank
{
    private List<Account> accounts;

    public Bank()
    {
        accounts = new List<Account>();
    }

    // Code Smell 2: Inadequate method naming
    public void AddAccount(Account a)
    {
        accounts.Add(a);
    }

    public void DisplayAccountInfo()
    {
        foreach (var a in accounts)
        {
            a.DisplayInfo();
            Console.WriteLine();
        }
    }

    public void ProcessTransactions()
    {
        foreach (var a in accounts)
        {
            Console.WriteLine($"Processing transactions for account {a.AccountNumber}...");
            a.Deposit(1000);
            a.Withdraw(500);
            Console.WriteLine($"New balance: {a.Balance:C2}");
            Console.WriteLine();
        }
    }
}

class Account
{
    public int AccountNumber { get; }
    public string Owner { get; set; }
    public decimal Balance { get; private set; }

    public Account(int acctNo, string owner)
    {
        AccountNumber = acctNo;
        Owner = owner;
        Balance = 0;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"{Owner}'s account ({AccountNumber}) has been credited with {amount:C2}");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"{Owner}'s account ({AccountNumber}) has been debited with {amount:C2}");
        }
        else
        {
            Console.WriteLine("Insufficient funds to complete the withdrawal.");
        }
    }

    // Code Smell 3: Lack of validation and handling for null
    public void DisplayInfo()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Owner: {Owner}");
        Console.WriteLine($"Balance: {Balance:C2}");
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        Account a1 = new Account(1001, "Alice");
        Account a2 = new Account(1002, "Bob");

        bank.AddAccount(a1);
        bank.AddAccount(a2);

        bank.DisplayAccountInfo();
        Console.WriteLine();

        bank.ProcessTransactions();
    }
}

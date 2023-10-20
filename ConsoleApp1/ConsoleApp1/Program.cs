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

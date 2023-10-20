namespace ConsoleApp1;

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
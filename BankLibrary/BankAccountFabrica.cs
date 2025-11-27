namespace BankLibrary;
public static class BankAccountFabrica
{
    private static Dictionary<Guid, BankAccountTumakov> accounts = new Dictionary<Guid, BankAccountTumakov>();
    public static Guid CreateAccount()
    {
        BankAccountTumakov account = new BankAccountTumakov();
        accounts[account.AccountNumber] = account;
        return account.AccountNumber;
    }
    public static Guid CreateAccount(decimal balance)
    {
        BankAccountTumakov account = new BankAccountTumakov(balance);
        accounts[account.AccountNumber] = account;
        return account.AccountNumber;
    }
    public static Guid CreateAccount(BankAccount bankAccountType)
    {
        BankAccountTumakov account = new BankAccountTumakov(bankAccountType);
        accounts[account.AccountNumber] = account;
        return account.AccountNumber;
    }
    public static Guid CreateAccount(BankAccount bankAccountType, decimal balance)
    {
        BankAccountTumakov account = new BankAccountTumakov(bankAccountType, balance);
        accounts[account.AccountNumber] = account;
        return account.AccountNumber;
    }
    public static BankAccountTumakov GetAccount(Guid accountNumber)
    {
        accounts.TryGetValue(accountNumber, out BankAccountTumakov account); //TryGetValue безопасный способ получить значение из словаря по ключу без исключений
        return account;
    }
    public static bool ClosingAccount(Guid accountNumber)
    {
        return accounts.Remove(accountNumber);//Dictionary.Remove(key) удаляет ключ-значение из словаря
    }
    public static void PrintInfo()
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("нет счета");
            return;
        }
        foreach (BankAccountTumakov account in accounts.Values)
        {
            Console.WriteLine($"Счёт: {account.AccountNumber}");
            Console.WriteLine($"Тип: {account.BankAccountType}");
            Console.WriteLine($"Баланс: {account.Balance}");
        }
    }
}


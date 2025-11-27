class Program
{
    static void Main()
    {
        Console.WriteLine("Упражнение 1");
        Guid acc1 = BankAccountFabrica.CreateAccount();
        Guid acc2 = BankAccountFabrica.CreateAccount(1000m);
        Guid acc3 = BankAccountFabrica.CreateAccount(BankAccount.Savings);
        Guid acc4 = BankAccountFabrica.CreateAccount(BankAccount.Savings, 5000m);
        BankAccountTumakov account2 = BankAccountFabrica.GetAccount(acc2);
        if (account2 != null)
        {
            account2.Deposit(2600);
            account2.Withdrawal(56);
        }
        BankAccountTumakov account3 = BankAccountFabrica.GetAccount(acc3);
        BankAccountTumakov account4 = BankAccountFabrica.GetAccount(acc4);
        if (account4 != null && account3 != null)
        {
            account4.Transfer(account3, 1000);
        }
        BankAccountFabrica.PrintInfo();
        bool closing = BankAccountFabrica.ClosingAccount(acc1);
        if (closing)
        {
            Console.WriteLine("Счёт закрыт");
        }
        else
        {
            Console.WriteLine("Счет не закрыт");
        }
        Console.WriteLine("Домашнее задание 11.1");
        Building building = Creator.CreateBuild(300, 12, 215, 5);
        Building building2 = Creator.CreateBuild(120, 10, 800, 4);
        Console.WriteLine(building.BuildingNumber);
        Console.WriteLine(building2.BuildingNumber);
    }
}


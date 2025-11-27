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
        Console.WriteLine("Упражнение 12.1");
        BankAccountExercise12 acc5 = new BankAccountExercise12(BankAccount.Savings, 2600);
        BankAccountExercise12 acc6 = new BankAccountExercise12(BankAccount.Savings, 2599);
        BankAccountExercise12 acc7 = new BankAccountExercise12(BankAccount.Savings, 1999);
        Console.WriteLine(acc7); 
        Console.WriteLine(acc5 == acc6);
        Console.WriteLine(acc5.Equals(acc6));
        Console.WriteLine(acc5 == acc5);
        Console.WriteLine(acc5 != acc6);
        Console.WriteLine(acc5.GetHashCode() == acc6.GetHashCode());
        Console.WriteLine("Упражнение 12.2");
        RationalNumbers a1 = new RationalNumbers(1, 2);
        RationalNumbers b1 = new RationalNumbers(3, 4);
        RationalNumbers c1 = new RationalNumbers(5, 6);
        Console.WriteLine($"{a1 + b1}");
        Console.WriteLine($"{a1 - c1}");
        Console.WriteLine($"{a1 * c1}");
        Console.WriteLine($"{a1 / c1}");
        Console.WriteLine($"{b1 % c1}");
        Console.WriteLine($"{a1 == b1}");
        Console.WriteLine($"{a1 > c1}");
        Console.WriteLine($"{a1 <= b1}");
        int toInt = (int)a1;
        float toFloat = (float)a1;
        Console.WriteLine($"int: {toInt}");
        Console.WriteLine($"float: {toFloat}");
        Console.WriteLine("Домашнее задание 12.1");
        ComplexNumbers z1 = new ComplexNumbers(2, 5);
        ComplexNumbers z2 = new ComplexNumbers(1, 4);
        Console.WriteLine($"{z1 + z2}");
        Console.WriteLine($"{z1 - z2}");
        Console.WriteLine($"{z1 * z2}");
        Console.WriteLine($"{z1 / z2}");
        Console.WriteLine($"{z1 == z2}");
        Console.WriteLine($"{z1 != z2}");
        Console.WriteLine("Домашнее задание 12.2");
        BookContainer books = new BookContainer(
            new Book("Зацепить 13-ого", "Хлоя Уолш", "Эксмо"),
            new Book("Великий Гэтсби", "Фрэнсис Скотт Фицджеральд", "Эксклюзивная классика"),
            new Book("Восхитительная ведьма", "Анна Джей", "Клевер")
        );
        books.Sorting(BookCompare.Naming);
        Console.WriteLine("Названия: ");
        books.PrintInfo();
        books.Sorting(BookCompare.Authorship);
        Console.WriteLine("Автор: ");
        books.PrintInfo();
        books.Sorting(BookCompare.Publication);
        Console.WriteLine("Издательство: ");
        books.PrintInfo();
    }
}


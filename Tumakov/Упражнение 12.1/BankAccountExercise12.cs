public class BankAccountExercise12
{
    public Guid AccountNumbers { get; set; }
    public decimal Balances { get; set; }
    public BankAccount BankAccountTypes { get; set; }
    private Queue<BankTransaction> transaction;
    internal BankAccountExercise12()
    {
        AccountNumbers = Guid.NewGuid();
        Balances = 0;
        BankAccountTypes = BankAccount.Checking;
        transaction = new Queue<BankTransaction>();
    }
    internal BankAccountExercise12(decimal balance)
    {
        AccountNumbers = Guid.NewGuid();
        Balances = balance;
        BankAccountTypes = BankAccount.Checking;
        transaction = new Queue<BankTransaction>();
    }
    internal BankAccountExercise12(BankAccount type)
    {
        AccountNumbers = Guid.NewGuid();
        Balances = 0;
        BankAccountTypes = type;
        transaction = new Queue<BankTransaction>();
    }
    internal BankAccountExercise12(BankAccount type, decimal balance)
    {
        AccountNumbers = Guid.NewGuid();
        Balances = balance;
        BankAccountTypes = type;
        transaction = new Queue<BankTransaction>();
    }
    public bool Deposit(decimal summa)
    {
        if (summa <= 0)
        {
            Console.WriteLine("Ошибка. Введите сумму больше 0");
            return false;
        }
        Balances += summa;
        transaction.Enqueue(new BankTransaction(summa));
        Console.WriteLine($"Зачислено {summa}. Ваш баланс: {Balances}");
        return true;
    }
    public bool Withdrawal(decimal summa)
    {
        if (summa <= 0)
        {
            Console.WriteLine("Ошибка. Введите сумму больше 0");
            return false;
        }
        if (summa > Balances)
        {
            Console.WriteLine("Недостаточно средств на счёте.");
            return false;
        }
        Balances -= summa;
        transaction.Enqueue(new BankTransaction(summa));
        Console.WriteLine($"Снятие {summa}. Ваш баланс: {Balances}");
        return true;
    }
    public bool Transfer(BankAccountExercise12 toAccount, decimal transferAmount)
    {
        if (toAccount == null)
        {
            Console.WriteLine("Ошибка. Укажите счёт получателя.");
            return false;
        }
        if (transferAmount <= 0)
        {
            Console.WriteLine("Сумма перевода должна быть больше 0.");
            return false;
        }
        if (Withdrawal(transferAmount))
        {
            toAccount.Deposit(transferAmount);
            return true;
        }
        return false;
    }
    public void TransactionOperation()
    {
        Console.WriteLine("История операций:");
        foreach (BankTransaction operation in transaction)
        {
            Console.WriteLine($"Время: {operation.DateAndTime:yyyy-MM-dd HH:mm}, сумма: {operation.Summa}");
        }
    }
    public static bool operator ==(BankAccountExercise12 value1, BankAccountExercise12 value2)
    {
        if (ReferenceEquals(value1, value2))
        {
            return true;
        }
        if (value1 is null || value2 is null)
        {
            return false;
        }
        else
        {
            return value1.Equals(value2);
        }
    }
    public static bool operator !=(BankAccountExercise12 value1, BankAccountExercise12 value2)
    {
        return !(value1 == value2);
    }
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (ReferenceEquals(this, obj)) //ReferenceEquals возвращает true, если обе переменные ссылаются на один и тот же объект в памяти

        {
            return true;
        }
        BankAccountExercise12 other = (BankAccountExercise12)obj;// явное приведение
        return AccountNumbers == other.AccountNumbers && Balances == other.Balances && BankAccountTypes == other.BankAccountTypes;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(AccountNumbers, Balances, BankAccountTypes);// комбинация хеш-кодов
    }
    public override string ToString()
    {
        return $"Счёт: {AccountNumbers}, Тип: {BankAccountTypes}, Баланс: {Balances}";
    }
}

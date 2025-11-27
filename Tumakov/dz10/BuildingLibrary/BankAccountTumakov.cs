namespace BankAccountLibrary
{
    public class BankAccountTumakov
    {
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public BankAccount BankAccountType { get; set; }
        private Queue<BankTransaction> bankTransaction;
        internal BankAccountTumakov()
        {
            AccountNumber = Guid.NewGuid();
            Balance = 0;
            BankAccountType = BankAccount.Checking;
            bankTransaction = new Queue<BankTransaction>();
        }
        internal BankAccountTumakov(decimal balance)
        {
            AccountNumber = Guid.NewGuid();
            Balance = balance;
            BankAccountType = BankAccount.Checking;
            bankTransaction = new Queue<BankTransaction>();
        }
        internal BankAccountTumakov(BankAccount type)
        {
            AccountNumber = Guid.NewGuid();
            Balance = 0;
            BankAccountType = type;
            bankTransaction = new Queue<BankTransaction>();
        }
        internal BankAccountTumakov(BankAccount type, decimal balance)
        {
            AccountNumber = Guid.NewGuid();
            Balance = balance;
            BankAccountType = type;
            bankTransaction = new Queue<BankTransaction>();
        }
        public bool Deposit(decimal summa)
        {
            if (summa <= 0)
            {
                Console.WriteLine("Ошибка. Введите сумму больше 0");
                return false;
            }
            Balance += summa;
            bankTransaction.Enqueue(new BankTransaction(summa));
            Console.WriteLine($"Зачислено {summa}. Ваш баланс: {Balance}");
            return true;
        }
        public bool Withdrawal(decimal summa)
        {
            if (summa <= 0)
            {
                Console.WriteLine("Ошибка. Введите сумму больше 0");
                return false;
            }
            if (summa > Balance)
            {
                Console.WriteLine("Недостаточно средств на счёте.");
                return false;
            }
            Balance -= summa;
            bankTransaction.Enqueue(new BankTransaction(summa));
            Console.WriteLine($"Снятие {summa}. Ваш баланс: {Balance}");
            return true;
        }
        public bool Transfer(BankAccountTumakov toAccount, decimal transferAmount)
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
            foreach (BankTransaction operation in bankTransaction)
            {
                Console.WriteLine($"Время: {operation.DateAndTime:yyyy-MM-dd HH:mm}, сумма: {operation.Summa}");
            }
        }
    }
}
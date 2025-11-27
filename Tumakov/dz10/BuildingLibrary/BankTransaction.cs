namespace BankAccountLibrary
{
    public class BankTransaction
    {
        public readonly DateTime DateAndTime;
        public readonly decimal Summa;

        public BankTransaction(decimal summa)
        {
            DateAndTime = DateTime.Now;
            Summa = summa;
        }
    }
}

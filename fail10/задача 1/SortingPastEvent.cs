class SortingPastEvent : IComparer<PastEvent>
{
    public int Compare(PastEvent x, PastEvent y)
    {
        if (x == null && y == null)
        {
            return 0;
        }
        if (x == null) // x правее в списке
        {
            return 1;
        }
        if (y == null)//x левее в списке
        {
            return -1;
        }
        return y.Date.CompareTo(x.Date); // сортируем от новых к старым
    }
}
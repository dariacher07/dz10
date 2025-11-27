public class RationalNumbers
{
    private long numerator;
    private long denominator;
    public RationalNumbers(long numerator, long denominator)
    {
        if (denominator == 0)
        {
            this.numerator = 0;
            this.denominator = 1;
            return;
        }
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
        long nod = NOD(Math.Abs(numerator), Math.Abs(denominator));
        this.numerator = numerator / nod;
        this.denominator = denominator / nod;
    }
    public long Numerator
    {
        get { return numerator; }
    }

    public long Denominator
    {
        get { return denominator; }
    }
    private static long NOD(long a, long b)
    {
        while (b != 0)
        {
            long с = b;
            b = a % b;
            a = с;
        }
        return a;
    }
    public static bool operator ==(RationalNumbers a, RationalNumbers b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }
        if (a is null || b is null)
        {
            return false;
        }
        else
        {
            return a.Equals(b);
        }
    }
    public static bool operator !=(RationalNumbers a, RationalNumbers b)
    {
        return !(a == b);
    }
    public override bool Equals(object obj)
    {
        if (obj is RationalNumbers other)
        {
            return numerator == other.numerator &&
                   denominator == other.denominator;
        }
        return false;
    }
    public static bool operator <(RationalNumbers a, RationalNumbers b)
    {
        return a.numerator * b.denominator < b.numerator * a.denominator;
    }
    public static bool operator >(RationalNumbers a, RationalNumbers b)
    {
        return a.numerator * b.denominator > b.numerator * a.denominator;
    }
    public static bool operator <=(RationalNumbers a, RationalNumbers b)
    {
        return a < b || a == b;
    }
    public static bool operator >=(RationalNumbers a, RationalNumbers b)
    {
        return a > b || a == b;
    }
    public static RationalNumbers operator +(RationalNumbers a, RationalNumbers b)
    {
        long numerator = a.numerator * b.denominator + b.numerator * a.denominator;
        long denominator = a.denominator * b.denominator;
        return new RationalNumbers(numerator, denominator);
    }
    public static RationalNumbers operator -(RationalNumbers a, RationalNumbers b)
    {
        long numerator = a.numerator * b.denominator - b.numerator * a.denominator;
        long denominator = a.denominator * b.denominator;
        return new RationalNumbers(numerator, denominator);
    }
    public static RationalNumbers operator ++(RationalNumbers a)
    {
        return a + 1;
    }
    public static RationalNumbers operator --(RationalNumbers a)
    {
        return a - 1;
    }
    public override string ToString()
    {
        if (denominator == 1)
        {
            return numerator.ToString();
        }
        return numerator.ToString() + "/" + denominator.ToString();
    }
    public static implicit operator RationalNumbers(int value)
    {
        return new RationalNumbers(value, 1);
    }
    public static explicit operator RationalNumbers(float a)
    {
        long b = 1000000;
        long c = (long)(a * b);
        return new RationalNumbers(c, b);
    }
    public static explicit operator int(RationalNumbers a)
    {
        return (int)((double)a.numerator / a.denominator);
    }
    public static explicit operator float(RationalNumbers a)
    {
        return (float)((double)a.numerator / a.denominator);
    }
    public static RationalNumbers operator *(RationalNumbers a, RationalNumbers b)
    {
        return new RationalNumbers(a.numerator * b.numerator, a.denominator * b.denominator);
    }
    public static RationalNumbers operator /(RationalNumbers a, RationalNumbers b)
    {
        if (b.numerator == 0)
        {
            Console.WriteLine("Нельзя делить на ноль");
            return new RationalNumbers(0,1);
        }
        return new RationalNumbers(a.numerator * b.denominator, a.denominator * b.numerator);
    }
    public static RationalNumbers operator %(RationalNumbers a, RationalNumbers b)
    {
        if (b.numerator == 0)
            return new RationalNumbers(0,1);
        long a1 = a.numerator * b.denominator;
        long b1 = a.denominator * b.numerator;
        if (b1 < 0)
        {
            a1 = -a1;
            b1 = -b1;
        }
        long value;
        if (a1 >= 0)
        {
            value = a1 / b1;
        }
        else
        {
            value = (a1 - b1 + 1) / b1;
        }
        return a - b * new RationalNumbers(value,1);
    }
}

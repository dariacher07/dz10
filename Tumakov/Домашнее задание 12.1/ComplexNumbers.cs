public class ComplexNumbers
{
    public double Real { get; }
    public double Imaginary { get; }
    public ComplexNumbers(double real = 0, double imaginary = 0)
    {
        Real = real;
        Imaginary = imaginary;
    }
    public static ComplexNumbers operator +(ComplexNumbers a, ComplexNumbers b)
    {
        return new ComplexNumbers(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }
    public static ComplexNumbers operator -(ComplexNumbers a, ComplexNumbers b)
    {
        return new ComplexNumbers(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }
    public static ComplexNumbers operator *(ComplexNumbers a, ComplexNumbers b)
    {
        double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
        double imag = a.Real * b.Imaginary + a.Imaginary * b.Real;
        return new ComplexNumbers(real, imag);
    }
    public static ComplexNumbers operator /(ComplexNumbers a, ComplexNumbers b)
    {
        if (b.Real == 0 && b.Imaginary == 0)
            throw new DivideByZeroException();
        double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        double real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator;
        double imag = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator;
        return new ComplexNumbers(real, imag);
    }
    public static bool operator ==(ComplexNumbers a, ComplexNumbers b)
    {
        return a.Real == b.Real && a.Imaginary == b.Imaginary;
    }
    public static bool operator !=(ComplexNumbers a, ComplexNumbers b)
    {
        return !(a == b);
    }
    public override string ToString()
    {
        if (Imaginary >= 0)
        {
            return Real + "+" + Imaginary + "i";
        }
        else
        {
            return Real + Imaginary + "i";
        }
    }
}

using System;

class Fraction
{
    private int numerator;
    private int denominator;

    // סעיף א + ג:
    public Fraction(int num, int den)
    {
        numerator = num;
        denominator = den;
        Reduce();
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }

    private void Reduce()
    {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // סעיף ב: 
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int num = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
        int den = f1.denominator * f2.denominator;
        return new Fraction(num, den);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int num = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
        int den = f1.denominator * f2.denominator;
        return new Fraction(num, den);
    }

    // סעיף ד
  
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator);
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.numerator * f2.denominator, f1.denominator * f2.numerator);
    }

    public static bool operator <(Fraction f1, Fraction f2)
    {
        return f1.numerator * f2.denominator < f2.numerator * f1.denominator;
    }

    public static bool operator >(Fraction f1, Fraction f2)
    {
        return f1.numerator * f2.denominator > f2.numerator * f1.denominator;
    }

    public static bool operator ==(Fraction f1, Fraction f2)
    {
        return f1.numerator == f2.numerator && f1.denominator == f2.denominator;
    }

    public static bool operator !=(Fraction f1, Fraction f2)
    {
        return !(f1 == f2);
    }

    public override bool Equals(object obj)
    {
        if (obj is Fraction other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return numerator.GetHashCode() ^ denominator.GetHashCode();
    }

    public void Print()
    {
        Console.WriteLine($"{numerator}/{denominator}");
    }
}

// Main

class Program
{
    static void Main()
    {
        Fraction f1 = new Fraction(8, 12); 
        Fraction f2 = new Fraction(1, 3);

        Console.Write("חיבור: ");
        (f1 + f2).Print();

        Console.Write("חיסור: ");
        (f1 - f2).Print();

        Console.Write("כפל: ");
        (f1 * f2).Print();

        Console.Write("חילוק: ");
        (f1 / f2).Print();

        Console.WriteLine("השוואות:");
        Console.WriteLine($"f1 > f2: {f1 > f2}");
        Console.WriteLine($"f1 < f2: {f1 < f2}");
        Console.WriteLine($"f1 == f2: {f1 == f2}");
        Console.WriteLine($"f1 != f2: {f1 != f2}");
    }
}

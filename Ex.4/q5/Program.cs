using System;

class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor + צמצום השבר
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

    // Operator Overloading לחיבור
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.numerator * f2.denominator + f2.numerator * f1.denominator,
                            f1.denominator * f2.denominator);
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }
}

class GenericOperationTable<T>
{
    private T[] elements;
    private Func<T, T, T> operation; // delegate לפעולה

    public GenericOperationTable(T[] elems, Func<T, T, T> op)
    {
        elements = elems;
        operation = op;
    }

    public void PrintTable()
    {
        int n = elements.Length;

        // הדפסת כותרות עמודות
        Console.Write("       ");
        foreach (var e in elements)
            Console.Write($"{e,-8}");
        Console.WriteLine();

        // הדפסת השורות עם הפעולה
        foreach (var row in elements)
        {
            Console.Write($"{row,-7}");
            foreach (var col in elements)
            {
                T result = operation(row, col);
                Console.Write($"{result,-8}");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        // יצירת השברים 1/12 עד 12/12
        Fraction[] fractions = new Fraction[12];
        for (int i = 1; i <= 12; i++)
        {
            fractions[i - 1] = new Fraction(i, 12);
        }

        // יצירת הטבלה הגנרית עם פעולת חיבור
        GenericOperationTable<Fraction> table = new GenericOperationTable<Fraction>(
            fractions,
            (a, b) => a + b
        );

        // הדפסת לוח החיבור
        table.PrintTable();
    }
}

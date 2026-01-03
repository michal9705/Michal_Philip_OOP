// סעיף א: הגדרת delegate
public delegate double BinaryOperation(double x, double y);

// סעיף ב: הגדרת פונקציות סטטיות
public static class Calculator
{
    public static double Add(double x, double y)
    {
        return x + y;
    }

    public static double Subtract(double x, double y)
    {
        return x - y;
    }

    public static double Multiply(double x, double y)
    {
        return x * y;
    }

 // סעיף ג: פונקציה ApplyOperation
    public static double ApplyOperation(BinaryOperation bOp, double a, double b)
    {
        return bOp(a, b);
    }
}

// דוגמת שימוש
class Program
{
    static void Main()
    {
        double a = 5;
        double b = 3;

        Console.WriteLine("Add: " + Calculator.ApplyOperation(Calculator.Add, a, b));       // 8
        Console.WriteLine("Subtract: " + Calculator.ApplyOperation(Calculator.Subtract, a, b)); // 2
        Console.WriteLine("Multiply: " + Calculator.ApplyOperation(Calculator.Multiply, a, b)); // 15
    }
}

using System;

class Program
{
    // חלק א – החלפת פריטים במערך
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // חלק ב – החלפת שני משתנים גנרית
    static void SwapVars<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        // דוגמה לפונקציה של מערך
        int[] numbers = { 1, 2, 3 };
        Console.WriteLine("מקורי: " + string.Join(", ", numbers));
        Swap(numbers, 0, 2);
        Console.WriteLine("לאחר Swap: " + string.Join(", ", numbers));

        // דוגמה לפונקציה גנרית עם משתנים
        int x = 5, y = 10;
        Console.WriteLine($"לפני SwapVars: x={x}, y={y}");
        SwapVars(ref x, ref y);
        Console.WriteLine($"לאחר SwapVars: x={x}, y={y}");

        // דוגמה לפונקציה גנרית עם פריטי מערך
        SwapVars(ref numbers[0], ref numbers[1]);
        Console.WriteLine("לאחר SwapVars על מערך: " + string.Join(", ", numbers));
    }
}

using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int n = 50_000_000; 
        int[] arr = new int[n];
        long sum = 0;

        for (int i = 0; i < n; i++)
            arr[i] = i;

        Stopwatch sw = new Stopwatch();

        // 1. גישה רציפה
        sw.Start();
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
        }
        sw.Stop();
        Console.WriteLine("Sequential access: " + sw.ElapsedMilliseconds + " ms");

        // 2. גישה בקפיצות (Strided)
        sw.Reset();
        sw.Start();

        int stride = 1024; 
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            sum += arr[index];
            index = (index + stride) % n; 
        }

        sw.Stop();
        Console.WriteLine("Strided access:   " + sw.ElapsedMilliseconds + " ms");

        // 3. גישה אקראית
        Random rnd = new Random();
        sw.Reset();
        sw.Start();

        for (int i = 0; i < n; i++)
        {
            int randomIndex = rnd.Next(n);
            sum += arr[randomIndex];
        }

        sw.Stop();
        Console.WriteLine("Random access:    " + sw.ElapsedMilliseconds + " ms");

        Console.WriteLine("sum = " + sum);
    }
}

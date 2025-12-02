using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        int size = 1_000_000;
        int[] array = new int[size];

        // מאתחלים את המערך בערכים כלשהם
        for (int i = 0; i < size; i++)
            array[i] = i;

        // ---------- מצב א: גישה לאזורים שונים ----------
        Stopwatch sw1 = Stopwatch.StartNew();

        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < size / 2; i++)
                array[i] += 1;  // פעולה על חצי ראשון
        });

        Thread t2 = new Thread(() =>
        {
            for (int i = size / 2; i < size; i++)
                array[i] += 1;  // פעולה על חצי שני
        });

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        sw1.Stop();
        Console.WriteLine($"זמן ריצה מצב א (אזורים שונים): {sw1.ElapsedMilliseconds} ms");

        // ---------- מצב ב: גישה לכל המערך ----------
        // אתחול מחדש של המערך
        for (int i = 0; i < size; i++)
            array[i] = i;

        object lockObj = new object(); // מנגנון סנכרון

        Stopwatch sw2 = Stopwatch.StartNew();

        Thread t3 = new Thread(() =>
        {
            for (int i = 0; i < size; i++)
            {
                lock (lockObj) // כל thread "ננעל" בזמן עדכון המערך
                {
                    array[i] += 1;
                }
            }
        });

        Thread t4 = new Thread(() =>
        {
            for (int i = 0; i < size; i++)
            {
                lock (lockObj)
                {
                    array[i] += 1;
                }
            }
        });

        t3.Start();
        t4.Start();
        t3.Join();
        t4.Join();

        sw2.Stop();
        Console.WriteLine($"זמן ריצה מצב ב (גישה לכל המערך): {sw2.ElapsedMilliseconds} ms");
    }
}

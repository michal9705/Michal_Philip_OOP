using System;

namespace ArrayProcessingProject
{
    // 2. מחלקה ArrayProcessor
    public class ArrayProcessor
    {
        // פונקציה שמקבלת מערך של double ופונקציה שמבצעת פעולה על כל איבר
        public static void ProcessArray(double[] array, Action<double> unaryAction)
        {
            foreach (var item in array)
            {
                unaryAction(item);
            }
        }
    }

    // 3א. חישוב סכום
    public class SumCalculator
    {
        public double Sum { get; private set; } = 0;

        public void AddToSum(double value)
        {
            Sum += value;
        }
    }

    // 3ב. חישוב מקסימום
    public class MaxCalculator
    {
        public double Max { get; private set; } = double.MinValue;

        public void CheckMax(double value)
        {
            if (value > Max)
                Max = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 4. יצירת מערך אקראי
            Random rnd = new Random();
            double[] numbers = new double[10];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rnd.NextDouble() * 100;

            // חישוב סכום ומקסימום באמצעות מחלקות
            SumCalculator sumCalc = new SumCalculator();
            MaxCalculator maxCalc = new MaxCalculator();

            ArrayProcessor.ProcessArray(numbers, sumCalc.AddToSum);
            ArrayProcessor.ProcessArray(numbers, maxCalc.CheckMax);

            Console.WriteLine("Sum: " + sumCalc.Sum);
            Console.WriteLine("Max: " + maxCalc.Max);

            // 5. חישוב סכום ומקסימום באמצעות lambda ו-closure
            double sumLambda = 0;
            double maxLambda = double.MinValue;

            ArrayProcessor.ProcessArray(numbers, n => sumLambda += n);
            ArrayProcessor.ProcessArray(numbers, n => { if (n > maxLambda) maxLambda = n; });

            Console.WriteLine("Sum (lambda): " + sumLambda);
            Console.WriteLine("Max (lambda): " + maxLambda);
        }
    }
}

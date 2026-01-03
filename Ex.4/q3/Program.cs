using System;
using System.Collections.Generic;

class OperationTable<T>
{
    // delegate לפעולה בינארית
    public delegate T OpFunc(T x, T y);

    private List<T> row_values;
    private List<T> col_values;
    private T[,] table;
    private OpFunc op;

    public OperationTable(List<T> row_values, List<T> col_values, OpFunc op)
    {
        this.row_values = row_values;
        this.col_values = col_values;
        this.op = op;

        table = new T[row_values.Count, col_values.Count];

        // לולאה בתוך לולאה לחישוב הטבלה
        for (int i = 0; i < row_values.Count; i++)
        {
            for (int j = 0; j < col_values.Count; j++)
            {
                table[i, j] = op(row_values[i], col_values[j]);
            }
        }
    }

    public void Print()
    {
        for (int i = 0; i < row_values.Count; i++)
        {
            for (int j = 0; j < col_values.Count; j++)
            {
                Console.Write($"{table[i, j]}\t");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<double> row_values = new List<double>();
        for (int i = 1; i <= 4; i++)
        {
            row_values.Add(1.0 / i);
        }

        List<double> col_values = new List<double>();
        for (int i = 1; i < 5; i++)
        {
            col_values.Add(1.0 / i);
        }

        OperationTable<double> t1 =
            new OperationTable<double>(row_values, col_values, (x, y) => x + y);

        t1.Print();
    }
}

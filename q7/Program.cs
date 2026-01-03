using System;
using System.Collections.Generic;

class OperationTable<T>
{
    // delegate שמגדיר טיפוס של פעולה
    public delegate T OpFunc(T x, T y);

    // משתנה מהטיפוס של הפעולה
    public OpFunc op;

    private List<T> rowValues;
    private List<T> colValues;

    public OperationTable(List<T> _rowValues, List<T> _colValues, OpFunc _op)
    {
        rowValues = _rowValues;
        colValues = _colValues;
        op = _op;
    }

    public void Print()
    {
        foreach (T row in rowValues)
        {
            foreach (T col in colValues)
            {
                Console.Write(op(row, col) + "\t");
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
        for (int i = 1; i <= 4; i++)
        {
            col_values.Add(1.0 / i);
        }

        OperationTable<double> t1 =
            new OperationTable<double>(row_values, col_values, (x, y) => x + y);

        t1.Print();
    }
}

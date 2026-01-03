using System;

namespace OperationTableApp
{
    // הגדרת המחלקה
    public class OperationTable
    {
        private int startRow, endRow;
        private int startCol, endCol;
        private Func<int, int, int> operation;

        // Constructor שמקבל טווח שורות, טווח עמודות ופעולה
        public OperationTable(int startRow, int endRow, int startCol, int endCol, Func<int, int, int> op)
        {
            this.startRow = startRow;
            this.endRow = endRow;
            this.startCol = startCol;
            this.endCol = endCol;
            this.operation = op;
        }

        // פונקציה שמדפיסה את הלוח
        public void Print()
        {
            // הדפסת הכותרת של העמודות
            Console.Write("\t");
            for (int col = startCol; col <= endCol; col++)
            {
                Console.Write(col + "\t");
            }
            Console.WriteLine();

            // הדפסת הלוח עצמו
            for (int row = startRow; row <= endRow; row++)
            {
                Console.Write(row + "\t"); // כותרת השורה
                for (int col = startCol; col <= endCol; col++)
                {
                    Console.Write(operation(row, col) + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    // דוגמה לשימוש
    class Program
    {
        static void Main(string[] args)
        {
            // לוח כפל 1-10
            OperationTable multiplicationTable = new OperationTable(1, 10, 1, 10, (a, b) => a * b);
            Console.WriteLine("לוח כפל:");
            multiplicationTable.Print();

            Console.WriteLine();

            // לוח חיבור 1-5
            OperationTable additionTable = new OperationTable(1, 5, 1, 5, (a, b) => a + b);
            Console.WriteLine("לוח חיבור:");
            additionTable.Print();
        }
    }
}

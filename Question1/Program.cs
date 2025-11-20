using System;

namespace q1
{
    
    public struct PointStruct
    {
        public int X;
    }

    public class PointClass
    {
        public int X;
    }

    internal class Program
    {
        static void ModifyStruct(PointStruct point)
        {
            point.X = 100;
        }

        static void ModifyClass(PointClass point)
        {
            point.X = 100;
        }

        static void ModifyStructByRef(ref PointStruct point) 
        {
            point.X = 500;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("תרגיל 1: הדגמת Class (Reference) מול Struct (Value)\n");


            Console.WriteLine("=== 1.א.1: הדגמת השמה (Assignment) ===");

            // Struct (By Value): העתק מלא
            PointStruct ps1 = new PointStruct { X = 5 };
            PointStruct ps2 = ps1;
            ps2.X = 999;
            Console.WriteLine($"Struct ps1.X (מקורי): {ps1.X}"); // פלט: 5
            Console.WriteLine($"Struct ps2.X (עותק ששונה): {ps2.X}"); // פלט: 999

            // Class (By Reference): העתק של הכתובת
            PointClass pc1 = new PointClass { X = 5 };
            PointClass pc2 = pc1;
            pc2.X = 999;
            Console.WriteLine($"Class pc1.X (מקורי): {pc1.X}"); // פלט: 999
            Console.WriteLine($"Class pc2.X (הפניה לאותו אובייקט): {pc2.X}"); // פלט: 999

            Console.WriteLine("\n-------------------------------------------------\n");

            // 1.א.2: הדגמה באמצעות העברה לפונקציה

            Console.WriteLine("=== 1.א.2: הדגמת העברה לפונקציה (Method Call) ===");

            // Struct (By Value) - הפונקציה משנה רק את העותק
            PointStruct s3 = new PointStruct { X = 50 };
            Console.WriteLine($"Struct s3.X לפני קריאה: {s3.X}"); // פלט: 50
            ModifyStruct(s3);
            Console.WriteLine($"Struct s3.X אחרי קריאה: {s3.X}"); // פלט: 50

            // Class (By Reference) - הפונקציה משנה את המקור
            PointClass c3 = new PointClass { X = 50 };
            Console.WriteLine($"Class c3.X לפני קריאה: {c3.X}"); // פלט: 50
            ModifyClass(c3);
            Console.WriteLine($"Class c3.X אחרי קריאה: {c3.X}"); // פלט: 100

            Console.WriteLine("\n-------------------------------------------------\n");

            // 1.ב: שימוש מפורש ב-ref לשינוי Struct

            Console.WriteLine("=== 1.ב: שימוש מפורש ב-ref לשינוי Struct ===");

            PointStruct s4 = new PointStruct { X = 1 };
            Console.WriteLine($"Struct s4.X לפני קריאה עם ref: {s4.X}"); // פלט: 1
            ModifyStructByRef(ref s4);
            Console.WriteLine($"Struct s4.X אחרי קריאה עם ref: {s4.X}"); // פלט: 500
        }
    }
}
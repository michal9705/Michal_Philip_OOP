using System;

public class Program
{
    // הגדרת גדלים לבדיקה
    // int תופס 4 בתים (bytes)
    private const int int_size_bytes = sizeof(int);

    // גודל בינוני: 1 מיליון איברים (כ-4MB)
    private const int medium_size = 1_000_000;

    // גודל קרוב לגבול ה-2GB, שהוא מגבלת הקצאה נפוצה (2GB = 536,870,912 איברים)
    private const int large_size_near_2GB = 536_870_912;

    // גודל המערך המקסימלי התיאורטי (מעט פחות מ-Int32.MaxValue)
    // הערה: בדיקה זו דורשת הפעלת gcAllowVeryLargeObjects וריצה ב-64-bit.
    // גודל זה הוא כ-8GB.
    private const int max_theoretical_size = 2_147_483_591; // 2^31 - 57 איברים

    public static void Main(string[] args)
    {
        Console.WriteLine("--- בדיקת הקצאת זיכרון למערכי int ב-C# ---");
        Console.WriteLine($"גודל Int32: {int_size_bytes} בתים.");
        Console.WriteLine("---------------------------------------------");

        // 1. בדיקת מערך בגודל קטן
        AllocateArray(medium_size);

        // 2. בדיקת מערך בגודל גדול (מתקרב ל-2GB)
        AllocateArray(large_size_near_2GB);

        // 3. בדיקת המגבלה המקסימלית התיאורטית
        // הערה: ניסיון זה עלול להיכשל אם אין מספיק זיכרון רציף או אם ההגדרות (64-bit ו-gcAllowVeryLargeObjects) אינן מוגדרות כראוי.
        AllocateArray(max_theoretical_size);

        Console.WriteLine("\n--- סיום הבדיקה ---");

        // תשובות תיאורטיות לשאלה:
        DisplayTheoreticalAnswers();
    }

    /// <summary>
    /// מנסה להקצות מערך int בגודל נתון ומדפיס את הסטטוס.
    /// משתמש ב-try-catch כדי לטפל בחריגות OutOfMemoryException.
    /// </summary>
    /// <param name="size">מספר האיברים במערך.</param>
    public static void AllocateArray(int size)
    {
        // חישוב הגודל הכולל בבתים וב-GB
        long totalBytes = (long)size * int_size_bytes;
        double totalGigabytes = totalBytes / (1024.0 * 1024.0 * 1024.0);

        Console.Write($"\nמנסה להקצות מערך של {size:N0} איברים ({totalGigabytes:F2} GB)... ");

        try
        {
            // **נקודת הקצאת הזיכרון**: יצירת המערך עצמו
            int[] largeArray = new int[size];

            // בדיקה שולית לוודא נגישות
            largeArray[0] = 1;

            Console.WriteLine("✅ הצליח.");
        }
        catch (OutOfMemoryException)
        {
            // נתפס כאשר המערכת לא מצליחה להקצות את הבלוק הרציף המבוקש
            Console.WriteLine("❌ נכשל! - System.OutOfMemoryException (נגמר הזיכרון).");
        }
        catch (Exception ex)
        {
            // לכידת חריגות אחרות (כגון OverflowException אם מריצים ב-32-bit ללא תמיכה מתאימה)
            Console.WriteLine($"❌ נכשל! - חריגה: {ex.GetType().Name}.");
        }
    }

    /// <summary>
    /// מציג את התשובות התיאורטיות הנדרשות מהתיעוד.
    /// </summary>
    public static void DisplayTheoreticalAnswers()
    {
        Console.WriteLine("\n=======================================================");
        Console.WriteLine("        --- תשובות תיאורטיות על מגבלות הזיכרון ---");
        Console.WriteLine("=======================================================");

        // --- תשובה 1: גודל מערך מקסימלי ---
        Console.WriteLine("## 1. הגודל המקסימלי התיאורטי למערך בודד (באיברים):");
        Console.WriteLine($"   * הגודל המקסימלי הוא: {max_theoretical_size:N0} איברים (עבור int, זה כ-8 GB).");
        Console.WriteLine("   * זה נובע מכך שגודל המערך נשמר על ידי משתנה מסוג Int32, המוגבל ל-2,147,483,647.");
        Console.WriteLine("   * בפועל, המגבלה היא מעט נמוכה יותר בשל תקורה פנימית של המערכת.");
        Console.WriteLine("   * כדי להקצות מעל 2 GB, נדרשת הרצה ב-64-bit והפעלת התכונה 'gcAllowVeryLargeObjects'.");

        // --- תשובה 2: סך זיכרון מקסימלי ---
        Console.WriteLine("\n## 2. סך הזיכרון המקסימלי שניתן להקצות במערכת:");
        Console.WriteLine("   * **בסביבת 32-bit (x86)**: המגבלה היא כ-2 GB לכל תהליך (Process).");
        Console.WriteLine("   * **בסביבת 64-bit (x64)**: המגבלה היא בפועל סך הזיכרון הפיזי (RAM) + הזיכרון הווירטואלי (קובץ ההחלפה).");
        Console.WriteLine("   * המגבלה התיאורטית של מרחב הכתובות ב-64-bit היא עצומה, אך בפועל היא מוגבלת על ידי המשאבים הזמינים במחשב.");
    }
}
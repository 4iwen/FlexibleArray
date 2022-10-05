namespace FlexibleArray;

static class Program
{
    static void Main(string[] args)
    {
        Example();
    }
    
    private static void Example()
    {
        Random random = new Random();

        FlexibleArray<int> array = new FlexibleArray<int>(random.Next(1, 30));

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(100);
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("- Insert and remove elements -");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(array.ToString());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Insert at");
        Console.ForegroundColor = ConsoleColor.Green;
        array.InsertAt(2, 333);
        Console.WriteLine(array.ToString());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Remove at");
        Console.ForegroundColor = ConsoleColor.Green;
        array.RemoveAt(2);
        Console.WriteLine(array.ToString());
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("- Joining two arrays -");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(array.ToString());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Join");
        Console.ForegroundColor = ConsoleColor.Green;
        array.Join(new FlexibleArray<int>(new [] { 1, 2, 3, 4, 5, }));
        Console.WriteLine(array.ToString());
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("- Splitting array by odd and even indices -");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(array.ToString());
        FlexibleArray<int> odd;
        FlexibleArray<int> even;
        array.SplitByOddEvenIndex(out even, out odd);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Even");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(even.ToString());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Odd");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(odd.ToString());
    }
}
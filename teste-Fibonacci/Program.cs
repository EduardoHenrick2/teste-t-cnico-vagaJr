using System;

class Program
{
    public static void Fibonacci(int n)
    {
        if (n == 0) 
            return;

        long a = 0, b = 1;

        for (int i = 0; i < n; i++)
        {
            Console.Write(a);

            if (i < n - 1) 
                Console.Write(", ");

            long temp = a + b;
            a = b;
            b = temp;
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        Fibonacci(3);
        Fibonacci(5);
        Fibonacci(7);
    }
}
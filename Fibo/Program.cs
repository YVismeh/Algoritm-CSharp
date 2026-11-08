using System;

namespace Fibo
{

    class Program
    {
        static int Fibonacci(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
        }
    }
}

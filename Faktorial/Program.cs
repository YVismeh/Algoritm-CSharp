using System;

namespace Faktorial
{

    class Program
    {
        static int Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        static void Main()
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());

            int result = Factorial(n);

            Console.WriteLine("Factorial = " + result);
        }
    }
}

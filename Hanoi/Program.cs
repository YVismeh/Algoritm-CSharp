using System;

namespace Hanoi
{

    class Program
    {
        static void Hanoi(int n, char source, char destination, char auxiliary)
        {
            if (n == 1)
            {
                Console.WriteLine(source + " -> " + destination);
                return;
            }

            Hanoi(n - 1, source, auxiliary, destination);

            Console.WriteLine(source + " -> " + destination);

            Hanoi(n - 1, auxiliary, destination, source);
        }

        static void Main()
        {
            Console.Write("Enter number of disks: ");
            int n = int.Parse(Console.ReadLine());

            Hanoi(n, 'A', 'C', 'B');
        }
    }
}

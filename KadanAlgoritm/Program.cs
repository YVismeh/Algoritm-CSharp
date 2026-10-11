using System;

class Program
{
    static void Main()
    {
        int[] a = new int[7];

        // input
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write($"Enter number {i+1}: ");
            a[i] = int.Parse(Console.ReadLine());
        }

        int currentSum = a[0];
        int maxSum = a[0];

        int start = 0;     // start index of best choise
        int end = 0;       // end index of best choise
        int tempStart = 0; 

		// Main Algoritm
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > currentSum + a[i])
            {
                currentSum = a[i];
                tempStart = i;
            }
            else
            {
                currentSum += a[i];
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                start = tempStart;
                end = i;
            }
        }

        Console.WriteLine("\nSum of MAX: " + maxSum);

        Console.Write("Best choise: ");

        for (int i = start; i <= end; i++)
        {
            Console.Write(a[i] + " ");
        }

        Console.WriteLine();
    }
}

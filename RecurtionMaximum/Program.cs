using System;

namespace RecurtionMaximum
{

    class Program
    {
        static int FindMax(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            int max = FindMax(arr, index + 1);

            if (arr[index] > max)
            {
                return arr[index];
            }

            return max;
        }

        static void Main()
        {
            int[] numbers = { 12, 45, 7, 89, 23, 56 };

            int max = FindMax(numbers, 0);

            Console.WriteLine("Maximum = " + max);
        }
    }
}

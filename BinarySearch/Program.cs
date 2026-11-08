using System;

namespace BinarySearch
{
    class Program
    {

        static int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == target)
                {
                    return mid;
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80 };

            Console.Write("Enter number: ");
            int target = int.Parse(Console.ReadLine());

            int result = BinarySearch(numbers, target);

            if (result != -1)
            {
                Console.WriteLine("Number found at index: " + result);
            }
            else
            {
                Console.WriteLine("Number not found!");
            }
        }
    }
}


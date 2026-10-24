
using System;

class Program
{
    static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    static void Main()
    {
        int[] numbers = { 5, 3, 4, 1, 2 };

        Console.WriteLine("Before sorting:");
        Console.WriteLine(string.Join(", ", numbers));

        InsertionSort(numbers);

        Console.WriteLine("After sorting:");
        Console.WriteLine(string.Join(", ", numbers));
    }
}

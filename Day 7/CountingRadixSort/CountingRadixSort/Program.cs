using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingRadixSort
{
    internal class Program
    {
        static void Main()
        {
            // 1. Counting Sort (Marks)
            int[] marks = { 78, 95, 45, 62, 78, 90, 45 };
            Console.WriteLine("Original Marks:");
            Console.WriteLine(string.Join(" ", marks));

            CountingSort(marks, marks.Max());

            Console.WriteLine("Sorted Marks (Counting Sort):");
            Console.WriteLine(string.Join(" ", marks));

            // 2. Radix Sort (Registration Numbers)
            int[] regNumbers = { 102345, 984321, 345678, 123456, 567890 };
            Console.WriteLine("Original Registration Numbers:");
            Console.WriteLine(string.Join(" ", regNumbers));

            RadixSort(regNumbers);

            Console.WriteLine("Sorted Registration Numbers (Radix Sort):");
            Console.WriteLine(string.Join(" ", regNumbers));
        }

        static void CountingSort(int[] arr, int maxValue)
        {
            int[] count = new int[maxValue + 1];
            foreach (int num in arr) { count[num]++; }

            int index = 0;
            for (int i = 0; i <= maxValue; i++)
            {
                while (count[i] > 0)
                {
                    arr[index++] = i;
                    count[i]--;
                }
            }
        }

        static void RadixSort(int[] arr)
        {
            int max = arr.Max();
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountSortForRadix(arr, exp);
            }
        }

        static void CountSortForRadix(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            Array.Copy(output, arr, n);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Array of integers
            int[] ints = { 45, 4, -3, 44, -25, 86, 17, -8, 79, -120 };

            // LINQ Queries
            var evenNumbers = ints.Where(i => i % 2 == 0);  // Even numbers
            var oddNumbers = ints.Where(i => i % 2 != 0);   // Odd numbers
            var negativeNumbers = ints.Where(i => i < 0);   // Negative numbers
            var positiveNumbers = ints.Where(i => i > 0);   // Positive numbers
            var between15And22 = ints.Where(i => i > 15 && i < 22); // Numbers between 15 and 22
            var squares = ints.Select(i => i * i);          // Squares of all numbers

            // Print results using helper method
            PrintResults("Even Numbers", evenNumbers);
            PrintResults("Odd Numbers", oddNumbers);
            PrintResults("Negative Numbers", negativeNumbers);
            PrintResults("Positive Numbers", positiveNumbers);
            PrintResults("Numbers Between 15 and 22", between15And22);
            PrintResults("Squares of All Numbers", squares);
        }

        // Helper method to print results with a title
        static void PrintResults(string title, IEnumerable<int> items)
        {
            Console.WriteLine($"{title}:");
            Console.WriteLine(string.Join(", ", items)); // Join items with a comma for cleaner output
            Console.WriteLine();
        }
    }
}

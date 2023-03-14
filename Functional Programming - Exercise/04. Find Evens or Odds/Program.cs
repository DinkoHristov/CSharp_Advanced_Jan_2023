using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = input[0];
            int upperBound = input[1];

            List<int> numbers = new List<int>();

            string evenOrOdd = Console.ReadLine();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEvenOrOdd = EvenOrOdd(evenOrOdd);
            
            foreach (var number in numbers
                .Where(x => isEvenOrOdd(x)))
            {
                Console.Write($"{number} ");
            }
        }

        public static Predicate<int> EvenOrOdd(string command)
        {
            if (command == "even")
            {
                return x => x % 2 == 0;
            }
            else if (command == "odd")
            {
                return x => x % 2 != 0;
            }

            return null;
        }
    }
}

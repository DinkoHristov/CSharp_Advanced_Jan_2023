using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();
            for (int i = 1; i <= endOfRange; i++)
            {
                bool isTrue = true;
                foreach (int divider in dividers)
                {
                    if (i % divider != 0)
                    {
                        isTrue = false;
                        continue;
                    }
                }

                if (isTrue)
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

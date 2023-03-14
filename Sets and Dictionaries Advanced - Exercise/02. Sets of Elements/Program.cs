using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] countArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int setOneCount = countArgs[0];
            int setTwoCount = countArgs[1];

            HashSet<int> setOne = new HashSet<int>();
            for (int i = 0; i < setOneCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                setOne.Add(number);
            }

            HashSet<int> setTwo = new HashSet<int>();
            for (int j = 0; j < setTwoCount; j++)
            {
                int number = int.Parse(Console.ReadLine());

                setTwo.Add(number);
            }

            foreach (int number in setOne)
            {
                if (setTwo.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}

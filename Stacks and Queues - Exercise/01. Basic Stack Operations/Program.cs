using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = inputArgs[0];
            int elementsToPop = inputArgs[1];
            int searchingElement = inputArgs[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> elements = new Stack<int>();
            for (int i = 0; i < elementsToPush; i++)
            {
                int currNumber = numbers[i];
                elements.Push(currNumber);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                elements.Pop();
            }

            if (elements.Count > 0)
            {
                if (elements.Contains(searchingElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(elements.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}

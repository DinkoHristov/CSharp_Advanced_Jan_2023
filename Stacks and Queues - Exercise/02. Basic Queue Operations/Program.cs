using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToEnqueue = inputArgs[0];
            int elementsToDequeue = inputArgs[1];
            int searchingElement = inputArgs[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> elements = new Queue<int>();
            for (int i = 0; i < elementsToEnqueue; i++)
            {
                elements.Enqueue(numbers[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                elements.Dequeue();
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

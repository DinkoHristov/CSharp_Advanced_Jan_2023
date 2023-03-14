using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>(inputNumbers);
            int biggestOrder = numbers.Max();

            while (numbers.Any()) 
            {
                quantity -= numbers.Peek();
                if (quantity < 0)
                {
                    break;
                }

                numbers.Dequeue();
            }

            if (numbers.Any())
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine($"Orders left: {string.Join(" ", numbers)}");
            }
            else
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine("Orders complete");
            }    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> boutique = new Stack<int>(clothes);

            int sum = 0;
            int racks = 1;
            while (boutique.Any())
            {
               sum += boutique.Peek();

               if (sum > capacity)
               {
                   sum = 0;
                   racks++;

                   continue;
               }

                boutique.Pop();
            }

            Console.WriteLine(racks);
        }
    }
}

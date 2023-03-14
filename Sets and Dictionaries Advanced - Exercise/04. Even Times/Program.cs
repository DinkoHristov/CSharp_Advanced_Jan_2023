using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < count; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(currNumber))
                {
                    numbers[currNumber]++;
                }
                else
                {
                    numbers.Add(currNumber, 1);
                }
            }

            foreach (var number in numbers
                .Where(count => count.Value % 2 == 0))
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}

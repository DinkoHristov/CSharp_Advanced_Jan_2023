using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int numberToDivide = int.Parse(Console.ReadLine());

            Predicate<int> isNumberDividible = x => x % numberToDivide == 0;

            foreach (int number in numbers
                .Where(num => !isNumberDividible(num)))
            {
                Console.Write($"{number} ");
            }
        }
    }
}

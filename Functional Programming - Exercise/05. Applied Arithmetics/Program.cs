using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string operation = string.Empty;
            while ((operation = Console.ReadLine()) != "end")
            {
                if (operation == "add")
                {
                    numbers = numbers.Select(num => num + 1).ToList();
                }
                else if (operation == "multiply")
                {
                    numbers = numbers.Select(num => num * 2).ToList();
                }
                else if (operation == "subtract")
                {
                    numbers = numbers.Select(num => num - 1).ToList();
                }
                else if (operation == "divide")
                {
                    numbers = numbers.Select(num => num / 2).ToList();
                }
                else if (operation == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }
    }
}

using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> addSir = x => Console.WriteLine($"Sir {x}");

            names.ToList().ForEach(addSir);
        }
    }
}

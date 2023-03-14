using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int namesLength = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> filter = n => n.Length <= namesLength;

            foreach (string name in names
                .Where(n => filter(n)))
            {
                Console.WriteLine(name);
            }
        }
    }
}

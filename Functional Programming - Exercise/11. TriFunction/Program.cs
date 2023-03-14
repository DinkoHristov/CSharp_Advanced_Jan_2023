using System;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int givenSum = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isNameSumGreaterOrEqualThanGivenSum =
                (name, sum) => name.Sum(ch => ch) >= givenSum;

            Func<string[], int, Func<string, int, bool>, string> firstRightName =
                (givenNames, sum, match) => names.FirstOrDefault(name => match(name, givenSum));

            Console.WriteLine(firstRightName(names, givenSum, isNameSumGreaterOrEqualThanGivenSum));
        }
    }
}

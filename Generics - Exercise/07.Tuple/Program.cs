using System;
using System.Linq;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAddress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] nameBeer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            CustomTuple<string, string> nameAddressTuple = new CustomTuple<string, string>($"{nameAddress[0]} {nameAddress[1]}", nameAddress[2]);

            CustomTuple<string, int> nameBeerTuple = new CustomTuple<string, int>(nameBeer[0], int.Parse(nameBeer[1]));

            CustomTuple<int, double> numbersTuple = new CustomTuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));

            Console.WriteLine(nameAddressTuple);
            Console.WriteLine(nameBeerTuple);
            Console.WriteLine(numbersTuple);
        }
    }
}

using System;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAddress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] nameBeer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] bankInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            CustomTuple<string, string, string> nameAddressTuple = 
                new CustomTuple<string, string, string>($"{nameAddress[0]} {nameAddress[1]}", nameAddress[2], string.Join(" ", nameAddress[3..]));

            CustomTuple<string, int, bool> nameBeerTuple = 
                new CustomTuple<string, int, bool>(nameBeer[0], int.Parse(nameBeer[1]), nameBeer[2] == "drunk");

            CustomTuple<string, double, string> bankTuple = 
                new CustomTuple<string, double, string>(bankInfo[0], double.Parse(bankInfo[1]), bankInfo[2]);

            Console.WriteLine(nameAddressTuple);
            Console.WriteLine(nameBeerTuple);
            Console.WriteLine(bankTuple);
        }
    }
}

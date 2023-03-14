using System;
using System.Linq;

namespace _02.Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            ListyIterator<string> items = new ListyIterator<string>(input.ToList());

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(items.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(items.HasNext());
                }
                else if (command == "Print")
                {
                    try
                    {
                        items.Print();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (command == "PrintAll")
                {
                    try
                    {
                        items.PrintAll();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }
    }
}

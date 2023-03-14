using System;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> customStack = new CustomStack<string>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Push")
                {
                    foreach (var item in commandArgs.Skip(1))
                    {
                        customStack.Push(item);
                    }
                }
                else if (commandArgs[0] == "Pop")
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

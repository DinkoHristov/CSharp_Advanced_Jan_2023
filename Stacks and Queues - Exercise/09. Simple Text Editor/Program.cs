using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOperations = int.Parse(Console.ReadLine());

            Stack<string> changes = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < numberOperations; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArgs[0];

                if (commandType == "1")
                {
                    string newText = commandArgs[1];

                    changes.Push(text.ToString());
                    text.Append(newText);
                }
                else if (commandType == "2")
                {
                    int count = int.Parse(commandArgs[1]);

                    changes.Push(text.ToString());
                    text = text.Remove(text.Length - count, count);
                }
                else if (commandType == "3")
                {
                    int index = int.Parse(commandArgs[1]) - 1;
                    if (index >= 0 && index < text.Length)
                    {
                        Console.WriteLine(text[index].ToString());
                    }
                }
                else if (commandType == "4")
                {
                    text = new StringBuilder(changes.Pop());
                }
            }
        }
    }
}

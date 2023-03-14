using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();

            Queue<string> playlist = new Queue<string>(input);

            while (playlist.Any())
            {
                string[] commandArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArgs[0];

                if (commandType == "Play")
                {
                    playlist.Dequeue();
                }
                else if (commandType == "Add")
                {
                    string song = string.Join(" ", commandArgs.Skip(1));

                    if (playlist.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(song);
                    }
                }
                else if (commandType == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}

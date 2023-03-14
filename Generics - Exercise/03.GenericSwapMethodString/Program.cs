using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Box<string> boxes = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                boxes.Add(input);
            }

            List<int> indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int firstBox = indexes[0];
            int secondBox = indexes[1];

            boxes.SwapBoxes(firstBox, secondBox);

            Console.WriteLine(boxes);
        }
    }
}

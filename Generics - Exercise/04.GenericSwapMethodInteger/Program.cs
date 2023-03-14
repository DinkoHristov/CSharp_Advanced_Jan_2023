using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Box<int> boxes = new Box<int>();

            for (int i = 0; i < count; i++)
            {
                int number =int.Parse( Console.ReadLine());

                boxes.Add(number);
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

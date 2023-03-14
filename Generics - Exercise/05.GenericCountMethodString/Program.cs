using System;

namespace _05.GenericCountMethodString
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

            string itemToCompare = Console.ReadLine();

            Console.WriteLine(boxes.Count(itemToCompare));
        }
    }
}
